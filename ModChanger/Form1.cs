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


namespace ModChanger
{

    public partial class Form1 : Form
    {
        string settings = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\Capcom\RE4\modswitcher.ini";
        string selectedMod;
        string selectedDiff;
        string currentMod;
        bool Switcher = false;

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
            selectedMod = Convert.ToString(comboBox1.Text);
            selectedDiff = Convert.ToString(comboBox2.Text);

            using (var reader = new StreamReader(settings))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] split = line.Split('|');
                    string[] readSettings = File.ReadAllLines(settings);
                    currentMod = readSettings[2].Replace("curr=", "");

                    if (line.StartsWith($"mod={currentMod}"))
                    {
                        using (var reader2 = new StreamReader(split[1] + @"\files.txt"))
                        {
                            while (!reader2.EndOfStream)
                            {
                                string readFiles = reader2.ReadLine();
                                string File = readFiles.Replace("file=", "\\");
                                //string[] folder = readFiles.Split('\\');
                                string gamePath = textBox1.Text;
                                bool checkModFile = System.IO.File.Exists(split[1] + File);
                                bool checkFile = System.IO.File.Exists(gamePath + File + ".bak");
                                bool checkLfsFile = System.IO.File.Exists(gamePath + File + ".lfs.bak");

                                if (!readFiles.Contains("files.txt"))
                                {
                                    System.IO.File.Move(gamePath + File, split[1] + File);

                                    if (checkFile)
                                    {
                                        System.IO.File.Move(gamePath + File + ".bak", gamePath + File);
                                    }

                                    if (checkLfsFile)
                                    {
                                        System.IO.File.Move(gamePath + File + ".lfs.bak", gamePath + File + ".lfs");
                                    }

                                    Switcher = true;
                                }
                            }

                            reader2.Close();
                        }
                    }
                }

                reader.Close();
            }

            //if (Switcher == true)
            //{
            //string[] readSettings = File.ReadAllLines(settings);
            //readSettings[2] = "curr=" + selectedMod;
            //File.WriteAllLines(settings, readSettings);
            //}

            //Switcher = false;
        }

        private void RestoreTest()
        {
            string[] Settings = File.ReadAllLines(settings);
            string currentMod = Settings[2].Replace("curr=", "");
            int modLine = GetLineNumber(settings, $"mod={currentMod}");

            string gamePath = Settings[1].ToString().Split('=')[1];
            string modPath = Settings[modLine].ToString().Split('|')[1];

            using (var r = new StreamReader(modPath + "\\files.txt"))
            {
                while (!r.EndOfStream)
                {
                    string line = r.ReadLine();
                    string file = line.Replace("file=", "\\");
                    bool checkFile = File.Exists(gamePath + file + ".bak");
                    bool checkLfsFile = File.Exists(gamePath + file + ".lfs.bak");

                    if (!File.Exists(modPath + file))
                    {
                        File.Move(gamePath + file, modPath + file);
                    }

                    if (checkFile)
                    {
                        File.Move(gamePath + file + ".bak", gamePath + file);
                    }

                    if (checkLfsFile)
                    {
                        File.Move(gamePath + file + ".lfs.bak", gamePath + file + ".lfs");
                    }
                }

                r.Close();
            }
        }

        private void installTest()
        {
            
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
                RestoreTest();
                MessageBox.Show("Restoring...");
                Settings[2] = "curr=Original";
                File.WriteAllLines(settings, Settings);
            }

            else
            {
                if (selectedMod != currentMod)
                {
                    int modLine = GetLineNumber(settings, $"mod={selectedMod}");
                    string gamePath = Settings[1].ToString().Split('=')[1];
                    string modPath = Settings[modLine].ToString().Split('|')[1];

                    using (var r = new StreamReader(modPath + "\\files.txt"))
                    {
                        while (!r.EndOfStream)
                        {
                            string line = r.ReadLine();
                            string file = line.Replace("file=", "\\");
                            bool checkFile = File.Exists(gamePath + file) && !File.Exists(gamePath + file + ".bak");
                            bool checkLfsFile = File.Exists(gamePath + file + ".lfs") && !File.Exists(gamePath + file + ".lfs.bak");

                            if (currentMod != "Original")
                            {
                                RestoreTest();
                                wait(3000);
                            }

                            if (checkFile)
                            {
                                File.Move(gamePath + file, gamePath + file + ".bak");
                            }

                            if (checkLfsFile)
                            {
                                File.Move(gamePath + file + ".lfs", gamePath + file + ".lfs.bak");
                            }

                            if (File.Exists(modPath + file) && !File.Exists(gamePath + file))
                            {
                                File.Move(modPath + file, gamePath + file);
                            }

                            Switcher = true;
                        }

                        r.Close();
                    }
                }

                else
                {
                    MessageBox.Show($"{selectedMod} is already installed.");
                }

                if (Switcher == true)
                {
                    Settings[2] = "curr=" + selectedMod;
                    File.WriteAllLines(settings, Settings);
                }

                Switcher = false;
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
                    string newMod = reader.ReadLine();
                    string[] split = newMod.Split('|');

                    if (newMod.StartsWith("mod="))
                    {
                        if (!comboBox1.Items.Contains(split[0].Replace("mod=", "")))
                        {
                            comboBox1.Items.Add(split[0].Replace("mod=", ""));
                        }
                    }
                }

                reader.Close();
            }
        }

        private int GetLineNumber(string file, string contains)
        {
            string[] readSettings = File.ReadAllLines(file);
            int totalLines = File.ReadAllLines(file).Count();
            int lineNumber = 0;

            while (lineNumber <= totalLines)
            {
                lineNumber++;
                if (readSettings[lineNumber].Contains(contains))
                {
                    break;
                }
            }

            return lineNumber;
        }

        public void wait(int milliseconds)
        {
            var timer2 = new System.Windows.Forms.Timer();
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
    }
}
