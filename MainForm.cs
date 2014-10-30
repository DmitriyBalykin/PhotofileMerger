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
            initializeSourcesPanel();

            Progressed += MainForm_Progressed;

            prefixTextBox.Text = DEFAULT_FILE_PREFIX;

            addControl(SourceControl.ORIGIN);
        }

        private void initializeSourcesPanel()
        {
            sourcesPanel = new Sources();
            tableLayoutPanelMain.Controls.Add(sourcesPanel);
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
            bool groupByYear = yearToolStripMenuItem.Checked;
            bool groupByMonth = monthToolStripMenuItem.Checked;
            bool groupByDay = dayToolStripMenuItem.Checked;

            FileProcessor.MergeFiles(
                sourcesPanel.GetSourcesTimeMap(),
                destFolderPath.Text,
                prefixTextBox.Text,
                Progressed,
                new Grouping(
                    yearToolStripMenuItem.Checked,
                    monthToolStripMenuItem.Checked,
                    dayToolStripMenuItem.Checked
                    ));
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

        private void whatsGoingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string manual = "To align files from different sources by date select anchor files from each source. By default each pair from origin source and numbered " +
            " source will be recognized as taken in one time, so difference in time between them will be subtracted to aling both sources.\n Change difference value if this files" +
            " was taken in different time.";
            MessageBox.Show(manual);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Merger for photo files by Dmitriy Balykin\n (C) 2014");
        }
    }
}
