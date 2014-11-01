using System;
using System.IO;
using System.Windows.Forms;

namespace PhotofileMerger
{
    public partial class MainForm : Form
    {
        private static string DEFAULT_FILE_PREFIX = "Image_";

        private const string GO_TEXT = "Go!";
        private const string CANCEL_TEXT = "Cancel";
        private const string FILES_PREPROCESS_TEXT = "Files found:";

        public delegate void ProgressMoved(int progress, object state);

        public event ProgressMoved Progressed;
        public event ProgressMoved FilesCounted;

        public delegate void WorkInProgress();
        public event WorkInProgress workInProgress;

        public delegate void WorkFinished();
        public event WorkFinished workFinished;

        private FileProcessor fileProcessor;

        private bool working = false;

        public MainForm()
        {
            InitializeComponent();
            initializeSourcesPanel();

            goButton.Text = GO_TEXT;

            Progressed += MainForm_Progressed;
            FilesCounted += MainForm_FilesPreprocessed;

            workInProgress += MainForm_workInProgress;
            workFinished += MainForm_workFinished;

            prefixTextBox.Text = DEFAULT_FILE_PREFIX;

            addControl(SourceControl.ORIGIN);
        }

        void MainForm_workFinished()
        {
            working = false;
            goButton.Text = GO_TEXT;
            fileProcessor = null;
        }

        void MainForm_workInProgress()
        {
            working = true;
            progressBar.Value = 0;
            progressBar.Visible = false;
            filesCountLabel.Visible = false;
            filesFoundLabel.Visible = false;
            filesFoundLabel.Text = FILES_PREPROCESS_TEXT;
            goButton.Text = CANCEL_TEXT;
        }
        void MainForm_FilesPreprocessed(int progress, object state)
        {
            if (!filesFoundLabel.Visible)
            {
                filesFoundLabel.Visible = true;
                filesCountLabel.Visible = true;
                progressBar.Visible = true;
            }
            if (state != null)
            {
                progressBar.Value = progress;
                filesCountLabel.Text = state.ToString();
            }
        }

        private void initializeSourcesPanel()
        {
            sourcesPanel = new Sources();
            tableLayoutPanelMain.Controls.Add(sourcesPanel);
        }

        void MainForm_Progressed(int progress, object state)
        {
            if(!progressBar.Visible)
            {
                progressBar.Visible = true;
            }
            if (!filesFoundLabel.Visible)
            {
                filesFoundLabel.Visible = true;
            }
            if (state != null)
            {
                filesCountLabel.Visible = false;
                filesFoundLabel.Text = state.ToString();
            }
            else
            {
                filesFoundLabel.Text = "Sorting ...";
                progressBar.Value = progress;
            }
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
            if (!working)
            {
                bool groupByYear = yearToolStripMenuItem.Checked;
                bool groupByMonth = monthToolStripMenuItem.Checked;
                bool groupByDay = dayToolStripMenuItem.Checked;

                fileProcessor = new FileProcessor(
                    workInProgress,
                    workFinished,
                    destFolderPath.Text,
                    prefixTextBox.Text,
                    Progressed,
                    FilesCounted,
                    new Grouping(
                        yearToolStripMenuItem.Checked,
                        monthToolStripMenuItem.Checked,
                        dayToolStripMenuItem.Checked
                        ));
                fileProcessor.MergeFiles(sourcesPanel.GetSourcesTimeMap());
            }
            else
            {
                fileProcessor.CancelWork();
                progressBar.Value = 0;
                filesCountLabel.Visible = false;
                filesFoundLabel.Visible = false;
            }
            
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
