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
        int vidas = 3;
        int recorde = 0;

        public frmDinoGame()
        {
            frmTutorialDino f = new frmTutorialDino();
            f.ShowDialog();

            InitializeComponent();
            if(clsConfig.musicas == "on")
            {
                backgroundSound.URL = "FallGuys.mp3";
                backgroundSound.controls.play();
                backgroundSound.settings.setMode("loop", true);
                backgroundSound.settings.volume = 10;
            }
            txtScore.Text = "Aperte espaço para pular das integrais! Aperte R para começar";


        }


        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            pcbWuo.Top += jumpSpeed;

            // mostra pontos
            txtScore.Text = "Pontos: " + score;
            txtLifes.Text = "Vidas: " + vidas;
            txtRecord.Text = "Melhor Rodada: " + recorde;

            Pulo();

            foreach (Control z in this.Controls)
            {
                if (z is PictureBox && z.Tag == "obstaculo")
                {
                    z.Left -= obstacleSpeed;
                    // pula ganha ponto
                    if (z.Left + z.Width < -120)
                    {
                        z.Left = this.ClientSize.Width + rand.Next(200, 800);
                        score++;
                    }

                    VerificaColisao(z);
                    
                }
            }

            // if wuo top é maior do que o limite do pulo e AND pulando == true
            if (pcbWuo.Top >= 240 && !jumping)
            {
                force = 12;
                pcbWuo.Top = chao.Top - pcbWuo.Height;
                jumpSpeed = 0;
            }


            AumentaVelocidade();
            VerificaVitoria();
            
        }

        void Pulo()
        {
            if (jumping && force < 0)
            {
                jumping = false;
            }
            //pulo
            if (jumping)
            {
                jumpSpeed = -12;
                force -= 1;
            }
            //queda
            else
            {
                jumpSpeed = 12;
            }
        }

        void VerificaColisao(Control z)
        {
            if (pcbWuo.Bounds.IntersectsWith(z.Bounds))
            {
                timer.Stop();
                if(clsConfig.sons == "on")
                {
                    hit.URL = "MarioHit.mp3";
                    hit.controls.play();
                }
                pcbWuo.Image = Properties.Resources.imagem_wuo_2;
                txtScore.Text += "  Aperte R para reiniciar";
                backgroundSound.controls.stop();
                vidas--;
                isGameOver = true;
            }
        }

        void AumentaVelocidade()
        {
            if (score >= 5 && clsConfig.dificuldade == "Easy")
            {
                obstacleSpeed = 15;
            }
            else if (score >= 5 && clsConfig.dificuldade == "Normal")
            {
                obstacleSpeed = 20;
            }
            else
            {
                obstacleSpeed = 25;
                if (score >= 10) obstacleSpeed = 35;
            }
        }

        void VerificaVitoria()
        {
            if (score == 15 && clsConfig.dificuldade == "Normal" || clsConfig.dificuldade == "Easy")
            {
                timer.Stop();
                pcbWuo.Image = Properties.Resources.imagem_wuo_2;
                TocaTemaWin();
                MessageBox.Show("Parabéns você venceu");
                backgroundSound.controls.stop();

                clsConfig.pontosDino = 15;
                this.Close();
            }
            else if (score == 20 && clsConfig.dificuldade == "Hard")
            {
                timer.Stop();
                pcbWuo.Image = Properties.Resources.imagem_wuo_2;
                TocaTemaWin();
                MessageBox.Show("Parabéns você venceu");
                backgroundSound.controls.stop();
                clsConfig.pontosDino = 20;
                this.Close();
            }
        }

        void TocaTemaWin()
        {
            if (clsConfig.sons == "on")
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
                if(clsConfig.sons == "on")
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
                verificaRecorde(vidas, score);
                if (vidas == 0)
                {
                    if (clsConfig.sons == "on")
                    {
                        gameOverSound.URL = "gameOver.mp3";
                        gameOverSound.controls.play();
                    }
                    backgroundSound.controls.stop();
                    MessageBox.Show($"Sem mais vidas restantes! Sua pontuação foi: {recorde}");
                    clsConfig.pontosDino = recorde;
                    this.Close();
                }
                
                GameReset();
            }
        }

        void verificaRecorde(int vidas, int score)
        {
            if (vidas == 3)
                recorde = score;
            else if (score > recorde)
                recorde = score;
            
        }

        private void GameReset()
        {
            force = 12;
            jumpSpeed = 10;
            jumping = false;
            score = 0;
            obstacleSpeed = Dificuldade();

            txtScore.Text = "Pontos:" + score;
            pcbWuo.Image = Properties.Resources.jogowuogif;
            isGameOver = false;
            //wuo.Top = 260;
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "obstaculo")
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
        private int Dificuldade()
        {
            if (clsConfig.dificuldade == "Easy")
            {
                return 10;
            }
            else if (clsConfig.dificuldade == "Normal")
            {
                return 15;
            }
            else if (clsConfig.dificuldade == "Hard")
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
