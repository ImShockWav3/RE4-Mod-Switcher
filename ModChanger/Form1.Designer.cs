
namespace ModChanger
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button_browseFiles = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Settings = new System.Windows.Forms.Button();
            this.Tip_Settings = new System.Windows.Forms.ToolTip(this.components);
            this.pBar1 = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.lblRunning = new System.Windows.Forms.Label();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btnShowLog = new System.Windows.Forms.Button();
            this.btnHideLog = new System.Windows.Forms.Button();
            this.btnCleanLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(329, 166);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Original"});
            this.comboBox1.Location = new System.Drawing.Point(136, 137);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(151, 23);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Enabled = false;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Normal",
            "Hard",
            "Very Hard",
            "Ultra Hard",
            "Ultra Hard +",
            "Impossible",
            "Impossible +"});
            this.comboBox2.Location = new System.Drawing.Point(136, 166);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(151, 23);
            this.comboBox2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select a mod:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(329, 136);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Manage mods";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_browseFiles
            // 
            this.button_browseFiles.Image = ((System.Drawing.Image)(resources.GetObject("button_browseFiles.Image")));
            this.button_browseFiles.Location = new System.Drawing.Point(427, 71);
            this.button_browseFiles.Name = "button_browseFiles";
            this.button_browseFiles.Size = new System.Drawing.Size(29, 23);
            this.button_browseFiles.TabIndex = 6;
            this.button_browseFiles.UseVisualStyleBackColor = true;
            this.button_browseFiles.Click += new System.EventHandler(this.button_browseFiles_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "RE4 Mod Changer by ShockWav3";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 73);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(410, 23);
            this.textBox1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Path currently in use:";
            // 
            // btn_Settings
            // 
            this.btn_Settings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Settings.BackgroundImage")));
            this.btn_Settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Settings.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_Settings.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btn_Settings.FlatAppearance.BorderSize = 0;
            this.btn_Settings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Settings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Settings.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Settings.Location = new System.Drawing.Point(434, 10);
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(22, 19);
            this.btn_Settings.TabIndex = 12;
            this.Tip_Settings.SetToolTip(this.btn_Settings, "Settings");
            this.btn_Settings.UseVisualStyleBackColor = true;
            this.btn_Settings.Click += new System.EventHandler(this.btn_Settings_Click);
            // 
            // pBar1
            // 
            this.pBar1.Location = new System.Drawing.Point(12, 224);
            this.pBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pBar1.Name = "pBar1";
            this.pBar1.Size = new System.Drawing.Size(441, 22);
            this.pBar1.Step = 5;
            this.pBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pBar1.TabIndex = 13;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 206);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(57, 15);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Waiting...";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "Select a soundtrack:";
            // 
            // lblRunning
            // 
            this.lblRunning.AutoSize = true;
            this.lblRunning.Location = new System.Drawing.Point(12, 206);
            this.lblRunning.Name = "lblRunning";
            this.lblRunning.Size = new System.Drawing.Size(344, 15);
            this.lblRunning.TabIndex = 16;
            this.lblRunning.Text = "Game is running. You won\'t be able to change mods or settings.";
            this.lblRunning.Visible = false;
            // 
            // rtbLog
            // 
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbLog.Location = new System.Drawing.Point(12, 309);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(442, 231);
            this.rtbLog.TabIndex = 17;
            this.rtbLog.Text = "";
            this.rtbLog.Visible = false;
            this.rtbLog.TextChanged += new System.EventHandler(this.rtbLog_TextChanged);
            // 
            // btnShowLog
            // 
            this.btnShowLog.Location = new System.Drawing.Point(329, 271);
            this.btnShowLog.Name = "btnShowLog";
            this.btnShowLog.Size = new System.Drawing.Size(125, 23);
            this.btnShowLog.TabIndex = 18;
            this.btnShowLog.TabStop = false;
            this.btnShowLog.Text = "Show error log";
            this.btnShowLog.UseVisualStyleBackColor = true;
            this.btnShowLog.Click += new System.EventHandler(this.btnShowLog_Click);
            // 
            // btnHideLog
            // 
            this.btnHideLog.Location = new System.Drawing.Point(329, 271);
            this.btnHideLog.Name = "btnHideLog";
            this.btnHideLog.Size = new System.Drawing.Size(125, 23);
            this.btnHideLog.TabIndex = 19;
            this.btnHideLog.TabStop = false;
            this.btnHideLog.Text = "Hide error log";
            this.btnHideLog.UseVisualStyleBackColor = true;
            this.btnHideLog.Visible = false;
            this.btnHideLog.Click += new System.EventHandler(this.btnHideLog_Click);
            // 
            // btnCleanLog
            // 
            this.btnCleanLog.Location = new System.Drawing.Point(234, 271);
            this.btnCleanLog.Name = "btnCleanLog";
            this.btnCleanLog.Size = new System.Drawing.Size(89, 23);
            this.btnCleanLog.TabIndex = 20;
            this.btnCleanLog.TabStop = false;
            this.btnCleanLog.Text = "Clear log";
            this.btnCleanLog.UseVisualStyleBackColor = true;
            this.btnCleanLog.Visible = false;
            this.btnCleanLog.Click += new System.EventHandler(this.btnCleanLog_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 309);
            this.Controls.Add(this.btnCleanLog);
            this.Controls.Add(this.btnHideLog);
            this.Controls.Add(this.btnShowLog);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.lblRunning);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pBar1);
            this.Controls.Add(this.btn_Settings);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_browseFiles);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RE4 Mod Changer";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_browseFiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Settings;
        private System.Windows.Forms.ToolTip Tip_Settings;
        private System.Windows.Forms.ProgressBar pBar1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblRunning;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Button btnShowLog;
        private System.Windows.Forms.Button btnHideLog;
        private System.Windows.Forms.Button btnCleanLog;
    }
}

