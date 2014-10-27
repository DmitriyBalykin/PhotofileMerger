﻿using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PhotofileMerger
{
    public partial class SourceControl : UserControl
    {
        private bool isOriginal;
        
        private static int sources = 0;

        public int Id;

        private static string origin_time;

        public delegate void ChangedEventHandler(object sender, OriginDateChangedEventArgs e);

        public event ChangedEventHandler Changed;

        public delegate void RemovedEventHandler(object sender, EventArgs e);

        public event RemovedEventHandler Removed;

        public static bool ORIGIN = true;

        public TimeSpan SourceTimeDiff;

        public SourceControl()
        {
            initializeControl();
            sourceGroupBox.Text = "Source #" + sources;
            photoDateTextBox.TextChanged += sourcePhotoDateChanged;
            if(!string.IsNullOrEmpty(origin_time)){
                tryCountDiff(origin_time, photoDateTextBox.Text);
            }
        }
        
        public SourceControl(bool isOrigin)
        {
            initializeControl();
            isOriginal = true;
            sourceGroupBox.Text = "Original source";
            timeShiftPanel.Hide();
            removeSourceButton.Hide();
            photoDateTextBox.TextChanged += originPhotoDateChanged;
        }
        private void initializeControl() {
            InitializeComponent();
            sources++;
            Id = sources;
            Changed += SourceControl_Changed;
            timeShiftLabelReplacer.Text = "              ";
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
                clearTimeShiftBoxes("");
                return;
            }
            DateTime originDateTime = getExifDateTime(origin_time);
            if (originDateTime.Equals(DateTime.MinValue))
            {
                clearTimeShiftBoxes("Origin time is incorrect");
                return;
            }
            DateTime sourceDateTime = getExifDateTime(sourceTime);
            if (sourceDateTime.Equals(DateTime.MinValue))
            {
                clearTimeShiftBoxes("Source time is incorrect");
                return;
            }

            SourceTimeDiff = originDateTime.Subtract(sourceDateTime);
            showTimeShiftBoxes();
            updateTimeShiftTextBoxes();
        }

        private void updateTimeShiftTextBoxes()
        {
            string negativeSign = "+";
            if(SourceTimeDiff.TotalSeconds < 0)
            {
                negativeSign = "-";
            }
            timeShiftDaysT.Text = string.Format("{0}{1}", negativeSign, Math.Abs(SourceTimeDiff.Days));
            timeShiftHoursT.Text = string.Format("{0}", Math.Abs(SourceTimeDiff.Hours));
            timeShiftMinutesT.Text = string.Format("{0}", Math.Abs(SourceTimeDiff.Minutes));
            timeShiftSecondsT.Text = string.Format("{0}", Math.Abs(SourceTimeDiff.Seconds));
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
        public TimeSpan GetTimeShift() {
            return SourceTimeDiff;
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

        private void removeSourceButton_Click(object sender, EventArgs e)
        {
            Removed(this, e);
        }

        public override bool Equals(object obj)
        {
 	         return (obj is SourceControl) && ((SourceControl)obj).Id == Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        private void timeShiftTextBoxes_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void clearTimeShiftBoxes(string text) {
            timeShiftSecondsT.Clear();
            timeShiftMinutesT.Clear();
            timeShiftHoursT.Clear();
            timeShiftDaysT.Clear();
            timeShiftValuePanel.Hide();
            timeShiftLabelReplacer.Show();
            timeShiftLabelReplacer.Text = text;
        }
        private void showTimeShiftBoxes() {
            timeShiftLabelReplacer.Hide();
            timeShiftValuePanel.Show();
        }

    }
}
