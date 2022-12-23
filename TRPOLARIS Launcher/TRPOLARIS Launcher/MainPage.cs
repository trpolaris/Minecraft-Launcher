using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using CmlLib.Core;
using CmlLib.Core.Auth;


namespace TRPOLARIS_Launcher
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
           WindowState = FormWindowState.Minimized;
        }

        private void versioncombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            label4.Text = versioncombobox.Text;
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2Button1.Text = "AÇILIYOR";
            guna2Button1.Enabled = true;
            Thread thread = new Thread(() => launch());
            thread.IsBackground = true;
            thread.Start();


        }

        public static string version;


        MSession mSession;

        private void path() 
        {
            //var path = new MinecraftPath("game_directory_path");
            var path = new MinecraftPath(); // use default directory

            var launcher = new CMLauncher(path);

            // show launch progress to console
            launcher.FileChanged += (e) =>
            {
                listBox1.Items.Add(string.Format("[{0}] {1} - {2}/{3}", e.FileKind.ToString(), e.FileName, e.ProgressedFileCount, e.TotalFileCount));
            };
            launcher.ProgressChanged += (s, e) =>
            {
                //Console.WriteLine("{0}%", e.ProgressPercentage);
            };

            foreach (var item in launcher.GetAllVersions())
            {
                // show all version names
                // use this version name in CreateProcessAsync method.
                versioncombobox.Items.Add(item.Name);
            }
            

        }
        
        
        private void launch() 
        {
            //var path = new MinecraftPath("game_directory_path");
            var path = new MinecraftPath(); // use default directory

            var launcher = new CMLauncher(path);
            listBox1.TopIndex = listBox1.Items.Count - 1;
            // show launch progress to console
            launcher.FileChanged += (e) =>
            {
                listBox1.Items.Add(string.Format("[{0}] {1} - {2}/{3}", e.FileKind.ToString(), e.FileName, e.ProgressedFileCount, e.TotalFileCount));
            };


            var launchOption = new MLaunchOption
            {
                MaximumRamMb = 4096,
                Session = MSession.GetOfflineSession("label3.text"),

                //ScreenWidth = 1600,
                //ScreenHeigth = 900,
                //ServerIp = "mc.hypixel.net"
            };

            //var process = await launcher.CreateProcessAsync("input version name here", launchOption);
            version = versioncombobox.SelectedItem.ToString();
            var process = launcher.CreateProcess(version, launchOption); // vanilla
                                                                         // var process = await launcher.CreateProcessAsync("1.12.2-forge1.12.2-14.23.5.2838", launchOption); // forge
                                                                         // var process = await launcher.CreateProcessAsync("1.12.2-LiteLoader1.12.2"); // liteloader
                                                                         // var process = await launcher.CreateProcessAsync("fabric-loader-0.11.3-1.16.5") // fabric-loader

            process.Start();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            path();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            {
                if (string.IsNullOrEmpty(guna2TextBox1.Text))
                {
                    MessageBox.Show("Kullanıcı Adı Boş Bırakılamaz");
                }

                else
                {
                    guna2TextBox1.Visible = true;
                    label3.Text = guna2TextBox1.Text;
                    label3.Visible = true;
                    guna2Button1.Visible = true;
                }
            }
        }
        //link verme
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/celill_ylmz/");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/TRPOLARISSS");
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/trpolaris");
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCnAby8eMOycnJ-CDJMBb9Rw");
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/trpolaris?tab=repositories");
        }
    }
}
