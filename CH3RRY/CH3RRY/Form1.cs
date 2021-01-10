using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordRPC;

namespace CH3RRY
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public Form1()
        {
            InitializeComponent();
            DiscordRpcClient client = new DiscordRpcClient("797671593580953670");
            client.Initialize();
            client.SetPresence(new RichPresence()
            {
                Details = "Level 6 Lua Executor | Auto updating exploit",
                State = "Using CH3RRY",
                Assets = new Assets()
                {
                    LargeImageKey = "c3rray",
                }
            });
        }

        ShadowCheats.Module api = new ShadowCheats.Module();

        private void fastColoredTextBox1_Load(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Lua;
            string credits = @"--[[
CH3RRY Executor by Pupper#2006 and deaddlocust#1757 ;)
--]]
";
            fastColoredTextBox1.Text = credits;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/7vfPmATSVf");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(System.Drawing.Color.Red, 5),
                                     this.DisplayRectangle);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/7vfPmATSVf");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("RobloxPlayerBeta").Length > 0)
            {
                if (api.ValidateAttachment())
                {
                    MessageBox.Show("CH3RRY is already injected!", "CH3RRY");
                }
                else
                {
                    api.Attach();
                }
            }
            else
            {
                MessageBox.Show("Please open Roblox before injecting!", "CH3RRY");
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (api.ValidateAttachment())
            {
                api.ExecuteScript(fastColoredTextBox1.Text);
            }
            else
            {
                MessageBox.Show("Please inject the exploit before executing!", "CH3RRY");
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Clear();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Title = "Browse Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "Text files (*.txt)|*.txt|Lua files (*.lua)|*.lua",
                FilterIndex = 1,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fastColoredTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }
    }
}
