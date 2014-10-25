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

            SourceControl control = new SourceControl();
            sources.Add(control);
            control.SetOriginal();
            sourcesPanel.Controls.Add(control);
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
            SourceControl control = new SourceControl();
            sources.Add(control);
            sourcesPanel.Controls.Add(control);
        }
    }
}
