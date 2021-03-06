﻿using System.Windows.Forms;
namespace PhotofileMerger
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.destFolderPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.prefixTextBox = new System.Windows.Forms.TextBox();
            this.addSourceButton = new System.Windows.Forms.Button();
            this.goButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filesSortingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whatsGoingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.filesCountLabel = new System.Windows.Forms.Label();
            this.filesFoundLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Target folder";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // destFolderPath
            // 
            this.destFolderPath.Location = new System.Drawing.Point(123, 5);
            this.destFolderPath.Name = "destFolderPath";
            this.destFolderPath.Size = new System.Drawing.Size(419, 20);
            this.destFolderPath.TabIndex = 3;
            this.destFolderPath.TextChanged += new System.EventHandler(this.destFolderPath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Target file name prefix";
            // 
            // prefixTextBox
            // 
            this.prefixTextBox.Location = new System.Drawing.Point(122, 31);
            this.prefixTextBox.Name = "prefixTextBox";
            this.prefixTextBox.Size = new System.Drawing.Size(419, 20);
            this.prefixTextBox.TabIndex = 6;
            // 
            // addSourceButton
            // 
            this.addSourceButton.Location = new System.Drawing.Point(6, 59);
            this.addSourceButton.Name = "addSourceButton";
            this.addSourceButton.Size = new System.Drawing.Size(108, 25);
            this.addSourceButton.TabIndex = 8;
            this.addSourceButton.Text = "Add source";
            this.addSourceButton.UseVisualStyleBackColor = true;
            this.addSourceButton.Click += new System.EventHandler(this.addSourceButton_Click);
            // 
            // goButton
            // 
            this.goButton.Enabled = false;
            this.goButton.Location = new System.Drawing.Point(434, 59);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(108, 25);
            this.goButton.TabIndex = 9;
            this.goButton.Text = "Go!";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(3, 90);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(539, 20);
            this.progressBar.TabIndex = 11;
            this.progressBar.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(550, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesSortingToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // filesSortingToolStripMenuItem
            // 
            this.filesSortingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yearToolStripMenuItem,
            this.monthToolStripMenuItem,
            this.dayToolStripMenuItem});
            this.filesSortingToolStripMenuItem.Name = "filesSortingToolStripMenuItem";
            this.filesSortingToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.filesSortingToolStripMenuItem.Text = "Files group by";
            // 
            // yearToolStripMenuItem
            // 
            this.yearToolStripMenuItem.CheckOnClick = true;
            this.yearToolStripMenuItem.Name = "yearToolStripMenuItem";
            this.yearToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.yearToolStripMenuItem.Text = "Year";
            // 
            // monthToolStripMenuItem
            // 
            this.monthToolStripMenuItem.CheckOnClick = true;
            this.monthToolStripMenuItem.Name = "monthToolStripMenuItem";
            this.monthToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.monthToolStripMenuItem.Text = "Month";
            // 
            // dayToolStripMenuItem
            // 
            this.dayToolStripMenuItem.CheckOnClick = true;
            this.dayToolStripMenuItem.Name = "dayToolStripMenuItem";
            this.dayToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.dayToolStripMenuItem.Text = "Day";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.whatsGoingToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // whatsGoingToolStripMenuItem
            // 
            this.whatsGoingToolStripMenuItem.Name = "whatsGoingToolStripMenuItem";
            this.whatsGoingToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.whatsGoingToolStripMenuItem.Text = "What\'s going?";
            this.whatsGoingToolStripMenuItem.Click += new System.EventHandler(this.whatsGoingToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 1;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(550, 116);
            this.tableLayoutPanelMain.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.filesCountLabel);
            this.panel1.Controls.Add(this.filesFoundLabel);
            this.panel1.Controls.Add(this.goButton);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.addSourceButton);
            this.panel1.Controls.Add(this.destFolderPath);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Controls.Add(this.prefixTextBox);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 110);
            this.panel1.TabIndex = 14;
            // 
            // filesCountLabel
            // 
            this.filesCountLabel.AutoSize = true;
            this.filesCountLabel.Location = new System.Drawing.Point(276, 93);
            this.filesCountLabel.Name = "filesCountLabel";
            this.filesCountLabel.Size = new System.Drawing.Size(13, 13);
            this.filesCountLabel.TabIndex = 13;
            this.filesCountLabel.Text = "0";
            this.filesCountLabel.Visible = false;
            // 
            // filesFoundLabel
            // 
            this.filesFoundLabel.AutoSize = true;
            this.filesFoundLabel.BackColor = System.Drawing.Color.Transparent;
            this.filesFoundLabel.Location = new System.Drawing.Point(215, 93);
            this.filesFoundLabel.Name = "filesFoundLabel";
            this.filesFoundLabel.Size = new System.Drawing.Size(61, 13);
            this.filesFoundLabel.TabIndex = 12;
            this.filesFoundLabel.Text = "Files found:";
            this.filesFoundLabel.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(550, 149);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Photofile Merger";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox destFolderPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox prefixTextBox;
        private System.Windows.Forms.Button addSourceButton;
        private System.Windows.Forms.Button goButton;
        private Sources sourcesPanel;
        private ProgressBar progressBar;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem filesSortingToolStripMenuItem;
        private ToolStripMenuItem yearToolStripMenuItem;
        private ToolStripMenuItem monthToolStripMenuItem;
        private ToolStripMenuItem dayToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem whatsGoingToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanelMain;
        private Panel panel1;
        private Label filesFoundLabel;
        private Label filesCountLabel;
    }
}

