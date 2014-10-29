using System;
using System.Collections.Generic;
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

        public static string GetFileExifDate(string fileName) {
            try
            {
                Bitmap image = new Bitmap(fileName);
                PropertyItem[] propItems = image.PropertyItems;
                int id;
                foreach (PropertyItem item in propItems)
                {
                    id = item.Id;
                    if (id == ORIGIN_DT)
                    {
                        string strValue = System.Text.Encoding.UTF8.GetString(item.Value).Replace("\0","");
                        return strValue;
                    }
                }
            }
            catch
            {
                return "";
            }
            return "No origin data available";
        }

        public static DateTime GetExifDateTime(string datestr)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            try
            {
                return DateTime.ParseExact(datestr, FileProcessor.EXIF_DATE_FORMAT, provider);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        internal static void MergeFiles(Dictionary<string, TimeSpan> timeShiftDict, string destFolder, string filePrefix, MainForm.ProgressMoved progressed)
        {
            SortedList<FileRecord, string> filesList = new SortedList<FileRecord, string>();
            //Create dictionary of files by date
            foreach(string rootFolder in timeShiftDict.Keys)
            {
                TimeSpan timeShift;
                if(!timeShiftDict.TryGetValue(rootFolder, out timeShift))
                {
                    timeShift = new TimeSpan(0);
                }
                string[] files = Directory.GetFiles(rootFolder, "*.*", SearchOption.AllDirectories);
                foreach(string file in files)
                {
                    DateTime origExifDate = GetExifDateTime(GetFileExifDate(file));
                    DateTime fileDate = origExifDate.Add(timeShift);
                    filesList.Add(new FileRecord(file, fileDate), file);
                }
            }
            //Copy files in order of date
            int totalDigitsCount = (int)Math.Ceiling(Math.Log10(filesList.Count));
            int counter = 0;
            int totalCount = filesList.Count;
            foreach(string sourceFilePath in filesList.Values)
            {
                counter++;
                string destFileName = string.Format("{0}{1}{2}", filePrefix, counter.ToString("D" + totalDigitsCount), Path.GetExtension(sourceFilePath));
                string destFilePath = getDestFilePath(destFileName, destFolder);
                try
                {
                    File.Copy(sourceFilePath, destFilePath, true);
                }
                catch
                {
                    MessageBox.Show("Cannot copy image to file " + destFilePath);
                }
                
                progressed(new ProgressChangedEventArgs(100 * (double)counter / (double)totalCount));
            }
        }

        private static string getDestFilePath(string fileName, string destRootFolder)
        {
            string destFolder = destRootFolder;
            if(!Directory.Exists(destFolder))
            {
                Directory.CreateDirectory(destFolder);
            }
            return Path.Combine(destFolder, fileName);
        }
    }
}
