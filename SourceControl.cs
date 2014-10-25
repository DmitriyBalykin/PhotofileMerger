using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ReadExif
{
    public partial class SourceControl : UserControl
    {
        private bool isOriginal;

        private static int sources = 0;
        
        public SourceControl()
        {
            InitializeComponent();
            sources++;
            sourceGroupBox.Text = "Source #" + sources;
        }

        public void SetOriginal()
        {
            isOriginal = true;
            timeShiftPanel.Hide();
            sourceGroupBox.Text = "Original source";
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
