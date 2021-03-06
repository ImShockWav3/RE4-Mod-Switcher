﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace ModChanger
{
    public partial class Form3 : Form
    {
        string settings = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\Capcom\RE4\modswitcher.ini";

        public Form3()
        {
            InitializeComponent();
            RefreshList();
        }

        private void modList_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var reader = new StreamReader(settings))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] split = line.Split('|');

                    if (line.StartsWith("mod=") && (Convert.ToString(modList.SelectedItem) == split[0].Replace("mod=", "")))
                    {
                        txtName.Text = split[0].Replace("mod=", "");
                        txtPath.Text = split[1];
                    }
                }

                reader.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 addNewMod = new Form2();
            addNewMod.ShowDialog();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string[] Settings = File.ReadAllLines(settings);
            string selectedMod = Convert.ToString(modList.SelectedItem);
            string currentMod = Settings[2].Replace("curr=", "");

            if (txtName.Text.Length < 5)
            {
                MessageBox.Show("The mod name needs to be at least 5 characters long.", "Error", MessageBoxButtons.OK);
            }

            else if (txtPath.Text.Length == 0)
            {
                MessageBox.Show("Please, choose the mod directory.", "Error", MessageBoxButtons.OK);
            }

            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to overwrite the current settings?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (selectedMod == currentMod)
                    {
                        Settings[2] = $"curr={txtName.Text}";
                    }

                    int line = GetLineNumber(settings, $"mod={selectedMod}");

                    Settings[line] = $"mod={txtName.Text}|{txtPath.Text}";
                    File.WriteAllLines(settings, Settings);

                    txtName.Clear();
                    txtPath.Clear();

                    modList.Items.Clear();
                    RefreshList();
                }
            }

            
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string[] Settings = File.ReadAllLines(settings);
            string currentMod = Settings[2].Replace("curr=", "");
            string selectedMod = modList.SelectedItem.ToString();

            int modLine = GetLineNumber(settings, $"mod={selectedMod}");
            string filesTXT = Settings[modLine].Split('|')[1] + "\\files.txt";

            if (modList.SelectedItem != null)
            {
                if (selectedMod != currentMod)
                {
                    var result = MessageBox.Show(
                        $"Are you sure you want to delete \"{selectedMod}\"?", "Are you sure?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        if (File.Exists(filesTXT)) { File.Delete(filesTXT); }

                        RemoveLine(settings, $"mod={selectedMod}");

                        txtName.Text = "";
                        txtPath.Text = "";
                        modList.Items.Clear();

                        RefreshList();
                    }
                }
                else
                {
                    MessageBox.Show($"You can not delete \"{selectedMod}\" because it is currently in use.");
                }
            }
            else
            {
                MessageBox.Show("Please select a mod to be deleted.");
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

        private void RefreshList()
        {
            using (var reader = new StreamReader(settings))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] split = line.Split('|');

                    if (line.StartsWith("mod=") && !modList.Items.Contains(split[0].Replace("mod=", "")))
                    {
                        modList.Items.Add(split[0].Replace("mod=", ""));
                    }
                }

                reader.Close();
            }
        }

        private void RemoveLine(string filePath, string content)
        {
            using (var writer = new StreamWriter(filePath + ".temp.txt"))
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (!line.Contains(content))
                    {
                        writer.WriteLine(line);
                    }
                }
            }

            File.Delete(filePath);
            File.Move(filePath + ".temp.txt", filePath);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (modList.SelectedItem == null)
            {
                btn_Delete.Enabled = false;
                btn_Save.Enabled = false;
            }
            else
            {
                btn_Delete.Enabled = true;
                btn_Save.Enabled = true;
            }

            RefreshList();
        }
    }
}
