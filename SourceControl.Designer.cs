namespace ReadExif
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
            this.timeShiftTextBox = new System.Windows.Forms.TextBox();
            this.timeShiftLabel = new System.Windows.Forms.Label();
            this.rootFolderTextBox = new System.Windows.Forms.TextBox();
            this.rootFolderButton = new System.Windows.Forms.Button();
            this.anchorFileButton = new System.Windows.Forms.Button();
            this.anchorFileTextBox = new System.Windows.Forms.TextBox();
            this.sourceGroupBox = new System.Windows.Forms.GroupBox();
            this.timeShiftPanel = new System.Windows.Forms.Panel();
            this.rootFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.anchorFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.sourceGroupBox.SuspendLayout();
            this.timeShiftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // photoDateTextBox
            // 
            this.photoDateTextBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.photoDateTextBox.Location = new System.Drawing.Point(119, 79);
            this.photoDateTextBox.Name = "photoDateTextBox";
            this.photoDateTextBox.Size = new System.Drawing.Size(139, 20);
            this.photoDateTextBox.TabIndex = 15;
            // 
            // captureDateLabel
            // 
            this.captureDateLabel.AutoSize = true;
            this.captureDateLabel.Location = new System.Drawing.Point(6, 83);
            this.captureDateLabel.Name = "captureDateLabel";
            this.captureDateLabel.Size = new System.Drawing.Size(98, 13);
            this.captureDateLabel.TabIndex = 14;
            this.captureDateLabel.Text = "Photo capture date";
            // 
            // timeShiftTextBox
            // 
            this.timeShiftTextBox.Location = new System.Drawing.Point(61, 5);
            this.timeShiftTextBox.Name = "timeShiftTextBox";
            this.timeShiftTextBox.Size = new System.Drawing.Size(164, 20);
            this.timeShiftTextBox.TabIndex = 13;
            // 
            // timeShiftLabel
            // 
            this.timeShiftLabel.AutoSize = true;
            this.timeShiftLabel.Location = new System.Drawing.Point(3, 7);
            this.timeShiftLabel.Name = "timeShiftLabel";
            this.timeShiftLabel.Size = new System.Drawing.Size(52, 13);
            this.timeShiftLabel.TabIndex = 12;
            this.timeShiftLabel.Text = "Time shift";
            // 
            // rootFolderTextBox
            // 
            this.rootFolderTextBox.Location = new System.Drawing.Point(119, 21);
            this.rootFolderTextBox.Name = "rootFolderTextBox";
            this.rootFolderTextBox.Size = new System.Drawing.Size(370, 20);
            this.rootFolderTextBox.TabIndex = 11;
            // 
            // rootFolderButton
            // 
            this.rootFolderButton.Location = new System.Drawing.Point(6, 19);
            this.rootFolderButton.Name = "rootFolderButton";
            this.rootFolderButton.Size = new System.Drawing.Size(100, 23);
            this.rootFolderButton.TabIndex = 10;
            this.rootFolderButton.Text = "Root folder";
            this.rootFolderButton.UseVisualStyleBackColor = true;
            this.rootFolderButton.Click += new System.EventHandler(this.rootFolderButton_Click);
            // 
            // anchorFileButton
            // 
            this.anchorFileButton.Location = new System.Drawing.Point(6, 47);
            this.anchorFileButton.Name = "anchorFileButton";
            this.anchorFileButton.Size = new System.Drawing.Size(100, 23);
            this.anchorFileButton.TabIndex = 8;
            this.anchorFileButton.Text = "Date anchor file";
            this.anchorFileButton.UseVisualStyleBackColor = true;
            this.anchorFileButton.Click += new System.EventHandler(this.anchorFileButton_Click);
            // 
            // anchorFileTextBox
            // 
            this.anchorFileTextBox.Location = new System.Drawing.Point(119, 49);
            this.anchorFileTextBox.Name = "anchorFileTextBox";
            this.anchorFileTextBox.Size = new System.Drawing.Size(370, 20);
            this.anchorFileTextBox.TabIndex = 9;
            this.anchorFileTextBox.TextChanged += new System.EventHandler(this.anchorFileTextBox_TextChanged);
            // 
            // sourceGroupBox
            // 
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
            // timeShiftPanel
            // 
            this.timeShiftPanel.Controls.Add(this.timeShiftLabel);
            this.timeShiftPanel.Controls.Add(this.timeShiftTextBox);
            this.timeShiftPanel.Location = new System.Drawing.Point(264, 75);
            this.timeShiftPanel.Name = "timeShiftPanel";
            this.timeShiftPanel.Size = new System.Drawing.Size(231, 27);
            this.timeShiftPanel.TabIndex = 16;
            // 
            // anchorFileDialog
            // 
            this.anchorFileDialog.FileName = "openFileDialog1";
            // 
            // SourceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sourceGroupBox);
            this.Name = "SourceControl";
            this.Size = new System.Drawing.Size(506, 114);
            this.sourceGroupBox.ResumeLayout(false);
            this.sourceGroupBox.PerformLayout();
            this.timeShiftPanel.ResumeLayout(false);
            this.timeShiftPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox photoDateTextBox;
        private System.Windows.Forms.Label captureDateLabel;
        private System.Windows.Forms.TextBox timeShiftTextBox;
        private System.Windows.Forms.Label timeShiftLabel;
        private System.Windows.Forms.TextBox rootFolderTextBox;
        private System.Windows.Forms.Button rootFolderButton;
        private System.Windows.Forms.Button anchorFileButton;
        private System.Windows.Forms.TextBox anchorFileTextBox;
        private System.Windows.Forms.GroupBox sourceGroupBox;
        private System.Windows.Forms.FolderBrowserDialog rootFolderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog anchorFileDialog;
        private System.Windows.Forms.Panel timeShiftPanel;
    }
}
