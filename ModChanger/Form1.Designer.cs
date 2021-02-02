
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.button_refreshModList = new System.Windows.Forms.Button();
            this.btn_Settings = new System.Windows.Forms.Button();
            this.Tip_Settings = new System.Windows.Forms.ToolTip(this.components);
            this.pBar1 = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(193, 220);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 31);
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
            this.comboBox1.Location = new System.Drawing.Point(14, 181);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(172, 28);
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
            this.comboBox2.Location = new System.Drawing.Point(14, 220);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(172, 28);
            this.comboBox2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select a mod:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(347, 220);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(171, 31);
            this.button2.TabIndex = 5;
            this.button2.Text = "Manage mods";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_browseFiles
            // 
            this.button_browseFiles.Location = new System.Drawing.Point(347, 181);
            this.button_browseFiles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_browseFiles.Name = "button_browseFiles";
            this.button_browseFiles.Size = new System.Drawing.Size(171, 31);
            this.button_browseFiles.TabIndex = 6;
            this.button_browseFiles.Text = "Browse folder";
            this.button_browseFiles.UseVisualStyleBackColor = true;
            this.button_browseFiles.Click += new System.EventHandler(this.button_browseFiles_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "RE4 Mod Changer by ShockWav3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "(v1.0.0)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(14, 88);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(505, 27);
            this.textBox1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Path currently in use:";
            // 
            // button_refreshModList
            // 
            this.button_refreshModList.Location = new System.Drawing.Point(193, 181);
            this.button_refreshModList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_refreshModList.Name = "button_refreshModList";
            this.button_refreshModList.Size = new System.Drawing.Size(90, 32);
            this.button_refreshModList.TabIndex = 11;
            this.button_refreshModList.Text = "Refresh list";
            this.button_refreshModList.UseVisualStyleBackColor = true;
            this.button_refreshModList.Click += new System.EventHandler(this.button_refreshModList_Click);
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
            this.btn_Settings.Location = new System.Drawing.Point(496, 13);
            this.btn_Settings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(25, 25);
            this.btn_Settings.TabIndex = 12;
            this.Tip_Settings.SetToolTip(this.btn_Settings, "Settings");
            this.btn_Settings.UseVisualStyleBackColor = true;
            this.btn_Settings.Click += new System.EventHandler(this.btn_Settings_Click);
            // 
            // pBar1
            // 
            this.pBar1.Location = new System.Drawing.Point(14, 293);
            this.pBar1.Name = "pBar1";
            this.pBar1.Size = new System.Drawing.Size(504, 29);
            this.pBar1.Step = 3;
            this.pBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pBar1.TabIndex = 13;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(14, 270);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(69, 20);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Waiting...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 339);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pBar1);
            this.Controls.Add(this.btn_Settings);
            this.Controls.Add(this.button_refreshModList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_browseFiles);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RE4 Mod Changer";
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_refreshModList;
        private System.Windows.Forms.Button btn_Settings;
        private System.Windows.Forms.ToolTip Tip_Settings;
        private System.Windows.Forms.ProgressBar pBar1;
        private System.Windows.Forms.Label lblStatus;
    }
}

