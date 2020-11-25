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

        string selectedMod;
        string selectedDiff;
        string chosenPath;
        string currentMod;
        string bio4;

        public Form1()
        {
            InitializeComponent();
            string line = File.ReadLines(@"settings.cfg").Skip(1).Take(1).First();
            textBox1.Text = line.Replace("path=","");

            using (var reader = new System.IO.StreamReader(@"settings.cfg"))
            {
                while (!reader.EndOfStream)
                {
                    string newMod = reader.ReadLine();
                    string[] split = newMod.Split('|');

                    if (newMod.StartsWith("mod="))
                    {
                        comboBox1.Items.Add(split[0].Replace("mod=", ""));
                    }
                }

                reader.Close();
            }

            string currMod = File.ReadAllText(@"currentmod.ini");

            if (currMod.Length == 0 || (currMod.Contains("Original")))
            {
                comboBox1.SelectedItem = "Original";
            }
            else
            {
                comboBox1.SelectedItem = currMod;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectedMod = Convert.ToString(comboBox1.Text);
            selectedDiff = Convert.ToString(comboBox2.Text);
            currentMod = System.IO.File.ReadAllText(@"currentmod.ini");

            using (var reader = new System.IO.StreamReader(@"settings.cfg"))
            {
                while (!reader.EndOfStream)
                {
                    string changeMod = reader.ReadLine();
                    string[] split = changeMod.Split('|');

                    if (changeMod.StartsWith("mod=") && (comboBox1.Text == split[0].Replace("mod=","")))
                    {
                        if (selectedMod != currentMod)
                        {
                            MessageBox.Show("Installing " + selectedMod + ". Directory is: " + split[1]);


                            using (var reader2 = new System.IO.StreamReader(split[1] + @"\config.cfg"))
                            {
                                while (!reader2.EndOfStream)
                                {
                                    string readFiles = reader2.ReadLine();
                                    string File = readFiles.Replace("file=","\\");
                                    string[] folder = readFiles.Split('\\');
                                    string gamePath = textBox1.Text;

                                    bool checkModFile = System.IO.File.Exists(split[1] + File);
                                    bool checkGameFile = System.IO.File.Exists(gamePath + File);

                                    if (readFiles.StartsWith("file="))
                                    {
                                        if (checkModFile && checkGameFile)
                                        {
                                            System.IO.File.Move(gamePath+File, gamePath+File+".bak");
                                            // new System.IO.FileInfo(gamePath + File.Replace(folder.Last(), ""));
                                            // System.IO.Directory.CreateDirectory(gamePath + @"\Original" + File.Replace(folder.Last(), ""));
                                            // System.IO.File.Move(gamePath + File, gamePath + @"\Original" + File.Replace(folder.Last(), ""));
                                            // System.IO.File.Move(split[1] + File, gamePath);
                                        }
                                        else if ((checkModFile) || (!checkGameFile))
                                        {
                                            // System.IO.File.Move("","");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Not found.");
                                        }
                                    }
                                }

                                reader2.Close();
                            }

                            System.IO.File.WriteAllText(@"currentmod.ini", selectedMod);
                        }
                        else
                        {
                            MessageBox.Show(selectedMod + " is already installed.");
                        }
                        
                    }
                }

                reader.Close();
            }

            if (selectedMod == "Original" && currentMod != "Original")
            {
                Restore();
                System.IO.File.WriteAllText(@"currentmod.ini", "Original");
            }
            else if (selectedMod == "Original" && currentMod == "Original")
            {
                MessageBox.Show("The game has no mods installed already.");
            }
        }

        private void Restore()
        {
            MessageBox.Show("Restoring");

        }

        private void InstallMod()
        {
            // string check = System.IO.File.Exists();
        }


        private void button_browseFiles_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                
                chosenPath = folderBrowserDialog1.SelectedPath;
                bio4 = (chosenPath + @"\Bin32\bio4.exe");      

                if (System.IO.File.Exists(bio4))
                {
                    string[] lines = {
                    "[SETTINGS]",
                    "path="+chosenPath,
                    "",
                    "[MODS]",
                };
                    textBox1.Text = folderBrowserDialog1.SelectedPath;
                    System.IO.File.WriteAllLines(@"settings.cfg", lines);
                }
                else
                {
                    MessageBox.Show("bio4.exe was not found. Please try again!", "Error", MessageBoxButtons.OK);
                }
                
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Form2 addNewMod = new Form2(textBox1.Text);
            addNewMod.ShowDialog(this);
        }

        private void button_refreshModList_Click(object sender, EventArgs e)
        {
            using (var reader = new System.IO.StreamReader(@"settings.cfg"))
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
    }
}
