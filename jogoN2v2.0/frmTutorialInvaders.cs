using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jogoN2v2._0
{
    public partial class frmTutorialInvaders : Form
    {
        WMPLib.WindowsMediaPlayer houstonSound = new WMPLib.WindowsMediaPlayer();
        public frmTutorialInvaders()
        {
            InitializeComponent();
            timerTutorialInvaders.Start();
            if(clsConfig.sounds == "on")
            {
                houstonSound.URL = "Houston.mp3";
                houstonSound.controls.play();
                houstonSound.settings.setMode("loop", true);
            }
        }

        private void timerTutorialInvaders_Tick(object sender, EventArgs e)
        {
            panel1.Width += 7;
            if(panel1.Width > 563)
            {
                timerTutorialInvaders.Stop();
                if (clsConfig.sounds == "on")
                    houstonSound.controls.stop();
                this.Close();
            }
        }
    }
}
