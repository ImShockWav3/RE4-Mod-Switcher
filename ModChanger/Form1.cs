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
                    "currentmod=Original",
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
                    currentMod = readSettings[2].Replace("currentmod=", "");

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
                    string changeMod = reader.ReadLine();
                    string[] split = changeMod.Split('|');

                    if (changeMod.StartsWith("mod="))
                    {
                        using (var reader2 = new StreamReader(split[1] + @"\files.txt"))
                        {
                            while (!reader2.EndOfStream)
                            {
                                string readFiles = reader2.ReadLine();
                                string File = readFiles.Replace("file=", "\\");
                                string[] folder = readFiles.Split('\\');
                                string gamePath = textBox1.Text;
                                bool checkModFile = System.IO.File.Exists(split[1] + File);
                                bool checkFile = System.IO.File.Exists(gamePath + File + ".bak");
                                bool checkLfsFile = System.IO.File.Exists(gamePath + File + ".lfs.bak");

                                if (readFiles.StartsWith("file=") && !readFiles.Contains("files.txt"))
                                {
                                    if (!System.IO.File.Exists(split[1] + File))
                                    {
                                        System.IO.File.Move(gamePath + File, split[1] + File);
                                    }

                                    if (checkFile)
                                    {
                                        System.IO.File.Move(gamePath + File + ".bak", gamePath + File);
                                    }

                                    else if (checkLfsFile)
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

            if (Switcher == true)
            {
                string[] readSettings = File.ReadAllLines(settings);
                readSettings[2] = "currentmod=" + selectedMod;
                File.WriteAllLines(settings, readSettings);
            }

            Switcher = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectedMod = Convert.ToString(comboBox1.Text);
            selectedDiff = Convert.ToString(comboBox2.Text);
            string[] readSettings = File.ReadAllLines(settings);
            currentMod = readSettings[2].Replace("currentmod=", "");

            if (selectedMod == "Original" && currentMod == "Original")
            {
                MessageBox.Show("The game has no mods installed.");
            }

            else if (selectedMod == "Original" && currentMod != "Original")
            {
                MessageBox.Show("Restoring...");
                Restore();
            }

            using (var reader = new StreamReader(settings))
            {
                while (!reader.EndOfStream)
                {
                    string changeMod = reader.ReadLine();
                    string[] split = changeMod.Split('|');

                    if (changeMod.StartsWith("mod=") && (comboBox1.Text == split[0].Replace("mod=","")))
                    {
                        if (selectedMod != currentMod)
                        {
                            if (currentMod != "Original")
                            {
                                Restore();
                            }

                            MessageBox.Show("Installing " + selectedMod + ". Directory is: " + split[1]);

                            using (var reader2 = new StreamReader(split[1] + @"\files.txt"))
                            {
                                while (!reader2.EndOfStream)
                                {
                                    
                                    string readFiles = reader2.ReadLine();
                                    string File = readFiles.Replace("file=", "\\");
                                    string[] folder = readFiles.Split('\\');
                                    string gamePath = textBox1.Text;
                                    bool checkModFile = System.IO.File.Exists(split[1] + File);
                                    bool checkFile = System.IO.File.Exists(gamePath + File);
                                    bool checkLfsFile = System.IO.File.Exists(gamePath + File + ".lfs");

                                    
                                    if (readFiles.StartsWith("file=") && !readFiles.Contains("files.txt"))
                                    {

                                        if (checkFile)
                                        {
                                            System.IO.File.Move(gamePath + File, gamePath + File + ".bak");
                                        }

                                        else if (checkLfsFile)
                                        {
                                            System.IO.File.Move(gamePath + File + ".lfs", gamePath + File + ".lfs.bak");
                                        }

                                        if (!System.IO.File.Exists(gamePath + File))
                                        {
                                            System.IO.File.Move(split[1] + File, gamePath + File);
                                        }

                                        Switcher = true;
                                        
                                    }
                                }

                                reader2.Close();
                            }
                        }   

                        else
                        {
                            MessageBox.Show(selectedMod + " is already installed.");
                        }
                    }
                }

                reader.Close();
            }

            if (Switcher == true)
            {
                readSettings[2] = "currentmod=" + selectedMod;
                File.WriteAllLines(settings, readSettings);
            }

            Switcher = false;
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
