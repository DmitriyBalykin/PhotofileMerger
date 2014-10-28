namespace PhotofileMerger
{
    partial class SourceControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.photoDateTextBox = new System.Windows.Forms.TextBox();
            this.captureDateLabel = new System.Windows.Forms.Label();
            this.timeShiftDaysT = new System.Windows.Forms.TextBox();
            this.timeShiftLabel = new System.Windows.Forms.Label();
            this.rootFolderTextBox = new System.Windows.Forms.TextBox();
            this.rootFolderButton = new System.Windows.Forms.Button();
            this.anchorFileButton = new System.Windows.Forms.Button();
            this.anchorFileTextBox = new System.Windows.Forms.TextBox();
            this.sourceGroupBox = new System.Windows.Forms.GroupBox();
            this.removeSourceButton = new System.Windows.Forms.Button();
            this.timeShiftPanel = new System.Windows.Forms.Panel();
            this.timeShiftValuePanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timeShiftSecondsT = new System.Windows.Forms.TextBox();
            this.timeShiftMinutesT = new System.Windows.Forms.TextBox();
            this.timeShiftHoursT = new System.Windows.Forms.TextBox();
            this.rootFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.anchorFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.sourceGroupBox.SuspendLayout();
            this.timeShiftPanel.SuspendLayout();
            this.timeShiftValuePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // photoDateTextBox
            // 
            this.photoDateTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.photoDateTextBox.Location = new System.Drawing.Point(199, 79);
            this.photoDateTextBox.Name = "photoDateTextBox";
            this.photoDateTextBox.ReadOnly = true;
            this.photoDateTextBox.Size = new System.Drawing.Size(115, 20);
            this.photoDateTextBox.TabIndex = 15;
            // 
            // captureDateLabel
            // 
            this.captureDateLabel.AutoSize = true;
            this.captureDateLabel.Location = new System.Drawing.Point(99, 83);
            this.captureDateLabel.Name = "captureDateLabel";
            this.captureDateLabel.Size = new System.Drawing.Size(98, 13);
            this.captureDateLabel.TabIndex = 14;
            this.captureDateLabel.Text = "Photo capture date";
            // 
            // timeShiftDaysT
            // 
            this.timeShiftDaysT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timeShiftDaysT.Location = new System.Drawing.Point(1, 2);
            this.timeShiftDaysT.Margin = new System.Windows.Forms.Padding(0);
            this.timeShiftDaysT.MaxLength = 5;
            this.timeShiftDaysT.Name = "timeShiftDaysT";
            this.timeShiftDaysT.Size = new System.Drawing.Size(32, 13);
            this.timeShiftDaysT.TabIndex = 13;
            this.timeShiftDaysT.Text = "+0";
            this.timeShiftDaysT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.timeShiftDaysT.TextChanged += new System.EventHandler(this.timeShiftDaysTextBox_TextChanged);
            // 
            // timeShiftLabel
            // 
            this.timeShiftLabel.AutoSize = true;
            this.timeShiftLabel.Location = new System.Drawing.Point(-1, 7);
            this.timeShiftLabel.Name = "timeShiftLabel";
            this.timeShiftLabel.Size = new System.Drawing.Size(52, 13);
            this.timeShiftLabel.TabIndex = 12;
            this.timeShiftLabel.Text = "Time shift";
            // 
            // rootFolderTextBox
            // 
            this.rootFolderTextBox.Location = new System.Drawing.Point(102, 21);
            this.rootFolderTextBox.Name = "rootFolderTextBox";
            this.rootFolderTextBox.Size = new System.Drawing.Size(387, 20);
            this.rootFolderTextBox.TabIndex = 11;
            // 
            // rootFolderButton
            // 
            this.rootFolderButton.Location = new System.Drawing.Point(6, 19);
            this.rootFolderButton.Name = "rootFolderButton";
            this.rootFolderButton.Size = new System.Drawing.Size(90, 23);
            this.rootFolderButton.TabIndex = 10;
            this.rootFolderButton.Text = "Root folder";
            this.rootFolderButton.UseVisualStyleBackColor = true;
            this.rootFolderButton.Click += new System.EventHandler(this.rootFolderButton_Click);
            // 
            // anchorFileButton
            // 
            this.anchorFileButton.Location = new System.Drawing.Point(6, 47);
            this.anchorFileButton.Name = "anchorFileButton";
            this.anchorFileButton.Size = new System.Drawing.Size(90, 23);
            this.anchorFileButton.TabIndex = 8;
            this.anchorFileButton.Text = "Date anchor file";
            this.anchorFileButton.UseVisualStyleBackColor = true;
            this.anchorFileButton.Click += new System.EventHandler(this.anchorFileButton_Click);
            // 
            // anchorFileTextBox
            // 
            this.anchorFileTextBox.Location = new System.Drawing.Point(102, 49);
            this.anchorFileTextBox.Name = "anchorFileTextBox";
            this.anchorFileTextBox.Size = new System.Drawing.Size(387, 20);
            this.anchorFileTextBox.TabIndex = 9;
            this.anchorFileTextBox.TextChanged += new System.EventHandler(this.anchorFileTextBox_TextChanged);
            // 
            // sourceGroupBox
            // 
            this.sourceGroupBox.BackColor = System.Drawing.SystemColors.Control;
            this.sourceGroupBox.Controls.Add(this.removeSourceButton);
            this.sourceGroupBox.Controls.Add(this.photoDateTextBox);
            this.sourceGroupBox.Controls.Add(this.captureDateLabel);
            this.sourceGroupBox.Controls.Add(this.timeShiftPanel);
            this.sourceGroupBox.Controls.Add(this.rootFolderButton);
            this.sourceGroupBox.Controls.Add(this.anchorFileTextBox);
            this.sourceGroupBox.Controls.Add(this.anchorFileButton);
            this.sourceGroupBox.Controls.Add(this.rootFolderTextBox);
            this.sourceGroupBox.Location = new System.Drawing.Point(3, 3);
            this.sourceGroupBox.Name = "sourceGroupBox";
            this.sourceGroupBox.Size = new System.Drawing.Size(500, 108);
            this.sourceGroupBox.TabIndex = 16;
            this.sourceGroupBox.TabStop = false;
            this.sourceGroupBox.Text = "Source #";
            // 
            // removeSourceButton
            // 
            this.removeSourceButton.Location = new System.Drawing.Point(7, 79);
            this.removeSourceButton.Name = "removeSourceButton";
            this.removeSourceButton.Size = new System.Drawing.Size(89, 23);
            this.removeSourceButton.TabIndex = 17;
            this.removeSourceButton.Text = "Remove";
            this.removeSourceButton.UseVisualStyleBackColor = true;
            this.removeSourceButton.Click += new System.EventHandler(this.removeSourceButton_Click);
            // 
            // timeShiftPanel
            // 
            this.timeShiftPanel.Controls.Add(this.timeShiftValuePanel);
            this.timeShiftPanel.Controls.Add(this.timeShiftLabel);
            this.timeShiftPanel.Location = new System.Drawing.Point(316, 75);
            this.timeShiftPanel.Name = "timeShiftPanel";
            this.timeShiftPanel.Size = new System.Drawing.Size(177, 27);
            this.timeShiftPanel.TabIndex = 16;
            // 
            // timeShiftValuePanel
            // 
            this.timeShiftValuePanel.BackColor = System.Drawing.SystemColors.Window;
            this.timeShiftValuePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.timeShiftValuePanel.Controls.Add(this.label4);
            this.timeShiftValuePanel.Controls.Add(this.label3);
            this.timeShiftValuePanel.Controls.Add(this.label2);
            this.timeShiftValuePanel.Controls.Add(this.label1);
            this.timeShiftValuePanel.Controls.Add(this.timeShiftSecondsT);
            this.timeShiftValuePanel.Controls.Add(this.timeShiftMinutesT);
            this.timeShiftValuePanel.Controls.Add(this.timeShiftHoursT);
            this.timeShiftValuePanel.Controls.Add(this.timeShiftDaysT);
            this.timeShiftValuePanel.Location = new System.Drawing.Point(49, 4);
            this.timeShiftValuePanel.Name = "timeShiftValuePanel";
            this.timeShiftValuePanel.Size = new System.Drawing.Size(124, 20);
            this.timeShiftValuePanel.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 2);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "d";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 2);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "h";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 2);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "m";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "s";
            // 
            // timeShiftSecondsT
            // 
            this.timeShiftSecondsT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timeShiftSecondsT.Location = new System.Drawing.Point(98, 2);
            this.timeShiftSecondsT.Margin = new System.Windows.Forms.Padding(0);
            this.timeShiftSecondsT.MaxLength = 2;
            this.timeShiftSecondsT.Name = "timeShiftSecondsT";
            this.timeShiftSecondsT.Size = new System.Drawing.Size(12, 13);
            this.timeShiftSecondsT.TabIndex = 14;
            this.timeShiftSecondsT.Text = "0";
            this.timeShiftSecondsT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.timeShiftSecondsT.TextChanged += new System.EventHandler(this.timeShiftMinSecTextBox_TextChanged);
            // 
            // timeShiftMinutesT
            // 
            this.timeShiftMinutesT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timeShiftMinutesT.Location = new System.Drawing.Point(72, 2);
            this.timeShiftMinutesT.Margin = new System.Windows.Forms.Padding(0);
            this.timeShiftMinutesT.MaxLength = 2;
            this.timeShiftMinutesT.Name = "timeShiftMinutesT";
            this.timeShiftMinutesT.Size = new System.Drawing.Size(12, 13);
            this.timeShiftMinutesT.TabIndex = 14;
            this.timeShiftMinutesT.Text = "0";
            this.timeShiftMinutesT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.timeShiftMinutesT.TextChanged += new System.EventHandler(this.timeShiftMinSecTextBox_TextChanged);
            // 
            // timeShiftHoursT
            // 
            this.timeShiftHoursT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timeShiftHoursT.Location = new System.Drawing.Point(47, 2);
            this.timeShiftHoursT.Margin = new System.Windows.Forms.Padding(0);
            this.timeShiftHoursT.MaxLength = 2;
            this.timeShiftHoursT.Name = "timeShiftHoursT";
            this.timeShiftHoursT.Size = new System.Drawing.Size(12, 13);
            this.timeShiftHoursT.TabIndex = 14;
            this.timeShiftHoursT.Text = "0";
            this.timeShiftHoursT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.timeShiftHoursT.TextChanged += new System.EventHandler(this.timeShiftHoursTextBox_TextChanged);
            // 
            // anchorFileDialog
            // 
            this.anchorFileDialog.FileName = "openFileDialog1";
            // 
            // SourceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SandyBrown;
            this.Controls.Add(this.sourceGroupBox);
            this.Name = "SourceControl";
            this.Size = new System.Drawing.Size(506, 115);
            this.sourceGroupBox.ResumeLayout(false);
            this.sourceGroupBox.PerformLayout();
            this.timeShiftPanel.ResumeLayout(false);
            this.timeShiftPanel.PerformLayout();
            this.timeShiftValuePanel.ResumeLayout(false);
            this.timeShiftValuePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.TextBox photoDateTextBox;
        private System.Windows.Forms.Label captureDateLabel;
        private System.Windows.Forms.TextBox timeShiftDaysT;
        private System.Windows.Forms.Label timeShiftLabel;
        private System.Windows.Forms.TextBox rootFolderTextBox;
        private System.Windows.Forms.Button rootFolderButton;
        private System.Windows.Forms.Button anchorFileButton;
        private System.Windows.Forms.TextBox anchorFileTextBox;
        private System.Windows.Forms.GroupBox sourceGroupBox;
        private System.Windows.Forms.FolderBrowserDialog rootFolderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog anchorFileDialog;
        private System.Windows.Forms.Panel timeShiftPanel;
        private System.Windows.Forms.Button removeSourceButton;
        private System.Windows.Forms.Panel timeShiftValuePanel;
        private System.Windows.Forms.TextBox timeShiftSecondsT;
        private System.Windows.Forms.TextBox timeShiftMinutesT;
        private System.Windows.Forms.TextBox timeShiftHoursT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
