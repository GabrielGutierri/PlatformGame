using jogoN2v2._0.Constants;
using jogoN2v2._0.Utils;
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
            PlayTheme();
        }

        private void PlayTheme()
        {
            if (clsConfig.sounds == ConfigurationConstants.MUSIC_ON)
            {
                GameUtils.PlayTrack("Houston.mp3", houstonSound);
                houstonSound.settings.setMode("loop", true);
            }
        }
        private void timerTutorialPong_Tick(object sender, EventArgs e)
        {
            panel1.Width += TutorialConstants.WIDTH_GAIN;
            if (panel1.Width > TutorialConstants.MAX_WIDTH)
            {
                timerTutorialPong.Stop();
                if (clsConfig.sounds == ConfigurationConstants.MUSIC_ON)
                    houstonSound.controls.stop();
                this.Close();
            }
        }
    }
}
