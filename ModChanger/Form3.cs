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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            using (var reader = new StreamReader(@"settings.cfg"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] split = line.Split('|');
                    string[] readSettings = File.ReadAllLines(@"settings.cfg");
                    //currentMod = readSettings[2].Replace("currentmod=", "");

                    if (line.StartsWith("mod="))
                    {
                        modList.Items.Add(split[0].Replace("mod=", ""));
                    }
                }

                reader.Close();
            }
        }

        private void modList_SelectedIndexChanged(object sender, EventArgs e)
        {
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


    }
}
