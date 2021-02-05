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
    public partial class Form4 : Form
    {

        string configPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\Capcom\RE4\config.ini";

        public Form4()
        {
            InitializeComponent();

            AppendRichText(richTextBox1, "This software was made by ", Color.Black);
            AppendRichText(richTextBox1, "ShockWav3.\n\n", Color.Red);
            AppendRichText(richTextBox1, "Please consider subscribing to my ", Color.Black);
            AppendRichText(richTextBox1, "YouTube ", Color.Red);
            AppendRichText(richTextBox1, "channel and following me on ", Color.Black);
            AppendRichText(richTextBox1, "Twitch", Color.Purple);
            AppendRichText(richTextBox1, ":\nhttps://youtube.com/ShockWav3\nhttps://twitch.tv/ImShockWav3\n\n", Color.Black);
            AppendRichText(richTextBox1, "This is an early version, so expect bugs. If you experience one, report it to me on my Discord:\n\nShockWav3#5041", Color.Black);

            using (var sr = new StreamReader(configPath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] split = line.Split(' ');
                    int opt = Convert.ToInt32(split[1]);

                    bool check;

                    if (line.StartsWith("resolution"))
                    {
                        int resWidth = Convert.ToInt32(split[1]);
                        int resHeight = Convert.ToInt32(split[2]);
                        int hertz = Convert.ToInt32(split[3]);

                        if (resWidth == 1280 && resHeight == 720)
                        {
                            cb_ResolutionPresets.SelectedItem = "HD (720p)";
                            txt_resWidth.Text = resWidth.ToString();
                            txt_resHeight.Text = resHeight.ToString();
                            txt_hertz.Text = hertz.ToString();
                        }

                        else if (resWidth == 1920 && resHeight == 1080)
                        {
                            cb_ResolutionPresets.SelectedItem = "Full-HD (1080p)";
                            txt_resWidth.Text = resWidth.ToString();
                            txt_resHeight.Text = resHeight.ToString();
                            txt_hertz.Text = hertz.ToString();
                        }

                        else if (resWidth == 2560 && resHeight == 1440)
                        {
                            cb_ResolutionPresets.SelectedItem = "Quad-HD (1440p)";
                            txt_resWidth.Text = resWidth.ToString();
                            txt_resHeight.Text = resHeight.ToString();
                            txt_hertz.Text = hertz.ToString();
                        }

                        else if (resWidth == 3840 && resHeight == 2160)
                        {
                            cb_ResolutionPresets.SelectedItem = "Ultra-HD (2160p)";
                            txt_resWidth.Text = resWidth.ToString();
                            txt_resHeight.Text = resHeight.ToString();
                            txt_hertz.Text = hertz.ToString();
                        }

                        else
                        {
                            cb_ResolutionPresets.SelectedItem = "Custom";
                            txt_resWidth.Text = resWidth.ToString();
                            txt_resHeight.Text = resHeight.ToString();
                            txt_hertz.Text = hertz.ToString();
                        }
                    }

                    if (line.StartsWith("vsync"))
                    {
                        check = split[1].Contains('1') ? chk_EnableVSync.Checked = true : chk_EnableVSync.Checked = false;
                    }

                    if (line.StartsWith("fullscreen"))
                    {
                        check = split[1].Contains('1') ? chk_EnableFullscreen.Checked = true : chk_EnableFullscreen.Checked = false;
                    }

                    if (line.StartsWith("antialiasing"))
                    {
                        switch (opt)
                        {
                            case 0:
                                cb_AntiAliasing.SelectedItem = "Off";
                                break;

                            case 2:
                                cb_AntiAliasing.SelectedItem = "2X";
                                break;

                            case 4:
                                cb_AntiAliasing.SelectedItem = "4X";
                                break;

                            case 8:
                                cb_AntiAliasing.SelectedItem = "8X";
                                break;

                            default:
                                cb_AntiAliasing.SelectedItem = "Off";
                                break;
                        }

                    }

                    if (line.StartsWith("anisotropy"))
                    {
                        switch (opt)
                        {
                            case 0:
                                cb_Anisotropy.SelectedItem = "Off";
                                break;

                            case 2:
                                cb_Anisotropy.SelectedItem = "2X";
                                break;

                            case 4:
                                cb_Anisotropy.SelectedItem = "4X";
                                break;

                            case 8:
                                cb_Anisotropy.SelectedItem = "8X";
                                break;

                            case 16:
                                cb_Anisotropy.SelectedItem = "16X";
                                break;

                            default:
                                cb_Anisotropy.SelectedItem = "Off";
                                break;
                        }

                    }

                    if (line.StartsWith("shadowQuality"))
                    {
                        switch (opt)
                        {
                            case 0:
                                cb_ShadowQuality.SelectedItem = "Low";
                                break;

                            case 1:
                                cb_ShadowQuality.SelectedItem = "Medium";
                                break;

                            case 2:
                                cb_ShadowQuality.SelectedItem = "High";
                                break;

                            default:
                                cb_ShadowQuality.SelectedItem = "Medium";
                                break;
                        }
                    }

                    if (line.StartsWith("useHDTexture"))
                    {
                        switch (opt)
                        {
                            case 0:
                                rb_Texture_Original.Checked = true;
                                break;

                            case 1:
                                rb_Texture_HD.Checked = true;
                                break;

                            default:
                                rb_Texture_HD.Checked = true;
                                break;
                        }
                    }

                    if (line.StartsWith("ppEnabled"))
                    {
                        check = split[1].Contains('1') ? chk_EnablePostProcessing.Checked = true : chk_EnablePostProcessing.Checked = false;
                    }

                    if (line.StartsWith("motionblurEnabled"))
                    {
                        check = split[1].Contains('1') ? chk_EnableMotionBlur.Checked = true : chk_EnableMotionBlur.Checked = false;
                    }

                    if (line.StartsWith("variableframerate"))
                    {
                        switch (opt)
                        {
                            case 0:
                                rb_FPSoff.Checked = true;
                                break;

                            case 30:
                                rb_FPS30.Checked = true;
                                break;

                            case 60:
                                rb_FPS60.Checked = true;
                                break;

                            default:
                                rb_FPS60.Checked = true;
                                break;
                        }
                    }

                    if (line.StartsWith("subtitle"))
                    {
                        switch (opt)
                        {
                            case 0:
                                chk_EnableSubtitles.Checked = false;
                                break;

                            case 1:
                                chk_EnableSubtitles.Checked = true;
                                break;

                            default:
                                rb_FPS60.Checked = true;
                                break;
                        }
                    }

                    if (line.Contains("laserA 255"))
                    {
                        chk_EnableLaser.Checked = true;
                    }
                    else
                    {
                        chk_EnableLaser.Checked = false;
                    }

                    if (line.StartsWith("laserR"))
                    {
                        trackBar1.Value = opt;
                        lbl_num_red.Text = opt.ToString();
                    }

                    if (line.StartsWith("laserG"))
                    {
                        trackBar2.Value = opt;
                        lbl_num_green.Text = opt.ToString();
                    }

                    if (line.StartsWith("laserB"))
                    {
                        trackBar3.Value = opt;
                        lbl_num_blue.Text = opt.ToString();
                    }

                    UpdateColor();
                }

                sr.Close();
            }


        }


        private void AppendRichText(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        private void btn_SaveSettings_Click(object sender, EventArgs e)
        {
            char vsync;
            char fullscreen;
            string antialiasing;
            string anisotropy;
            char shadowquality;
            char texture;
            int fps;
            char pp;
            char motionblur;
            char subtitle;

            if (chk_EnableVSync.Checked) { vsync = '1'; } else { vsync = '0'; }
            if (chk_EnableFullscreen.Checked) { fullscreen = '1'; } else { fullscreen = '0'; }

            if (cb_AntiAliasing.SelectedItem.ToString() == "Off")
            {
                antialiasing = "0";
            }
            else
            {
                antialiasing = Convert.ToString(cb_AntiAliasing.SelectedItem).Replace("X", "");
            }

            if (cb_Anisotropy.SelectedItem.ToString() == "Off")
            {
                anisotropy = "0";
            }
            else
            {
                anisotropy = Convert.ToString(cb_Anisotropy.SelectedItem).Replace("X", "");
            }

            if (cb_ShadowQuality.SelectedItem.ToString() == "Low")
            {
                shadowquality = '0';
            }
            else if (cb_ShadowQuality.SelectedItem.ToString() == "Medium")
            {
                shadowquality = '1';
            }
            else
            {
                shadowquality = '2';
            }

            if (rb_Texture_Original.Checked)
            {
                texture = '0';
            }
            else
            {
                texture = '1';
            }

            if (chk_EnablePostProcessing.Checked) { pp = '1'; } else { pp = '0'; }
            if (chk_EnableMotionBlur.Checked) { motionblur = '1'; } else { motionblur = '0'; }
            if (chk_EnableSubtitles.Checked) { subtitle = '1'; } else { subtitle = '0'; }


            if (rb_FPSoff.Checked)
            {
                fps = 0;
            }
            else if (rb_FPS30.Checked)
            {
                fps = 30;
            }
            else
            {
                fps = 60;
            }



            string[] Config = File.ReadAllLines(configPath);
            Config[0] = $"resolution {txt_resWidth.Text} {txt_resHeight.Text} {txt_hertz.Text}";
            Config[1] = $"vsync {vsync}";
            Config[2] = $"fullscreen {fullscreen}";
            Config[4] = $"antialiasing {antialiasing}";
            Config[5] = $"anisotropy {anisotropy}";
            Config[6] = $"shadowQuality {shadowquality}";
            Config[7] = $"useHDTexture {texture}";
            Config[8] = $"ppEnabled {pp}";
            Config[9] = $"motionblurEnabled {motionblur}";
            Config[10] = $"variableframerate {fps}";
            Config[11] = $"subtitle {subtitle}";



            if (chk_EnableLaser.Checked)
            {
                Config[12] = $"laserR {trackBar1.Value}";
                Config[13] = $"laserG {trackBar2.Value}";
                Config[14] = $"laserB {trackBar3.Value}";
                Config[15] = $"laserA 255";
            }
            else
            {
                Config[12] = $"laserR 255";
                Config[13] = $"laserG 0";
                Config[14] = $"laserB 0";
                Config[15] = $"laserA -1";
            }

            var result = MessageBox.Show("Are you sure you want to overwrite the current settings?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                File.WriteAllLines(configPath, Config);
                MessageBox.Show("Settings saved.");
                Close();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lbl_num_red.Text = trackBar1.Value.ToString();
            UpdateColor();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            lbl_num_green.Text = trackBar2.Value.ToString();
            UpdateColor();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            lbl_num_blue.Text = trackBar3.Value.ToString();
            UpdateColor();
        }

        private void UpdateColor()
        {
            int r = trackBar1.Value;
            int g = trackBar2.Value;
            int b = trackBar3.Value;
            btn_rgbpicker.BackColor = Color.FromArgb(r, g, b);
        }

        private void btn_rgbpicker_Click(object sender, EventArgs e)
        {
            ColorDialog laserColor = new ColorDialog();

            if (laserColor.ShowDialog() == DialogResult.OK)
            {
                int red = laserColor.Color.R;
                int green = laserColor.Color.G;
                int blue = laserColor.Color.B;

                trackBar1.Value = red;
                trackBar2.Value = green;
                trackBar3.Value = blue;

                lbl_num_red.Text = red.ToString();
                lbl_num_green.Text = green.ToString();
                lbl_num_blue.Text = blue.ToString();

                UpdateColor();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 100;

            if (chk_EnableLaser.Checked)
            {
                trackBar1.Enabled = true;
                trackBar2.Enabled = true;
                trackBar3.Enabled = true;
                btn_rgbpicker.Enabled = true;
            }
            else
            {
                trackBar1.Enabled = false;
                trackBar2.Enabled = false;
                trackBar3.Enabled = false;
                btn_rgbpicker.Enabled = false;
            }
        }

        private void cb_ResolutionPresets_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (cb_ResolutionPresets.Text)
            {
                case "HD (720p)":
                    txt_resWidth.Text = "1280";
                    txt_resHeight.Text = "720";
                    break;

                case "Full-HD (1080p)":
                    txt_resWidth.Text = "1920";
                    txt_resHeight.Text = "1080";
                    break;

                case "Quad-HD (1440p)":
                    txt_resWidth.Text = "2560";
                    txt_resHeight.Text = "1440";
                    break;

                case "Ultra-HD (2160p)":
                    txt_resWidth.Text = "3840";
                    txt_resHeight.Text = "2160";
                    break;

            }
        }

        private void rb_FPSoff_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Removing the frame limit will fix most of the slow motion problems, but will also cause several bugs to your game. Please know that turning it off is not recommended.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
