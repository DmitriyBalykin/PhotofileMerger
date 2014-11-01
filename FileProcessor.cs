using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace PhotofileMerger
{
    class FileProcessor
    {
        private const int ORIGIN_DT = 0x9003;

        public const string EXIF_DATE_FORMAT = "yyyy:MM:dd HH:mm:ss";

        public BackgroundWorker backWorker;

        private PhotofileMerger.MainForm.ProgressMoved Progress;
        private PhotofileMerger.MainForm.ProgressMoved FilesCounted;

        public event PhotofileMerger.MainForm.WorkInProgress WorkInProgress;
        public event PhotofileMerger.MainForm.WorkFinished WorkFinished;

        private string FilePrefix;
        private string DestFolder;
        private Grouping Grouping;

        public FileProcessor(
            PhotofileMerger.MainForm.WorkInProgress WorkInProgress,
            PhotofileMerger.MainForm.WorkFinished WorkFinished,
            string destFolder,
            string filePrefix,
            MainForm.ProgressMoved progressed,
            MainForm.ProgressMoved filesCounted,
            Grouping grouping)
        {
            this.WorkInProgress = WorkInProgress;
            this.WorkFinished = WorkFinished;
            Progress = progressed;
            FilesCounted = filesCounted;
            FilePrefix = filePrefix;
            DestFolder = destFolder;
            Grouping = grouping;
        }

        private SortedList<FileRecord, string> filesList;

        public static string GetFileExifDate(string fileName) {
            try
            {
                Bitmap image = new Bitmap(fileName);
                PropertyItem[] propItems = image.PropertyItems;
                for (int i = 0; i < propItems.Length; i++ )
                {
                    if (propItems[i].Id == ORIGIN_DT)
                    {
                        string strValue = System.Text.Encoding.UTF8.GetString(propItems[i].Value).Replace("\0", "");
                        return strValue;
                    }
                }
                image = null;
            }
            catch
            {
                return "";
            }
            return "No origin data available";
        }

        public static DateTime GetExifDateTime(string datestr)
        {
            try
            {
                return DateTime.ParseExact(datestr, FileProcessor.EXIF_DATE_FORMAT, CultureInfo.InvariantCulture);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        public void CancelWork()
        {
            backWorker.CancelAsync();
        }

        internal void MergeFiles(Dictionary<string, TimeSpan> timeShiftDict)
        {
            WorkInProgress();
            
            backWorker = new BackgroundWorker();

            backWorker.DoWork += backWorker_SortFiles;
            backWorker.ProgressChanged += backWorker_FilesCounted;
            backWorker.RunWorkerCompleted += backWorker_FilesCountCompleted;
            backWorker.WorkerReportsProgress = true;
            backWorker.WorkerSupportsCancellation = true;
            backWorker.RunWorkerAsync(timeShiftDict);
        }

        void backWorker_FilesMergeCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            WorkFinished();
        }

        void backWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            Progress(e.ProgressPercentage, e.UserState);
        }

        void backWorker_MergeFiles(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            //Copy files in order of date
            if (filesList == null)
            {
                return;
            }
            int totalDigitsCount = (int)Math.Ceiling(Math.Log10(filesList.Count));
            int counter = 0;
            int totalCount = filesList.Count;
            foreach (KeyValuePair<FileRecord, string> kvp in filesList)
            {
                counter++;

                string sourceFilePath = kvp.Value;
                string destFileName = string.Format("{0}{1}{2}", FilePrefix, counter.ToString("D" + totalDigitsCount), Path.GetExtension(sourceFilePath));
                DateTime destFileDate = kvp.Key.Time;
                string destFilePath = getDestFilePath(destFileName, DestFolder, Grouping, destFileDate);
                try
                {
                    File.Copy(sourceFilePath, destFilePath, true);
                }
                catch
                {
                    MessageBox.Show("Cannot copy image to file " + destFilePath);
                }

                worker.ReportProgress((int)(100 * (double)counter / (double)totalCount));
                if(worker.CancellationPending)
                {
                    return;
                }
            }
            worker.ReportProgress(100, "Completed");
        }

        void backWorker_FilesCountCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Error == null && !e.Cancelled)
            {
                filesList = e.Result as SortedList<FileRecord, string>;

                backWorker = new BackgroundWorker();
                backWorker.DoWork += backWorker_MergeFiles;
                backWorker.ProgressChanged += backWorker_ProgressChanged;
                backWorker.RunWorkerCompleted += backWorker_FilesMergeCompleted;
                backWorker.WorkerReportsProgress = true;
                backWorker.WorkerSupportsCancellation = true;
                backWorker.RunWorkerAsync();
            }
        }

        void backWorker_FilesCounted(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            FilesCounted(e.ProgressPercentage, e.UserState);
        }

        void backWorker_SortFiles(object sender, DoWorkEventArgs e)
        {
            Dictionary<string, TimeSpan> timeShiftDict = e.Argument as Dictionary<string, TimeSpan>;

            BackgroundWorker worker = sender as BackgroundWorker;
            
            if(timeShiftDict == null)
            {
                e.Result = null;
                return;
            }
            //Look for total files in source

            int totalFiles = 0;
            foreach (string rootFolder in timeShiftDict.Keys)
            {
                totalFiles += Directory.GetFiles(rootFolder, "*.*", SearchOption.AllDirectories).Length;
            }

            //Create dictionary of files by date
            SortedList<FileRecord, string> filesList = new SortedList<FileRecord, string>();
            int counter = 0;
            foreach (string rootFolder in timeShiftDict.Keys)
            {
                TimeSpan timeShift;
                if (!timeShiftDict.TryGetValue(rootFolder, out timeShift))
                {
                    timeShift = new TimeSpan(0);
                }
                string[] files = Directory.GetFiles(rootFolder, "*.*", SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    DateTime fileDate = GetExifDateTime(GetFileExifDate(file)).Add(timeShift);
                    filesList.Add(new FileRecord(file, fileDate), file);
                    counter++;
                    worker.ReportProgress((int)(100*counter/totalFiles), totalFiles);
                    if (worker.CancellationPending)
                    {
                        return;
                    }
                }
            }
            e.Result = filesList;
        }

        private static string getDestFilePath(string fileName, string destRootFolder, Grouping grouping, DateTime destFileDate)
        {
            string destFolder = destRootFolder;
            if(grouping.ByYear)
            {
                destFolder = Path.Combine(destFolder, destFileDate.Year.ToString("D4"));
            }
            if (grouping.ByMonth)
            {
                destFolder = Path.Combine(destFolder, destFileDate.ToString("MMMM", CultureInfo.InstalledUICulture));
            }
            if (grouping.ByDay)
            {
                destFolder = Path.Combine(destFolder, destFileDate.Day.ToString("D2"));
            }
            if(!Directory.Exists(destFolder))
            {
                Directory.CreateDirectory(destFolder);
            }
            return Path.Combine(destFolder, fileName);
        }
    }
}
