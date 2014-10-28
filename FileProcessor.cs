using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;

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
                string strValue;
                int id;
                foreach (PropertyItem item in propItems)
                {
                    id = item.Id;
                    strValue = System.Text.Encoding.UTF8.GetString(item.Value);
                    if (id == ORIGIN_DT)
                    {
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

        internal static void MergeFiles(Dictionary<string, TimeSpan> timeShiftDict, string destFolder, string filePrefix)
        {
            SortedSet<FileRecord> filesList = new SortedSet<FileRecord>();
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
                    DateTime fileDate = GetExifDateTime(file).Add(timeShift);
                    filesList.Add(file, fileDate);
                }
            }

            int totalDigitsCount = (int)Math.Round(Math.Log10(filesList.Count));
            string fileNameFormatter = string.Format("\\\\{0\\}\\{1,D{0}\\}.\\{2\\}", totalDigitsCount);
            int counter = 0;
            foreach(string file in filesList.Keys)
            {
                string destFileName = string.Format(fileNameFormatter, filePrefix, counter, Path.GetExtension(file));
            }
        }
    }
}
