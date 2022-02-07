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
    public partial class frmJogoPrincipal : Form
    {
        WMPLib.WindowsMediaPlayer SomPulo = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer SomDano = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer gameOverSound = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer winSound = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer SomPrincipal = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer laserSom = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer enemyDestroyed = new WMPLib.WindowsMediaPlayer();
        bool goRight, goLeft, jumping, hasKey1, hasKey2, hasKey3, parede, atira, sentidoDireita = true, imune = false, movimentaimagemdirecao = true, atirainimigo = true;
        int velocidadePulo = 10, velocidadeJogador = 2, forca = 8, score = 0, FundoTela = 16, vidas = 3, QuantosMini = 0, tempoimune = 0, movimentaimagem;
        PictureBox[] vida = new PictureBox[4];
        public frmJogoPrincipal()
        {
            InitializeComponent();
            if (clsConfig.musicas == "on")
            {
                SomPrincipal.URL = "song-two.mp3";
                SomPrincipal.controls.play();
                SomPrincipal.settings.setMode("loop", true);
            }
            
            vida[1] = pcbCoracao1;
            vida[2] = pcbCoracao2;
            vida[3] = pcbCoracao3;
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score;
            pcbPersonagem.Top += velocidadePulo;

            MovimentaçãoPersonagem();
            MoveGameElements4();
            MovimentacaoJogo();
            VerificaCoalisao1();
            VerificaCoalisao2();
            VerificaCoalisao3();
            VerificaCoalisao4();
            VerificaCoalisao6();

            foreach (Control x in this.Controls)
            {

                verificaColisaoInimigo(x);
                if (x is PictureBox && (string)x.Tag == "laser")
                {
                    if (sentidoDireita == true)
                    {
                        x.Left += 20;
                        if (x.Left > 600)
                        {
                            this.Controls.Remove(x);
                            atira = false;
                        }

                        VerificaColisao5(x);

                    }

                    if (sentidoDireita == false)
                    {
                        x.Left -= 20;
                        if (x.Left < 0)
                        {
                            this.Controls.Remove(x);
                            atira = false;
                        }

                        VerificaColisao5(x);
                    }
                }

            }

            GanhaouMorre();
            ImuneDano();
            InimigoAtira();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                sentidoDireita = false;
                pcbPersonagem.Image = Properties.Resources.wuo_tras1;
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                sentidoDireita = true;
                pcbPersonagem.Image = Properties.Resources.imagem_wuo_3;
                goRight = true;

            }
            if (e.KeyCode == Keys.Space && jumping == false)
            {
                if (sentidoDireita == false)
                {
                    pcbPersonagem.Image = Properties.Resources.wuo_tras_pulando;
                }
                else
                {
                    pcbPersonagem.Image = Properties.Resources.wuo_pulando;
                }

                if (clsConfig.sons == "on")
                {
                    SomPulo.URL = "som_de_pulo_.mp3";
                    SomPulo.controls.play();
                }
                jumping = true;
            }
            if (e.KeyCode == Keys.Enter && atira == false)
            {
                if (sentidoDireita == false)
                {
                    pcbPersonagem.Image = Properties.Resources.wuo_tras_atirando;
                }
                else
                {
                    pcbPersonagem.Image = Properties.Resources.wuo_atirando;
                }
                if (clsConfig.sons == "on")
                {
                    laserSom.URL = "somLaser.mp3";
                    laserSom.controls.play();
                }
                atira = true;
                criaLaser("laser");
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                sentidoDireita = false;
                pcbPersonagem.Image = Properties.Resources.wuo_tras2;
                goLeft = false;

            }
            if (e.KeyCode == Keys.Right)
            {
                sentidoDireita = true;
                pcbPersonagem.Image = Properties.Resources.imagem_wuo_2;
                goRight = false;

            }
            if (jumping == true)
            {
                if (sentidoDireita == false)
                {
                    pcbPersonagem.Image = Properties.Resources.wuo_tras2;
                }
                else
                {
                    pcbPersonagem.Image = Properties.Resources.imagem_wuo_2;
                }

                jumping = false;
            }
            if (e.KeyCode == Keys.Enter && atira == true)
            {
                if (sentidoDireita == false)
                {
                    pcbPersonagem.Image = Properties.Resources.wuo_tras2;
                }
                else
                {
                    pcbPersonagem.Image = Properties.Resources.imagem_wuo_2;
                }
            }
        }

        private void MoveGameElements1(string direction)
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "plataforma" || x is PictureBox && (string)x.Tag == "moeda" || x is PictureBox && (string)x.Tag == "chave")
                {
                    if (direction == "back")
                    {
                        x.Left -= FundoTela;
                    }
                    if (direction == "forward")
                    {
                        x.Left += FundoTela;
                    }
                }
            }
        }

        private void MoveGameElements2(string direction)
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "porta" || x is PictureBox && (string)x.Tag == "parede" || x is PictureBox && (string)x.Tag == "inimigo")
                {

                    if (direction == "back")
                    {
                        x.Left -= FundoTela;
                    }
                    if (direction == "forward")
                    {
                        x.Left += FundoTela;
                    }

                }
            }
        }

        private void MoveGameElements3(string direction)
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "lava" || x is PictureBox && (string)x.Tag == "carro")
                {

                    if (direction == "back")
                    {
                        x.Left -= FundoTela;
                    }
                    if (direction == "forward")
                    {
                        x.Left += FundoTela;
                    }

                }
            }
        }

        private void MoveGameElements4()
        {
            int i = 10;
            
            if(movimentaimagem == 0)
            {
                movimentaimagemdirecao = true;
            }
            else if(movimentaimagem == 50)
            {
                movimentaimagemdirecao = false;
            }

            if (movimentaimagemdirecao == true)
            {
                pcbCarro.Left -= i;
                movimentaimagem++;
            }
            else
            {
                pcbCarro.Left += i;
                movimentaimagem--;
            }
            
        }

        private void MovimentaçãoPersonagem()
        {

            if (goLeft == true && pcbPersonagem.Left > 60)
            {
                pcbPersonagem.Left -= velocidadeJogador;
            }
            if (goRight == true && pcbPersonagem.Left + (pcbPersonagem.Width + 60) < this.ClientSize.Width)
            {
                pcbPersonagem.Left += velocidadeJogador;
            }
            if (jumping == true)
            {
                velocidadePulo = -10;
                forca -= 1;
            }
            else
            {
                velocidadePulo = 10;
            }

            if (jumping == true && forca < 0)
            {
                jumping = false;
            }

        }

        private void MovimentacaoJogo()
        {
            if (goLeft == true && pcbFundoTela.Left < 0 && parede == false)
            {
                pcbFundoTela.Left += FundoTela;
                MoveGameElements1("forward");
                MoveGameElements2("forward");
                MoveGameElements3("forward");
            }
            if (goRight == true && pcbFundoTela.Left > -2120 && parede == false)
            {
                pcbFundoTela.Left -= FundoTela;
                MoveGameElements1("back");
                MoveGameElements2("back");
                MoveGameElements3("back");

                if (pcbFundoTela.Left < -2100)
                {
                    velocidadeJogador = 10;
                }
                else
                {
                    velocidadeJogador = 2;
                }
            }
        }

        private void VerificaCoalisao1()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "parede")
                {
                    if (pcbPersonagem.Bounds.IntersectsWith(x.Bounds))
                    {
                        parede = true;
                        forca = 8;
                        pcbPersonagem.Left = x.Left - (pcbPersonagem.Height - 25);

                    }

                    x.BringToFront();
                    parede = false;
                }

                if (x is PictureBox && (string)x.Tag == "moeda")
                {
                    if (pcbPersonagem.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                    {
                        x.Visible = false;
                        score += 1;

                    }
                }
            }
        }

        private void VerificaCoalisao2()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "inimigo" || x is PictureBox && (string)x.Tag == "lava")
                {
                    if (pcbPersonagem.Bounds.IntersectsWith(x.Bounds) && imune == false)
                    {
                        if (clsConfig.sons == "on")
                        {
                            SomDano.URL = "barulho_de_soco_.mp3";
                            SomDano.controls.play();
                        }
                        imune = true;
                        this.Controls.Remove(vida[vidas]);
                        vidas--;
                    }

                    x.BringToFront();
                }
            }
        }

        private void VerificaCoalisao3()
        {
            if (pcbPersonagem.Bounds.IntersectsWith(pcbChave1.Bounds))
            {
                this.Controls.Remove(pcbChave1);
                hasKey1 = true;
            }
            if (pcbPersonagem.Bounds.IntersectsWith(pcbChave2.Bounds))
            {
                this.Controls.Remove(pcbChave2);
                hasKey2 = true;
            }
            if (pcbPersonagem.Bounds.IntersectsWith(pcbChave3.Bounds))
            {
                this.Controls.Remove(pcbChave3);
                hasKey3 = true;
            }

        }

        private void VerificaCoalisao4()
        {
            if (pcbPersonagem.Bounds.IntersectsWith(pcbPorta1.Bounds) && hasKey1 == true)
            {
                pcbPorta1.Image = Properties.Resources.porta_aberta;
                SomPrincipal.controls.pause();
                JogoPrincipalTimer.Stop();
                frmCalculoInvaders a = new frmCalculoInvaders();
                a.ShowDialog();
                this.Controls.Remove(pcbPorta1);
                JogoPrincipalTimer.Start();
                QuantosMini++;
                SomPrincipal.controls.play();
                hasKey1 = false;

            }
            if (pcbPersonagem.Bounds.IntersectsWith(pcbPorta2.Bounds) && hasKey2 == true)
            {
                pcbPorta2.Image = Properties.Resources.porta_aberta;
                if(clsConfig.musicas == "on")
                    SomPrincipal.controls.stop();
                JogoPrincipalTimer.Stop();

                this.Controls.Remove(pcbPorta2);
                JogoPrincipalTimer.Start();
                QuantosMini++;
                if(clsConfig.musicas == "on")
                    SomPrincipal.controls.play();
                hasKey2 = false;

            }
            if (pcbPersonagem.Bounds.IntersectsWith(pcbPorta3.Bounds) && hasKey3 == true)
            {
                pcbPorta3.Image = Properties.Resources.porta_aberta;
                if(clsConfig.musicas == "on")
                    SomPrincipal.controls.stop();
                JogoPrincipalTimer.Stop();

                this.Controls.Remove(pcbPorta3);
                JogoPrincipalTimer.Start();
                QuantosMini++;
                if(clsConfig.musicas == "on")
                    SomPrincipal.controls.play();
                hasKey3 = false;

            }
        }

        void VerificaColisao5(Control x)
        {
            if (x is PictureBox && (string)x.Tag == "laser")
            {
                foreach (Control y in this.Controls)
                {
                    if (y is PictureBox && ((string)y.Tag == "plataforma" || (string)y.Tag == "parede"))
                    {
                        if (x.Bounds.IntersectsWith(y.Bounds))
                        {
                            this.Controls.Remove(x);
                            atira = false;
                        }
                    }
                }
            }
        }

        private void VerificaCoalisao6()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "plataforma" || x is PictureBox && (string)x.Tag == "lava")
                {
                    if (pcbPersonagem.Bounds.IntersectsWith(x.Bounds) && jumping == false)
                    {
                        forca = 8;
                        pcbPersonagem.Top = x.Top - pcbPersonagem.Height;
                        velocidadePulo = 0;
                    }

                    x.BringToFront();
                }
            }
        }

        void verificaColisaoInimigo(Control x)
        {
            if (x is PictureBox && (string)x.Tag == "inimigo")
            {
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
                            atira = false;
                        }
                    }
                }
            }
        }

        private void criaLaser(string laserTag)
        {

            PictureBox laser = new PictureBox();
            laser.Image = Properties.Resources.laser2;
            laser.Size = new Size(50, 16);
            laser.Tag = laserTag;
            laser.Top = pcbPersonagem.Top + 20;

            if (sentidoDireita == true)
            {
                laser.Left = pcbPersonagem.Left + pcbPersonagem.Width;
            }
            else
            {
                laser.Left = pcbPersonagem.Left - 40;
            }
            this.Controls.Add(laser);
            laser.BringToFront();
        }

        private void ImuneDano()
        {
            tempoimune++;

            if (imune == true && tempoimune < 60)
            {
                pcbPersonagem.BackColor = Color.Red;
                pcbPersonagem.Visible = true;

                if (tempoimune % 2 == 0)
                {
                    pcbPersonagem.Visible = false;
                }
            }
            else
            {
                pcbPersonagem.Visible = true;
                pcbPersonagem.BackColor = Color.Transparent;
                imune = false;
                tempoimune = 0;
            }
        }

        private void GanhaouMorre()
        {
            clsConfig.pontosPrincipal = score;
            if (vidas < 0)
            {
                if(clsConfig.musicas == "on")  
                    SomPrincipal.controls.stop();
                JogoPrincipalTimer.Stop();
                if (clsConfig.sons == "of")
                {
                    gameOverSound.URL = "gameOver.mp3";
                    gameOverSound.controls.play();
                }
                
                frmGameOver f = new frmGameOver();
                f.ShowDialog();

                if (f.DialogResult == DialogResult.Yes)
                    Application.Restart();
               if(f.DialogResult == DialogResult.No)
                    this.Close();
            }
            else if (QuantosMini == 3)
            {
                if(clsConfig.musicas == "on")
                    SomPrincipal.controls.stop();
                JogoPrincipalTimer.Stop();
                if (clsConfig.sons == "on")
                {
                    winSound.URL = "winSound.mp3";
                    winSound.controls.play();
                }
                
                
                frmGameOver f = new frmGameOver();
                f.ShowDialog();

                if(f.DialogResult == DialogResult.No)
                    this.Close();

            }
           
        }

        private void InimigoAtira()
        {
            if (atirainimigo == true)
            {
                PictureBox laserinimigo1 = new PictureBox();
                laserinimigo1.Image = Properties.Resources.laser2;
                laserinimigo1.Size = new Size(50, 16);
                laserinimigo1.Tag = "laserinimigo1";
                laserinimigo1.Top = pcbIntegral1.Top + 20;
                
                PictureBox laserinimigo2 = new PictureBox();
                laserinimigo2.Image = Properties.Resources.laser2;
                laserinimigo2.Size = new Size(50, 16);
                laserinimigo2.Tag = "laserinimigo2";
                laserinimigo2.Top = pcbIntegral1.Top + 20;


                laserinimigo1.Left = pcbIntegral1.Left + pcbIntegral1.Width;


                laserinimigo2.Left = pcbIntegral1.Left - 40;

                this.Controls.Add(laserinimigo1);
                laserinimigo1.BringToFront();
                this.Controls.Add(laserinimigo2);
                laserinimigo2.BringToFront();
                atirainimigo = false;
            }

            foreach (Control x in this.Controls)
            {

                verificaColisaoInimigo(x);
                if (x is PictureBox && (string)x.Tag == "laserinimigo1")
                {

                    x.Left += 20;
                    if (x.Left > 600)
                    {
                        this.Controls.Remove(x);
                        atirainimigo = true;
                    }

                    VerificaColisao5(x);

                    if (sentidoDireita == false)
                    {
                        x.Left -= 20;
                        if (x.Left < 0)
                        {
                            this.Controls.Remove(x);
                            atira = false;
                        }

                        VerificaColisao5(x);
                    }
                }

            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "laserinimigo1")
                {
                    if (pcbPersonagem.Bounds.IntersectsWith(x.Bounds) && imune == false)
                    {
                        if (clsConfig.sons == "on")
                        {
                            SomDano.URL = "barulho_de_soco_.mp3";
                            SomDano.controls.play();
                        }
                        imune = true;
                        this.Controls.Remove(vida[vidas]);
                        vidas--;
                        atirainimigo = true;
                    }

                    x.BringToFront();
                }
            }
        }
    }
}
