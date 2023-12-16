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
    public partial class frmTutorialDino : Form
    {
        WMPLib.WindowsMediaPlayer houstonSound = new WMPLib.WindowsMediaPlayer();
        public frmTutorialDino()
        {
            InitializeComponent();
            timerTutorialDino.Start();
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

        private void timerTutorialDino_Tick(object sender, EventArgs e)
        {
            panelLoadingGame.Width += TutorialConstants.WIDTH_GAIN;
            if (panelLoadingGame.Width > TutorialConstants.MAX_WIDTH)
            {
                timerTutorialDino.Stop();
                if (clsConfig.sounds == ConfigurationConstants.MUSIC_ON)
                    houstonSound.controls.stop();
                this.Close();
            }
        }
    }
}
