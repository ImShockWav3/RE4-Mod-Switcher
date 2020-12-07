using System;
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

        public Form3()
        {
            InitializeComponent();
            RefreshList();
        }

        private void modList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modList.SelectedItem != null) { btn_Save.Enabled = true; }

            using (var reader = new StreamReader(@"settings.cfg"))
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

        private void btn_Refresh_Click(object sender, EventArgs e) => RefreshList();

        private void btn_Save_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to overwrite the current settings?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string indexedMod = Convert.ToString(modList.SelectedItem);
                int line = GetLineNumber(@"settings.cfg", $"mod={indexedMod}");

                string[] readSettings = File.ReadAllLines(@"settings.cfg");
                readSettings[line] = $"mod={txtName.Text}|{txtPath.Text}";
                File.WriteAllLines(@"settings.cfg", readSettings);

                btn_Save.Enabled = false;
                txtName.Text = "";
                txtPath.Text = "";

                modList.Items.Clear();
                RefreshList();
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

        private void RefreshList()
        {
            using (var reader = new StreamReader(@"settings.cfg"))
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

    }
}
