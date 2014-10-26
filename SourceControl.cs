using System;
using System.Globalization;
using System.Windows.Forms;

namespace ReadExif
{
    public partial class SourceControl : UserControl
    {
        private bool isOriginal;
        
        private static int sources = 0;

        private static string origin_time;

        public delegate void ChangedEventHandler(object sender, OriginDateChangedEventArgs e);

        public static event ChangedEventHandler Changed;

        public static bool ORIGIN = true;

        public TimeSpan SourceTimeDiff;

        public SourceControl()
        {
            InitializeComponent();
            sources++;
            sourceGroupBox.Text = "Source #" + sources;
            Changed += SourceControl_Changed;
            photoDateTextBox.TextChanged += sourcePhotoDateChanged;

            if(!string.IsNullOrEmpty(origin_time)){
                tryCountDiff(origin_time, photoDateTextBox.Text);
            }
        }
        
        public SourceControl(bool isOrigin)
        {
            isOriginal = true;
            InitializeComponent();
            sources++;
            sourceGroupBox.Text = "Original source";
            Changed += SourceControl_Changed;
            timeShiftPanel.Hide();
            photoDateTextBox.TextChanged += originPhotoDateChanged;
        }

        void originPhotoDateChanged(object sender, EventArgs e)
        {
            OriginDateChangedEventArgs eventArgs = new OriginDateChangedEventArgs(photoDateTextBox.Text);
            origin_time = photoDateTextBox.Text;
            Changed(this, eventArgs);
        }
        private void sourcePhotoDateChanged(object sender, EventArgs e)
        {
            tryCountDiff(origin_time, photoDateTextBox.Text);
        }
        void SourceControl_Changed(object sender, OriginDateChangedEventArgs e)
        {
            tryCountDiff(origin_time, photoDateTextBox.Text);
        }
        private void tryCountDiff(string originTime, string sourceTime) {
            if (isOriginal)
            {
               return;
            }
            if (string.IsNullOrEmpty(originTime) || string.IsNullOrEmpty(sourceTime))
            {
                timeShiftTextBox.Text = "";
                return;
            }
            DateTime originDateTime = getExifDateTime(origin_time);
            if (originDateTime.Equals(DateTime.MinValue))
            {
                timeShiftTextBox.Text = "Origin time is incorrect";
                return;
            }
            DateTime sourceDateTime = getExifDateTime(sourceTime);
            if (sourceDateTime.Equals(DateTime.MinValue))
            {
                timeShiftTextBox.Text = "Source time is incorrect";
                return;
            }

            SourceTimeDiff = originDateTime.Subtract(sourceDateTime);
            timeShiftTextBox.Text = SourceTimeDiff.ToString();
        }
        private DateTime getExifDateTime(string datestr) {
            CultureInfo provider = CultureInfo.InvariantCulture;
            //2013:09:14 15:15:19
            string format = "yyyy:MM:dd HH:mm:ss";
            try
            {
                return DateTime.ParseExact(datestr, format, provider);
            }
            catch {
                return DateTime.MinValue;
            }
        }
        public string GetRootFolder() {
            return rootFolderTextBox.Text;
        }
        public string GetTimeShift() {
            return timeShiftTextBox.Text;
        }
        private void rootFolderButton_Click(object sender, EventArgs e)
        {
            if (rootFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                rootFolderTextBox.Text = rootFolderBrowserDialog.SelectedPath;
                anchorFileDialog.InitialDirectory = rootFolderBrowserDialog.SelectedPath;
            }
        }

        private void anchorFileButton_Click(object sender, EventArgs e)
        {
            if(anchorFileDialog.ShowDialog() == DialogResult.OK){
                anchorFileTextBox.Text = anchorFileDialog.FileName;
                photoDateTextBox.Text = FileProcessor.GetFileExifDate(anchorFileDialog.FileName);
            }
        }

        private void anchorFileTextBox_TextChanged(object sender, EventArgs e)
        {
            photoDateTextBox.Text = FileProcessor.GetFileExifDate(anchorFileTextBox.Text);
        }
    }
}
