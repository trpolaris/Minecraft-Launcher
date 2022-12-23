using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRPOLARIS_Launcher
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private DiscordRPC.EventHandlers handlers;
        private DiscordRPC.RichPresence presence;
        void RPC()
        {
            this.handlers = default(DiscordRPC.EventHandlers);
            DiscordRPC.Initialize("954797771708317726", ref this.handlers, true, null);
            this.presence.details = "TRPOLARIS";
            this.presence.state = "Developer";
            this.presence.largeImageKey = "wall";
            this.presence.largeImageText = "TRPOLARIS";
            this.presence.smallImageKey = "wall";
            this.presence.smallImageText = "Developer";
            this.presence.startTimestamp = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
            DiscordRPC.UpdatePresence(ref this.presence);
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 4;
            if (panel2.Width >= 500)
            {
                timer1.Stop();
                MainPage main = new MainPage();
                main.Show();
                Hide();
            }
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            RPC();
        }
    }
}
