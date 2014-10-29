using System;
using System.IO;
using System.Windows.Forms;

namespace PhotofileMerger
{
    public partial class MainForm : Form
    {
        private static string DEFAULT_FILE_PREFIX = "Image_";

        public delegate void ProgressMoved(ProgressChangedEventArgs e);
        public event ProgressMoved Progressed;
        public MainForm()
        {
            InitializeComponent();

            Progressed += MainForm_Progressed;

            prefixTextBox.Text = DEFAULT_FILE_PREFIX;

            addControl(SourceControl.ORIGIN);
        }

        void MainForm_Progressed(ProgressChangedEventArgs e)
        {
            if(!progressBar.Visible)
            {
                progressBar.Visible = true;
            }
            progressBar.Value = e.Progress;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if(result == DialogResult.OK){
                destFolderPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void addSourceButton_Click(object sender, EventArgs e)
        {
            addControl(false);
        }
        private void addControl(bool isOrigin) { 
            SourceControl control;
            if(isOrigin){
                control = new SourceControl(SourceControl.ORIGIN);
            }
            else
            {
                control = new SourceControl();
            }
            control.Removed += control_Removed;
            sourcesPanel.AddSource(control);
        }

        void control_Removed(object sender, EventArgs e)
        {
            SourceControl removedControl = sender as SourceControl;
            if (removedControl != null)
            {
                sourcesPanel.RemoveSource(removedControl);
            }
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            FileProcessor.MergeFiles(sourcesPanel.GetSourcesTimeMap(), destFolderPath.Text, prefixTextBox.Text, Progressed);
        }

        private void destFolderPath_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(destFolderPath.Text) || !Directory.Exists(destFolderPath.Text))
            {
                goButton.Enabled = false;
            }
            else
            {
                goButton.Enabled = true;
            }
        }
    }
}
