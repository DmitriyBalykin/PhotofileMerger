using System.Drawing;
using System.Drawing.Imaging;

namespace PhotofileMerger
{
    class FileProcessor
    {
        private const int ORIGIN_DT = 0x9003;

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
                return "Invalid image file selected";
            }
            return "No origin data available";
        }
    }
}
