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

        bool goUp;
        bool goDown;
        int speed = ChangeSpeed();

        static int ChangeSpeed()
        {
            if (clsConfig.difficulty == "Easy")
            {
                return 20;
            }
            else if (clsConfig.difficulty == "Normal")
            {
                return 30;
            }
            else if (clsConfig.difficulty == "Hard")
            {
                return 40;
            }
            else
                return 0;
        }

        int xBall = 7;
        int yBall = 7;
        int points = 0;
        int pointsPC = 0;

        public frmPong()
        {
            frmTutorialPong t = new frmTutorialPong();
            t.ShowDialog();
            InitializeComponent();

            if(clsConfig.music == "on")
            {
                track.URL = "trilha.mp3";
                track.controls.play();
                track.settings.setMode("loop", true);
            }
            timerPong.Start();
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
            lblPointsPlayer.Text = "Wuo: " + points;
            lblPointsPC.Text = "Limits: " + pointsPC;

            pcbBall.Top -= yBall;
            pcbBall.Left -= xBall;
            pcbPc.Top += speed;

            if (pcbPc.Top < 0 || pcbPc.Top > 500)
            {
                speed *= -1;
            }

            CheckBorderCollision();
            CheckBallCollision();
            CheckPlayerMovement();
            

            if (points == 5)
            {
                GameOver("WUO HAVE WON THE LIMITS!!!", "win");  
            }

            if (pointsPC == 5)
            {
                GameOver("WUO HAVE LOST...", "loss");
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
            if (clsConfig.sounds == "on")
            {
                pointsSound.URL = "ponto.mp3";
                pointsSound.controls.play();
            }
        }

        void GameOver(string message, string condition)
        {
            timerPong.Stop();
            if (clsConfig.sounds == "on")
            {
                track.controls.stop();
                if (condition == "loss")
                {
                    gameOverSound.URL = "gameOver.mp3";
                    gameOverSound.controls.play();
                }

                if(condition == "win")
                {
                    track.controls.stop();
                    winSound.URL = "winSound.mp3";
                    winSound.controls.play();
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
                if (clsConfig.sounds == "on")
                {
                    racket.URL = "raquetada.mp3";
                    racket.controls.play();
                }
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

