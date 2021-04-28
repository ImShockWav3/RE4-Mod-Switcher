using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ModChanger
{

    public partial class Form1 : Form
    {
        string settings = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\Capcom\RE4\modswitcher.ini";
        string selectedMod;
        string currentMod;

        public Form1()
        {
            InitializeComponent();
            btn_Settings.MouseEnter += new EventHandler(btn_Settings_MouseEnter);
            btn_Settings.MouseLeave += new EventHandler(btn_Settings_MouseLeave);

            if (!File.Exists(settings))
            {
                string[] lines = {
                    "[SETTINGS]",
                    "path=",
                    "curr=Original",
                    "",
                    "[MODS]"
                };

                File.WriteAllLines(settings, lines);
            } 

            using (var reader = new StreamReader(settings))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] split = line.Split('|');
                    string[] readSettings = File.ReadAllLines(settings);
                    currentMod = readSettings[2].Replace("curr=", "");

                    if (line.StartsWith("path="))
                    {
                        if (line.Length < 6)
                        {
                            textBox1.Text = "Please browse to your game folder.";
                            button1.Enabled = false;
                            break;
                        }

                        textBox1.Text = line.Replace("path=", "");
                    }

                    if (line.StartsWith("mod="))
                    {
                        comboBox1.Items.Add(split[0].Replace("mod=", ""));
                    }
                }

                reader.Close();
            }

            if (currentMod.Length == 0 || currentMod.Contains("Original"))
            {
                comboBox1.SelectedItem = "Original";
            }
            else
            {
                comboBox1.SelectedItem = currentMod;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Restore()
        {
            string[] Settings = File.ReadAllLines(settings);
            string currentMod = Settings[2].Replace("curr=", "");
            int modLine = GetLineNumber(settings, $"mod={currentMod}");

            string gamePath = Settings[1].ToString().Split('=')[1];
            string modPath = Settings[modLine].ToString().Split('|')[1];
            string[] files = File.ReadAllLines(modPath + "\\files.txt");

            pBar1.Value = 0;
            pBar1.Maximum = files.Length;

            if (Directory.Exists(gamePath + "\\FILES"))
            {
                Directory.Move(gamePath + "\\FILES", modPath + "\\FILES");
            }

            foreach (string f in files)
            {
                string file = f.Replace("file=", "\\");

                try
                {
                    if (!File.Exists(modPath + file) && File.Exists(gamePath + file))
                    {
                        File.Move(gamePath + file, modPath + file);
                    }

                    if (File.Exists(gamePath + file + ".bak"))
                    {
                        File.Move(gamePath + file + ".bak", gamePath + file);
                    }

                    if (File.Exists(gamePath + file + ".lfs.bak"))
                    {
                        File.Move(gamePath + file + ".lfs.bak", gamePath + file + ".lfs");
                    }
                }
                catch (IOException e)
                {
                    AppendRichText(rtbLog, "(ERROR) ", Color.Red);
                    AppendRichText(rtbLog, $"{e.Message.Remove(e.Message.Length - 1)}: \"{file.Substring(1)}\"\n", Color.Black);
                }

                pBar1.PerformStep();
            }
        }

        private void Install()
        {
            string[] Settings = File.ReadAllLines(settings);
            string selectedMod = Convert.ToString(comboBox1.Text);
            int modLine = GetLineNumber(settings, $"mod={selectedMod}");

            string gamePath = Settings[1].ToString().Split('=')[1];
            string modPath = Settings[modLine].ToString().Split('|')[1];
            string[] files = File.ReadAllLines(modPath + "\\files.txt");

            pBar1.Value = 0;
            pBar1.Maximum = files.Length;

            if (Directory.Exists(modPath + "\\FILES"))
            {
                Directory.Move(modPath + "\\FILES", gamePath + "\\FILES");
            }

            foreach (string f in files)
            {
                string file = f.Replace("file=", "\\");

                if (!Directory.Exists(gamePath + file))
                {
                    new FileInfo(gamePath + file).Directory.Create();
                }

                try
                {
                    if (File.Exists(gamePath + file))
                    {
                        File.Move(gamePath + file, gamePath + file + ".bak");
                    }

                    if (File.Exists(gamePath + file + ".lfs"))
                    {
                        File.Move(gamePath + file + ".lfs", gamePath + file + ".lfs.bak");
                    }

                    if (File.Exists(modPath + file) && !File.Exists(gamePath + file))
                    {
                        File.Move(modPath + file, gamePath + file);
                    }
                }
                catch (IOException e)
                {
                    AppendRichText(rtbLog, "(ERROR) ", Color.Red);
                    AppendRichText(rtbLog, $"{e.Message.Remove(e.Message.Length - 1)}: \"{file.Substring(1)}\"\n", Color.Black);
                }

                pBar1.PerformStep();
                
                if (pBar1.Value == pBar1.Maximum)
                {
                    lblStatus.Text = $"{selectedMod} has been installed.";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] Settings = File.ReadAllLines(settings);
            currentMod = Settings[2].Replace("curr=", "");
            selectedMod = Convert.ToString(comboBox1.Text);

            if (selectedMod == "Original" && currentMod == "Original")
            {
                MessageBox.Show("The game has no mods installed.");
            }

            else if (selectedMod == "Original" && currentMod != "Original")
            {
                Restore();
                if (pBar1.Value == pBar1.Maximum)
                {
                    lblStatus.Text = "The game has been restored to default.";
                    AppendRichText(rtbLog, "The game has been restored to default.\n", Color.Green);
                }

                Settings[2] = "curr=Original";
                File.WriteAllLines(settings, Settings);
            }

            else
            {
                if (selectedMod != currentMod)
                {
                    if (currentMod != "Original")
                    {
                        Restore();
                    }

                    Install();
                    AppendRichText(rtbLog, $"{selectedMod} ", Color.Blue);
                    AppendRichText(rtbLog, "has been installed!\n", Color.Black);

                    Settings[2] = $"curr={selectedMod}";
                    File.WriteAllLines(settings, Settings);
                }

                else
                {
                    MessageBox.Show($"{selectedMod} is already installed.");
                }
            }
        }


        private void button_browseFiles_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string chosenPath = folderBrowserDialog1.SelectedPath;
                string[] readSettings = File.ReadAllLines(settings);
                readSettings[1] = "path=" + chosenPath;

                if (File.Exists(chosenPath + @"\Bin32\bio4.exe"))
                {
                    textBox1.Text = chosenPath;
                    button1.Enabled = true;
                    File.WriteAllLines(settings, readSettings);
                }
                else
                {
                    MessageBox.Show("bio4.exe was not found. Please try again!", "Error", MessageBoxButtons.OK);
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string[] readSettings = File.ReadAllLines(settings);

            if (readSettings[1].Length < 6)
            {
                MessageBox.Show("Please set your game path before adding mods.");
            }

            else
            {
                Form3 manageMods = new Form3();
                manageMods.ShowDialog();
            }
        }

        private void button_refreshModList_Click(object sender, EventArgs e)
        {
            using (var reader = new StreamReader(settings))
            {
                while (!reader.EndOfStream)
                {
                    string list = reader.ReadLine();
                    string mod = list.Split('|')[0];

                    if (list.StartsWith("mod="))
                    {
                        if (!comboBox1.Items.Contains(mod.Replace("mod=", "")))
                        {
                            comboBox1.Items.Add(mod.Replace("mod=", ""));
                        }
                    }
                }

                reader.Close();
            }
        }

        private int GetLineNumber(string file, string contains)
        {
            string[] line = File.ReadAllLines(file);
            int totalLines = File.ReadAllLines(file).Count();
            int lineNumber = 0;

            while (lineNumber < totalLines)
            {
                lineNumber++;
                if (line[lineNumber].Contains(contains)) { break; }
            }

            return lineNumber;
        }

        private void AppendRichText(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        public void wait(int milliseconds)
        {
            var timer2 = new Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            timer2.Interval = milliseconds;
            timer2.Enabled = true;
            timer2.Start();

            timer2.Tick += (s, e) =>
            {
                timer2.Enabled = false;
                timer2.Stop();
            };

            while (timer2.Enabled)
            {
                Application.DoEvents();
            }
        }

        void btn_Settings_MouseLeave(object sender, EventArgs e)
        {
            btn_Settings.BackgroundImage = Properties.Resources.settings;
        }


        void btn_Settings_MouseEnter(object sender, EventArgs e)
        {
            btn_Settings.BackgroundImage = Properties.Resources.settings2;
        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("bio4").Length > 0)
            {
                lblRunning.Visible = true;
                lblStatus.Visible = false;
                button1.Enabled = false;
                btn_Settings.Enabled = false;
            }
            else
            {
                lblRunning.Visible = false;
                lblStatus.Visible = true;
                button1.Enabled = true;
                btn_Settings.Enabled = true;
            }
        }

        private void RefreshList()
        {
            using (var reader = new StreamReader(settings))
            {

                while (!reader.EndOfStream)
                {
                    string list = reader.ReadLine();
                    string mod = list.Split('|')[0];

                    if (list.StartsWith("mod=") && !comboBox1.Items.Contains(mod.Replace("mod=", "")))
                    {
                        comboBox1.Items.Add(mod.Replace("mod=", ""));
                    }
                }

                reader.Close();
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            string currentMod = File.ReadAllLines(settings)[2].Replace("curr=", "");

            comboBox1.Items.Clear();
            comboBox1.Items.Add("Original");
            RefreshList();
            comboBox1.SelectedItem = currentMod;
        }

        private void btnShowLog_Click(object sender, EventArgs e)
        {
            Height = 590;
            btnShowLog.Visible = false;
            rtbLog.Visible = true;
            btnHideLog.Visible = true;
            btnCleanLog.Visible = true;
        }

        private void btnHideLog_Click(object sender, EventArgs e)
        {
            Height = 348;
            btnShowLog.Visible = true;
            rtbLog.Visible = false;
            btnHideLog.Visible = false;
            btnCleanLog.Visible = false;
        }

        private void btnCleanLog_Click(object sender, EventArgs e)
        {
            rtbLog.Clear();
        }

        private void rtbLog_TextChanged(object sender, EventArgs e)
        {
            rtbLog.ScrollToCaret();
        }
    }
}
