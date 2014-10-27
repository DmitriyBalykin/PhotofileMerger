using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace PhotofileMerger
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            addControl(SourceControl.ORIGIN);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if(result == DialogResult.OK){
                textBox2.Text = folderBrowserDialog1.SelectedPath;
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
    }
}
