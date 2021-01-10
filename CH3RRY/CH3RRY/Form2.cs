using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShadowCheats;

namespace CH3RRY
{
    public partial class Form2 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public Form2()
        {
            InitializeComponent();
        }

        ShadowCheats.Module api = new ShadowCheats.Module();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(System.Drawing.Color.Red, 5),
                                     this.DisplayRectangle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var process in Process.GetProcessesByName("RobloxPlayerBeta"))
            {
                process.Kill();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (api.ValidateAttachment())
            {
                api.ExecuteScript("loadstring(game:HttpGet(('https://github.com/MarsQQ/ScriptHubScripts/blob/master/FPS%20Boost'),true))()");
            }
            else
            {
                MessageBox.Show("Please inject the exploit before using this!", "Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("GHOST.exe");
        }
    }
}
