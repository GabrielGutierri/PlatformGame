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
    public partial class frmDinoGame : Form
    {
        WMPLib.WindowsMediaPlayer jump = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer backgroundSound = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer hit = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer gameOverSound = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer winSound = new WMPLib.WindowsMediaPlayer();

        bool jumping = false;
        int jumpSpeed = 10;
        int force = 12;
        int score = 0;
        int obstacleSpeed = 10;
        Random rand = new Random();
        int position;
        bool isGameOver = true;
        int lifes = 3;
        int record = 0;

        public frmDinoGame()
        {
            frmTutorialDino f = new frmTutorialDino();
            f.ShowDialog();

            InitializeComponent();
            if(clsConfig.music == "on")
            {
                backgroundSound.URL = "FallGuys.mp3";
                backgroundSound.controls.play();
                backgroundSound.settings.setMode("loop", true);
                backgroundSound.settings.volume = 10;
            }
            txtScore.Text = "Press the spacebar to jump the integrals! Press R to restart";


        }


        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            pcbWuo.Top += jumpSpeed;

            // mostra pontos
            txtScore.Text = "Points: " + score;
            txtLifes.Text = "Lifes: " + lifes;
            txtRecord.Text = "Best round: " + record;

            Jump();

            foreach (Control z in this.Controls)
            {
                if (z is PictureBox && z.Tag == "obstacle")
                {
                    z.Left -= obstacleSpeed;
                    // pula ganha ponto
                    if (z.Left + z.Width < -120)
                    {
                        z.Left = this.ClientSize.Width + rand.Next(200, 800);
                        score++;
                    }

                    VerifyCollision(z);
                    
                }
            }

            // if wuo top é maior do que o limite do pulo e AND pulando == true
            if (pcbWuo.Top >= 240 && !jumping)
            {
                force = 12;
                pcbWuo.Top = chao.Top - pcbWuo.Height;
                jumpSpeed = 0;
            }


            IncreaseSpeed();
            CheckVictory();
            
        }

        void Jump()
        {
            if (jumping && force < 0)
            {
                jumping = false;
            }
            //jump
            if (jumping)
            {
                jumpSpeed = -12;
                force -= 1;
            }
            //fall
            else
            {
                jumpSpeed = 12;
            }
        }

        void VerifyCollision(Control z)
        {
            if (pcbWuo.Bounds.IntersectsWith(z.Bounds))
            {
                timer.Stop();
                if(clsConfig.sounds == "on")
                {
                    hit.URL = "MarioHit.mp3";
                    hit.controls.play();
                }
                pcbWuo.Image = Properties.Resources.imagem_wuo_2;
                txtScore.Text += "  Press R to restart";
                backgroundSound.controls.stop();
                lifes--;
                isGameOver = true;
            }
        }

        void IncreaseSpeed()
        {
            if (score >= 5 && clsConfig.difficulty == "Easy")
            {
                obstacleSpeed = 15;
            }
            else if (score >= 5 && clsConfig.difficulty == "Normal")
            {
                obstacleSpeed = 20;
            }
            else
            {
                obstacleSpeed = 25;
                if (score >= 10) obstacleSpeed = 35;
            }
        }

        void CheckVictory()
        {
            if (score == 15 && clsConfig.difficulty == "Normal" || clsConfig.difficulty == "Easy")
            {
                timer.Stop();
                pcbWuo.Image = Properties.Resources.imagem_wuo_2;
                PlayWinTheme();
                MessageBox.Show("Congrats! You've won!");
                backgroundSound.controls.stop();

                clsConfig.pointsDino = 15;
                this.Close();
            }
            else if (score == 20 && clsConfig.difficulty == "Hard")
            {
                timer.Stop();
                pcbWuo.Image = Properties.Resources.imagem_wuo_2;
                PlayWinTheme();
                MessageBox.Show("Congrats! You've won!");
                backgroundSound.controls.stop();
                clsConfig.pointsDino = 20;
                this.Close();
            }
        }

        void PlayWinTheme()
        {
            if (clsConfig.sounds == "on")
            {
                winSound.URL = "winSound.mp3";
                winSound.controls.play();
            }
        }
        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;
                if(clsConfig.sounds == "on")
                {
                    jump.URL = "jump.mp3";
                    jump.controls.play();
                    jump.settings.volume = 100;
                }
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (jumping == true)
            {
                jumping = false;
            }
            if (e.KeyCode == Keys.R && isGameOver == true)
            {
                timer.Stop();
                VerifyRecord(lifes, score);
                if (lifes == 0)
                {
                    if (clsConfig.sounds == "on")
                    {
                        gameOverSound.URL = "gameOver.mp3";
                        gameOverSound.controls.play();
                    }
                    backgroundSound.controls.stop();
                    MessageBox.Show($"No more lifes! Your best round: {record}");
                    clsConfig.pointsDino = record;
                    this.Close();
                }
                
                GameReset();
            }
        }

        void VerifyRecord(int vidas, int score)
        {
            if (vidas == 3)
                record = score;
            else if (score > record)
                record = score;
            
        }

        private void GameReset()
        {
            force = 12;
            jumpSpeed = 10;
            jumping = false;
            score = 0;
            obstacleSpeed = DifficultySpeed();

            txtScore.Text = "Points:" + score;
            pcbWuo.Image = Properties.Resources.jogowuogif;
            isGameOver = false;
            //wuo.Top = 260;
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "obstacle")
                {
                    int position = rand.Next(600, 1000);
                    x.Left = 640 + (x.Left + position + x.Width * 3);
                    /*
                    position = this.ClientSize.Width + rand.Next(10, 100) + (x.Width * 10);
                    x.Left = position;
                    */
                }
            }
            timer.Start();
            backgroundSound.controls.play();
        }
        private int DifficultySpeed()
        {
            if (clsConfig.difficulty == "Easy")
            {
                return 10;
            }
            else if (clsConfig.difficulty == "Normal")
            {
                return 15;
            }
            else if (clsConfig.difficulty == "Hard")
            {
                return 20;
            }
            else
            {
                return 0;
            }
        }
    }
}
