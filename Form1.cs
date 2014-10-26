using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace ReadExif
{
    public partial class MainForm : Form
    {
        private List<SourceControl> sources;

        public MainForm()
        {
            InitializeComponent();
            sources = new List<SourceControl>();

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
            sources.Add(control);
            sourcesPanel.Controls.Add(control);
        }
    }
}
