﻿using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PhotofileMerger
{
    public partial class SourceControl : UserControl
    {
        private bool isOriginal;
        
        private static int sources = 0;

        public int Id;

        private static DateTime origin_time;

        public delegate void ChangedEventHandler(object sender, OriginDateChangedEventArgs e);

        public static event ChangedEventHandler Changed;

        public delegate void RemovedEventHandler(object sender, EventArgs e);

        public event RemovedEventHandler Removed;

        public static bool ORIGIN = true;

        private bool changeBlocked = false;

        public TimeSpan SourceTimeDiff;

        public SourceControl()
        {
            initializeControl();
            sourceGroupBox.Text = "Source #" + sources;
            photoDateTextBox.TextChanged += sourcePhotoDateChanged;
            if (origin_time != null)
            {
                tryCountDiff(origin_time, FileProcessor.GetExifDateTime(photoDateTextBox.Text));
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
        }
        void originPhotoDateChanged(object sender, EventArgs e)
        {
            OriginDateChangedEventArgs eventArgs = new OriginDateChangedEventArgs(photoDateTextBox.Text);
            origin_time = FileProcessor.GetExifDateTime(photoDateTextBox.Text);
            Changed(this, eventArgs);
        }
        private void sourcePhotoDateChanged(object sender, EventArgs e)
        {
            tryCountDiff(origin_time, FileProcessor.GetExifDateTime(photoDateTextBox.Text));
        }
        void SourceControl_Changed(object sender, OriginDateChangedEventArgs e)
        {
            tryCountDiff(origin_time, FileProcessor.GetExifDateTime(photoDateTextBox.Text));
        }
        private void tryCountDiff(DateTime originTime, DateTime sourceTime)
        {
            if (isOriginal)
            {
               return;
            }
            if (originTime == null || sourceTime == null)
            {
                clearTimeShiftBoxes();
                return;
            }

            SourceTimeDiff = sourceTime.Subtract(originTime);
            updateTimeShiftTextBoxes();
        }

        private void clearTimeShiftBoxes()
        {
            SourceTimeDiff = new TimeSpan(0);
            updateTimeShiftTextBoxes();
        }

        private void updateTimeShiftTextBoxes()
        {
            changeBlocked = true;
            string sign = "+";
            if(SourceTimeDiff.TotalSeconds < 0)
            {
                sign = "-";
            }
            timeShiftDaysT.Text = string.Format("{0}{1}", sign, Math.Abs(SourceTimeDiff.Days));
            timeShiftHoursT.Text = string.Format("{0}", Math.Abs(SourceTimeDiff.Hours));
            timeShiftMinutesT.Text = string.Format("{0}", Math.Abs(SourceTimeDiff.Minutes));
            timeShiftSecondsT.Text = string.Format("{0}", Math.Abs(SourceTimeDiff.Seconds));
            changeBlocked = false;
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
            }
        }

        private void anchorFileTextBox_TextChanged(object sender, EventArgs e)
        {
            DateTime time = FileProcessor.FastGetFileExifDate(anchorFileTextBox.Text);
            string result;
            if (time.Equals(DateTime.MinValue))
            {
                result = "Date of photo is anavailable";
            }
            else
            {
                result = time.ToString();
            }
            photoDateTextBox.Text = result;
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
        private void timeShiftDaysTextBox_TextChanged(object sender, EventArgs e)
        {
            if (changeBlocked)
            {
                return;
            }
            Regex digits = new Regex(@"-?\d{1,2}");
            if (string.IsNullOrEmpty(timeShiftDaysT.Text))
            {
                timeShiftDaysT.Text = "0";
            }
            if (!digits.IsMatch(timeShiftDaysT.Text))
            {
                updateTimeShiftTextBoxes();
                return;
            }
            storeTimeShift();
            updateTimeShiftTextBoxes();
        }

        
        private void timeShiftHoursTextBox_TextChanged(object sender, EventArgs e)
        {
            if (changeBlocked)
            {
                return;
            }
            Regex digits = new Regex(@"\d{1,2}");
                if (string.IsNullOrEmpty(timeShiftHoursT.Text))
                {
                    timeShiftHoursT.Text = "0";
                }
                if (!digits.IsMatch(timeShiftHoursT.Text))
                {
                    updateTimeShiftTextBoxes();
                    return;
                }
                storeTimeShift();
                updateTimeShiftTextBoxes();
        }
        private void timeShiftMinSecTextBox_TextChanged(object sender, EventArgs e)
        {
            if(changeBlocked)
            {
                return;
            }
            TextBox tbSender = sender as TextBox;
            Regex digits = new Regex(@"\d{1,2}");
            if (tbSender != null)
            {
                if (string.IsNullOrEmpty(tbSender.Text))
                {
                    tbSender.Text = "0";
                }
                if (!digits.IsMatch(tbSender.Text))
                {
                    updateTimeShiftTextBoxes();
                    return;
                }
                storeTimeShift();
                updateTimeShiftTextBoxes();
            }
        }
        private void storeTimeShift()
        {
            string shiftStr = string.Format(
                "{0}.{1}:{2}:{3}",
                timeShiftDaysT.Text.Replace("+", ""),
                timeShiftHoursT.Text,
                timeShiftMinutesT.Text,
                timeShiftSecondsT.Text
                );
            SourceTimeDiff = TimeSpan.Parse(shiftStr);
        }
    }
}
