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
    public partial class frmTutorialPong : Form
    {
        WMPLib.WindowsMediaPlayer houstonSound = new WMPLib.WindowsMediaPlayer();
        public frmTutorialPong()
        {
            InitializeComponent();
            timerTutorialPong.Start();
            if (clsConfig.sons == "on")
            {
                houstonSound.URL = "Houston.mp3";
                houstonSound.controls.play();
                houstonSound.settings.setMode("loop", true);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Width += 7;
            if (panel1.Width > 563)
            {
                timerTutorialPong.Stop();
                if (clsConfig.sons == "on")
                    houstonSound.controls.stop();
                this.Close();
            }
        }
    }
}
