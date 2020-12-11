using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ModChanger
{

    
    public partial class Form2 : Form
    {
        string settings = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\Capcom\RE4\modswitcher.ini";
        string modPath;
        string[] GetFiles;
        public string gamePath;

        public Form2()
        {
            InitializeComponent();
            radioButton2.Checked = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        public void button1_Click(object sender, EventArgs e)
        {
            

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath;

                if (Directory.Exists(path + @"\Bin32") || Directory.Exists(path + @"\BIO4"))
                {
                    textBox1.Text = folderBrowserDialog1.SelectedPath;
                }
                else
                {
                    MessageBox.Show("No mod has been identified. Make sure that the mod folder contains the BIO4 and Bin32 folders within its directory.");
                }

            }
            
        }

        public void btnConfirm_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0)
            {
                MessageBox.Show("Please, choose the mod directory.", "Error", MessageBoxButtons.OK);
            }
            else if (textBox2.TextLength <= 5)
            {
                MessageBox.Show("The mod name needs to be at least 5 characters long.", "Error", MessageBoxButtons.OK);
            }
            else
            {
                modPath = textBox1.Text;
                
                int modLength = textBox1.Text.Length + 1;

                GetFiles = Directory.GetFiles(modPath, "*.*", SearchOption.AllDirectories);

                var writer = new StreamWriter(modPath + @"\files.txt", true);

                foreach (string filename in GetFiles)
                {
                    if (!filename.StartsWith("files.txt"))
                    {
                        writer.WriteLine("file=" + filename.Remove(0, modLength));
                    }
                }

                writer.Close();

                File.AppendAllText(settings, $"mod={textBox2.Text}|{textBox1.Text}\n");

                MessageBox.Show("The mod has been added!", "Success", MessageBoxButtons.OK);
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                comboBox1.Enabled = false;
                comboBox1.SelectedItem = null;
            }
            else
            {
                comboBox1.Enabled = true;
            }
        }
    }
}
