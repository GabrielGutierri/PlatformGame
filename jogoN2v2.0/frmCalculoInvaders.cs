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
    public partial class frmCalculoInvaders : Form
    {
        WMPLib.WindowsMediaPlayer laserSom = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer enemyDestroyed = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer invadersSound = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer gameOverSound = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer winSound = new WMPLib.WindowsMediaPlayer();

        bool vaiParaEsquerda, vaiParaDireita;
        int velocidade = 12;
        int velocidadeInimigo = 0;
        int pontos = 0;
        int laserInimigoTimer = 300;
        int recorde = 0;
        PictureBox[] invadersVetor;
        bool atira;
        bool isGameOver;
        int vidas = 3;


        public frmCalculoInvaders()
        {
            frmTutorialInvaders t = new frmTutorialInvaders();
            t.ShowDialog();
            InitializeComponent();
            if (clsConfig.musicas == "on")
            {
                invadersSound.URL = "invadersSound.mp3";
                invadersSound.controls.play();
                invadersSound.settings.setMode("loop", true);
            }
            gameSetup();
        }
        private void InvadersTimerEvent(object sender, EventArgs e)
        {
            lblPontos.Text = "Pontos: " + pontos;
            lblVidas.Text = "Vidas: " + vidas;
            lblRecorde.Text = "Melhor rodada: " + recorde;
            if (vaiParaEsquerda && pcbJogador.Left > 0)
            {
                pcbJogador.Left -= velocidade;
            }

            if (vaiParaDireita && pcbJogador.Left < 620)
            {
                pcbJogador.Left += velocidade;
            }

            laserInimigoTimer -= 10;
            if (laserInimigoTimer < 10)
            {
                laserInimigoTimer = 300;
                criaLaser("invaderLaser");
            }

            foreach (Control x in this.Controls)
            {

                verificaColisaoInimigo(x);
                VerificaColisaoLaser(x);
                VerificaColisaoLaserInimigo(x);

            }

            if (pontos > 8)
            {
                MudaVelocidade();
            }

            if (pontos == invadersVetor.Length)
            {
                gameOver("Você venceu as derivadas!!! YUUUUUPPPPIIIIII");
            }
        }

        void VerificaColisaoLaser(Control x)
        {
            if (x is PictureBox && (string)x.Tag == "laser")
            {
                x.Top -= 20;
                if (x.Top < 15)
                {
                    this.Controls.Remove(x);
                    atira = false;
                }
            }
        }
        void verificaColisaoInimigo(Control x)
        {
            if (x is PictureBox && (string)x.Tag == "invader")
            {
                MoveInvader(x);

                if (x.Bounds.IntersectsWith(pcbJogador.Bounds))
                {
                    gameOver("Você foi pego pelos invaders... F");
                    vidas--;
                }

                foreach (Control y in this.Controls)
                {
                    if (y is PictureBox && (string)y.Tag == "laser")
                    {
                        if (y.Bounds.IntersectsWith(x.Bounds))
                        {
                            if (clsConfig.sons == "on")
                            {
                                enemyDestroyed.URL = "enemyDestroyed.mp3";
                                enemyDestroyed.controls.play();
                            }
                            this.Controls.Remove(x);
                            this.Controls.Remove(y);
                            pontos += 1;
                            atira = false;
                        }
                    }
                }
            }
        }
        void MoveInvader(Control x)
        {
            x.Left += velocidadeInimigo;
            if (x.Left > 730)
            {
                x.Top += 65;
                x.Left = -80;
            }
        }
        void VerificaColisaoLaserInimigo(Control x)
        {
            if (x is PictureBox && (string)x.Tag == "invaderLaser")
            {
                MoveRemoveLaser(x);

                if (x.Bounds.IntersectsWith(pcbJogador.Bounds))
                {
                    this.Controls.Remove(x);
                    gameOver("Você foi pego pelo laser dos invaders... F");
                    vidas--;
                }
            }
        }
        void MoveRemoveLaser(Control x)
        {
            x.Top += 20;
            if (x.Top > 620)
            {
                this.Controls.Remove(x);
            }
        }
        void MudaVelocidade()
        {
            if (clsConfig.dificuldade == "Easy")
            {
                velocidade = 14;
                velocidadeInimigo = 8;
            }
            else if (clsConfig.dificuldade == "Normal")
            {
                velocidade = 16;
                velocidadeInimigo = 12;
            }
            else if (clsConfig.dificuldade == "Hard")
            {
                velocidade = 18;
                velocidadeInimigo = 15;
            }
        }
        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                vaiParaEsquerda = true;

            }
            if (e.KeyCode == Keys.Right)
            {
                vaiParaDireita = true;
            }
        }

        private void keyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                vaiParaEsquerda = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                vaiParaDireita = false;
            }

            if (e.KeyCode == Keys.Space && atira == false)
            {
                if (clsConfig.sons == "on")
                {
                    laserSom.URL = "somLaser.mp3";
                    laserSom.controls.play();
                }
                atira = true;
                criaLaser("laser");
            }
            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                if (clsConfig.sons == "on")
                {
                    invadersSound.controls.play();
                    invadersSound.settings.setMode("loop", true);
                }
                removeTela(vidas, pontos);

                gameSetup();
            }
        }

        private void criaInvaders()
        {
            invadersVetor = new PictureBox[15];
            int left = 0;
            for (int i = 0; i < invadersVetor.Length; i++)
            {
                invadersVetor[i] = new PictureBox();
                invadersVetor[i].Size = new Size(80, 60);
                invadersVetor[i].Image = Properties.Resources.derivada_2;
                invadersVetor[i].Top = 5;
                invadersVetor[i].Tag = "invader";
                invadersVetor[i].Left = left;
                invadersVetor[i].SizeMode = PictureBoxSizeMode.Zoom;
                this.Controls.Add(invadersVetor[i]);
                left = left - 80;
            }
        }

        void gameSetup()
        {
            lblPontos.Text = "Pontos: 0";
            pontos = 0;
            isGameOver = false;
            laserInimigoTimer = 300;
            MudaVelocidadeInimigo();

            atira = false;

            criaInvaders();
            gameTimer.Start();
        }

        void MudaVelocidadeInimigo()
        {
            if (clsConfig.dificuldade == "Easy")
            {
                velocidadeInimigo = 5;
            }
            else if (clsConfig.dificuldade == "Normal")
            {
                velocidadeInimigo = 8;
            }
            else if (clsConfig.dificuldade == "Hard")
            {
                velocidadeInimigo = 12;
            }
        }
        

        void removeTela(int vidas, int pontosTentativa)
        {
            foreach (PictureBox i in invadersVetor)
            {
                this.Controls.Remove(i);
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "laser" || (string)x.Tag == "invaderLaser")
                    {
                        this.Controls.Remove(x);
                    }
                }
            }
            if (vidas == 3)
            {
                recorde = pontosTentativa;
            }
            else if (pontosTentativa > recorde)
            {
                recorde = pontosTentativa;
            }

            else if (vidas == 0)
            {
                invadersSound.controls.stop();
                gameOverSound.controls.stop();
                this.Close();
            }
        }
        void gameOver(string mensagem)
        {
            isGameOver = true;
            gameTimer.Stop();
            invadersSound.controls.stop();
            clsConfig.pontosInvaders = recorde;
            if (mensagem == "Você foi pego pelo laser dos invaders... F" || mensagem == "Você foi pego pelos invaders... F")
            {
                if (clsConfig.sons == "on")
                {
                    gameOverSound.URL = "gameOver.mp3";
                    gameOverSound.controls.play();
                }
                if (vidas > 1)
                    MessageBox.Show($"{mensagem}\nVolte no jogo e tente mais uma vez (Aperte ENTER para recomeçar)");
                if (vidas == 1)
                {
                    if (pontos > recorde)
                    {
                        recorde = pontos;
                    }
                    MessageBox.Show($"Sem mais vidas restantes. Sua melhor pontuação: {recorde}");
                    this.Close();
                }
            }
            else
            {
                if (clsConfig.sons == "on")
                {
                    winSound.URL = "winSound.mp3";
                    winSound.controls.play();
                }
                MessageBox.Show($"{mensagem}\nVIVA! O nosso grande mestre Wuo conseguiu vencer a dungeon das derivadas!!!!");
                clsConfig.pontosInvaders = invadersVetor.Length;
                this.Close();
            }
            lblPontos.Text = "Pontos: " + pontos;
        }

        void criaLaser(string laserTag)
        {
            PictureBox laser = new PictureBox();
            laser.Image = Properties.Resources.laser;
            laser.Size = new Size(5, 20);
            laser.Tag = laserTag;
            laser.Left = pcbJogador.Left + pcbJogador.Width / 2;

            if ((string)laser.Tag == "laser")
            {
                laser.Top = pcbJogador.Top - 20;
            }
            if ((string)laser.Tag == "invaderLaser")
            {
                laser.Top = -100;
            }
            this.Controls.Add(laser);
            laser.BringToFront();
        }
    }
}
