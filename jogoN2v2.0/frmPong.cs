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
    public partial class frmPong : Form
    {

        WMPLib.WindowsMediaPlayer racket = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer track = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer pointsSound = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer gameOverSound = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer winSound = new WMPLib.WindowsMediaPlayer();

        private bool goUp;
        private bool goDown;
        private int speed = ChangeSpeed();
        private int xBall = 7;
        private int yBall = 7;
        private int points = 0;
        private int pointsPC = 0;

        static int ChangeSpeed()
        {
            switch (clsConfig.difficulty)
            {
                case ConfigurationConstants.EASY:
                    return 20;
                case ConfigurationConstants.NORMAL:
                    return 30;
                case ConfigurationConstants.HARD:
                    return 40;
                default:
                    return 0;
            }
        }

        public frmPong()
        {
            frmTutorialPong t = new frmTutorialPong();
            t.ShowDialog();
            InitializeComponent();
            PlayTheme();
            timerPong.Start();
        }

        private void PlayTheme()
        {
            if (clsConfig.music == ConfigurationConstants.MUSIC_ON)
            {
                GameUtils.PlayTrack("trilha.mp3", track);
                track.settings.setMode("loop", true);
            }
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
        }

        private void timerPong_Click(object sender, EventArgs e)
        {
            SetVariables();
            CheckBorderCollision();
            CheckBallCollision();
            CheckPlayerMovement();
            SetGameOver();
        }

        private void SetGameOver()
        {
            if (points == 5)
            {
                GameOver(PongConstants.WUO_WIN_MESSAGE, "win");
            }

            if (pointsPC == 5)
            {
                GameOver(PongConstants.WUO_LOST_MESSAGE, "loss");
            }
        }

        private void SetVariables()
        {
            lblPointsPlayer.Text = $"{GameConstants.WUO}: " + points;
            lblPointsPC.Text = $"{GameConstants.LIMITS}: " + pointsPC;

            pcbBall.Top -= yBall;
            pcbBall.Left -= xBall;
            pcbPc.Top += speed;

            if (pcbPc.Top < 0 || pcbPc.Top > 500)
            {
                speed *= -1;
            }
        }

        void CheckBorderCollision()
        {
            if (pcbBall.Left < 0)
            {
                pcbBall.Left = 400;
                xBall = -xBall;
                xBall -= 2;
                pointsPC++;

                Score();
            }

            if (pcbBall.Left + pcbBall.Width > 800)
            {
                pcbBall.Left = 400;
                xBall = -xBall;
                xBall += 2;
                points++;

                Score();
            }
        }

        void Score()
        {
            GameUtils.PlayTrack("ponto.mp3", pointsSound);
        }

        void GameOver(string message, string condition)
        {
            timerPong.Stop();
            if (clsConfig.sounds == ConfigurationConstants.MUSIC_ON)
            {
                track.controls.stop();
                if (condition == "loss")
                {
                    GameUtils.PlayTrack("gameOver.mp3", gameOverSound);
                }

                if(condition == "win")
                {
                    track.controls.stop();
                    GameUtils.PlayTrack("winSound.mp3", winSound);
                }
            }
            clsConfig.pointsPong = points;
            MessageBox.Show(message);
            this.Close();

        }
        
        void CheckBallCollision()
        {
            if (pcbBall.Top < 0 || pcbBall.Top + pcbBall.Height > 600)
                yBall *= -1;

            if (pcbBall.Bounds.IntersectsWith(pcbPlayer.Bounds) || pcbBall.Bounds.IntersectsWith(pcbPc.Bounds))
            {
                xBall *= -1;
                GameUtils.PlayTrack("raquetada.mp3", racket);
            }
        }

        void CheckPlayerMovement()
        {
            if (goUp == true && pcbPlayer.Top > 0)
            {
                pcbPlayer.Top -= 15;
            }

            if (goDown == true && pcbPlayer.Top < 500)
            {
                pcbPlayer.Top += 15;
            }
        }
    }
}

