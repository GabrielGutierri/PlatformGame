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
    public partial class frmMainGame : Form
    {
        WMPLib.WindowsMediaPlayer SomInfinito = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer SomPulo = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer SomDano = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer gameOverSound = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer winSound = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer SomPrincipal = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer laserSom = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer enemyDestroyed = new WMPLib.WindowsMediaPlayer();
        string somaLetras = "";
        bool goRight, goLeft, jumping, hasKey1, hasKey2, hasKey3, parede, atira, sentidoDireita = true, imune = false, atirainimigo = true, 
            movimentaimagemdirecao, infinitoligado = false, soumavez = false;
        int velocidadePulo = 10, velocidadeJogador = 2, forca = 8, score = 0, FundoTela = 16, vidas, QuantosMini = 0, tempoimune = 0, movimentaimagem, laserInimigoTimer, tempo;
        PictureBox[] vida = new PictureBox[6];
        public frmMainGame()
        {
            frmCutScene f = new frmCutScene();
            f.ShowDialog();
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
            vida[4] = pcbCoracao4;
            vida[5] = pcbCoracao5;

            Dificuldade();
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score;
            pcbPersonagem.Top += velocidadePulo;

            MovimentaçãoPersonagem();
            MovimentacaoJogo();
            MoveGameElements4();
            VerificaColisao1();
            VerificaColisao2();
            VerificaColisao3();
            VerificaColisao4();
            VerificaColisao6();
            VerificaColisao7();

            foreach (Control x in this.Controls)
            {

                VerificaColisaoInimigo(x);
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

            laserInimigoTimer -= 10;
            if (laserInimigoTimer < 10)
            {
                laserInimigoTimer = tempo;
                CriaLaser("laserinimigo1");
            }

            InimigoAtira();
            Morre();
            Ganha();
            ImuneDano();
        }

        void Dificuldade()
        {
            if (clsConfig.dificuldade == "Easy")
            {
                vidas = 5;
                tempo = 1200;
            }
            else if (clsConfig.dificuldade == "Normal")
            {
                tempo = 1000;
                vidas = 3;
                this.Controls.Remove(pcbCoracao5);
                this.Controls.Remove(pcbCoracao4);
            }
            else if (clsConfig.dificuldade == "Hard")
            {
                tempo = 500;
                vidas = 1;
                this.Controls.Remove(pcbCoracao5);
                this.Controls.Remove(pcbCoracao4);
                this.Controls.Remove(pcbCoracao3);
                this.Controls.Remove(pcbCoracao2);
            }
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
                CriaLaser("laser");
            }

            somaLetras += Convert.ToChar(e.KeyValue);
            if (somaLetras.ToUpper().Contains("IDKIDNL") && soumavez == false)
            {
                if (clsConfig.sons == "on")
                {
                    SomInfinito.URL = "som-upgrade.mp3";
                    SomInfinito.controls.play();
                }
                pcbInfinito.Visible = true;

                this.Controls.Remove(pcbCoracao5);
                this.Controls.Remove(pcbCoracao4);
                this.Controls.Remove(pcbCoracao3);
                this.Controls.Remove(pcbCoracao2);
                this.Controls.Remove(pcbCoracao1);

                infinitoligado = true;
                soumavez = true;

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
                    x.BackColor = Color.Transparent;
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
                if (x is PictureBox && (string)x.Tag == "porta" || x is PictureBox && (string)x.Tag == "parede" || x is PictureBox && (string)x.Tag == "lava")
                {
                    x.BackColor = Color.Transparent;
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
                if (x is PictureBox && (string)x.Tag == "inimigo" )
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
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "inimigo")
                {
                    int i = 4;

                    if (movimentaimagem == 0)
                    {
                        movimentaimagemdirecao = true;
                    }
                    else if (movimentaimagem == 150)
                    {
                        movimentaimagemdirecao = false;
                    }

                    if (movimentaimagemdirecao == true)
                    {
                        x.Left += i;
                        movimentaimagem++;
                    }
                    else
                    {
                        x.Left -= i;
                        movimentaimagem--;
                    }
                }
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
            if (goLeft == true && pcbPlataforma.Left < 0 && parede == false)
            {
                MoveGameElements1("forward");
                MoveGameElements2("forward");
                MoveGameElements3("forward");
            }
            if (goRight == true && pcbPlataforma.Left > -2120 && parede == false)
            {
                MoveGameElements1("back");
                MoveGameElements2("back");
                MoveGameElements3("back");

                if (pcbPlataforma.Left < -2100)
                {
                    velocidadeJogador = 10;
                }
                else
                {
                    velocidadeJogador = 2;
                }
            }
        }

        private void VerificaColisao1()
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

        private void VerificaColisao2()
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

                        if (infinitoligado == false)
                        {
                            this.Controls.Remove(vida[vidas]);
                            vidas--;
                        }
                    }

                    x.BringToFront();
                }
            }
        }

        private void VerificaColisao3()
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

        private void VerificaColisao4()
        {
            if (pcbPersonagem.Bounds.IntersectsWith(pcbPorta1.Bounds) && hasKey1 == true)
            {
                pcbPorta1.Image = Properties.Resources.porta_aberta;
                if(clsConfig.musicas == "on")
                    SomPrincipal.controls.pause();
                JogoPrincipalTimer.Stop();
                frmCalculusInvaders a = new frmCalculusInvaders();
                a.ShowDialog();
                this.Controls.Remove(pcbPorta1);
                JogoPrincipalTimer.Start();
                QuantosMini++;
                if(clsConfig.musicas == "on")
                    SomPrincipal.controls.play();
                hasKey1 = false;
                pcbPersonagem.Left = pcbPersonagem.Left;

            }
            if (pcbPersonagem.Bounds.IntersectsWith(pcbPorta2.Bounds) && hasKey2 == true)
            {
                pcbPorta2.Image = Properties.Resources.porta_aberta;
                if(clsConfig.musicas == "on")
                    SomPrincipal.controls.pause();
                JogoPrincipalTimer.Stop();
                frmDinoGame b = new frmDinoGame();
                b.ShowDialog();
                this.Controls.Remove(pcbPorta2);
                JogoPrincipalTimer.Start();
                QuantosMini++;
                if(clsConfig.musicas == "on")
                    SomPrincipal.controls.play();
                hasKey2 = false;
                pcbPersonagem.Left = pcbPersonagem.Left;
            }
        }

        private void VerificaColisao7()
        {
            if (pcbPersonagem.Bounds.IntersectsWith(pcbPorta3.Bounds) && hasKey3 == true)
            {
                pcbPorta3.Image = Properties.Resources.porta_aberta;
                if (clsConfig.musicas == "on")
                    SomPrincipal.controls.pause();
                JogoPrincipalTimer.Stop();
                frmPong c = new frmPong();
                c.ShowDialog();
                this.Controls.Remove(pcbPorta3);
                JogoPrincipalTimer.Start();
                QuantosMini++;
                if (clsConfig.musicas == "on")
                    SomPrincipal.controls.play();
                hasKey3 = false;
                pcbPersonagem.Left = pcbPersonagem.Left;
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

        private void VerificaColisao6()
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

        void VerificaColisaoInimigo(Control x)
        {
            if (x is PictureBox && (string)x.Tag == "inimigo" )
            {
                foreach (Control y in this.Controls)
                {
                    if (y is PictureBox && (string)y.Tag == "laser")
                    {
                        if (y.Bounds.IntersectsWith(x.Bounds))
                        {
                            if (clsConfig.sons == "on")
                            {
                                enemyDestroyed.URL = "enemyDestroyed2.mp3";
                                enemyDestroyed.controls.play();
                            }
                            x.Visible = false;
                            this.Controls.Remove(x);
                            this.Controls.Remove(y);
                            atira = false;
                        }
                    }
                }
            }
        }

        private void CriaLaser(string laserTag)
        {
            

            if (laserTag == "laser" && sentidoDireita == true)
            {
                PictureBox laser = new PictureBox();
                laser.Image = Properties.Resources.laser2;
                laser.Size = new Size(50, 16);
                laser.Tag = laserTag;
                laser.Top = pcbPersonagem.Top + 40;
                laser.Left = pcbPersonagem.Left + pcbPersonagem.Width;
                laser.BackColor = Color.Transparent;

                this.Controls.Add(laser);
                laser.BringToFront();
            }
            else if(laserTag == "laser" && sentidoDireita == false)
            {
                PictureBox laser = new PictureBox();
                laser.Image = Properties.Resources.laser2;
                laser.Size = new Size(50, 16);
                laser.Tag = laserTag;
                laser.Top = pcbPersonagem.Top + 40;
                laser.Left = pcbPersonagem.Left - 40;
                laser.BackColor = Color.Transparent;

                this.Controls.Add(laser);
                laser.BringToFront();
            }
            else if(laserTag == "laserinimigo1" && atirainimigo == true)
            {
                if (pcbLimite2.Visible == true)
                {
                    PictureBox laser = new PictureBox();
                    laser.Size = new Size(50, 16);
                    laser.Tag = laserTag;
                    laser.Image = Properties.Resources.laser3;
                    laser.Left = pcbLimite2.Left - 10;
                    laser.Top = pcbLimite2.Top + 20;
                    laser.BackColor = Color.Transparent;
                    atirainimigo = false;

                    this.Controls.Add(laser);
                    laser.BringToFront();
                }

                if (pcbLimite3.Visible == true)
                {
                    PictureBox laser2 = new PictureBox();
                    laser2.Image = Properties.Resources.laser3;
                    laser2.Size = new Size(50, 16);
                    laser2.Tag = laserTag;
                    laser2.BackColor = Color.Transparent;
                    laser2.Left = pcbLimite3.Left - 10;
                    laser2.Top = pcbLimite3.Top + 20;
                    atirainimigo = false;

                    this.Controls.Add(laser2);
                    laser2.BringToFront();
                }
            }
          
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

        private void Morre()
        {
            clsConfig.pontosPrincipal = score;
            if (vidas <= 0 && infinitoligado == false)
            {
                if (clsConfig.musicas == "on")
                    SomPrincipal.controls.stop();
                JogoPrincipalTimer.Stop();
                if (clsConfig.sons == "on")
                {
                    gameOverSound.URL = "gameOver.mp3";
                    gameOverSound.controls.play();
                }

                frmGameOver f = new frmGameOver();
                f.ShowDialog();

                if (f.DialogResult == DialogResult.No)
                    this.Close();
            }
        }

        private void Ganha()
        {
            if (QuantosMini == 3)
            {
                if (clsConfig.musicas == "on")
                    SomPrincipal.controls.stop();
                JogoPrincipalTimer.Stop();
                if (clsConfig.sons == "on")
                {
                    winSound.URL = "winSound.mp3";
                    winSound.controls.play();
                }

                frmGameOver f = new frmGameOver();
                f.ShowDialog();

                if (f.DialogResult == DialogResult.No)
                    this.Close();
            }
        }

        private void InimigoAtira()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "laserinimigo1")
                {
                    x.Left -= 20;
                    if (x.Left < -100)
                    {
                        this.Controls.Remove(x);
                        atirainimigo = true;
                    }

                    foreach (Control y in this.Controls)
                    {
                        if (y is PictureBox && ((string)y.Tag == "plataforma" || (string)y.Tag == "parede"))
                        {
                            if (x.Bounds.IntersectsWith(y.Bounds))
                            {
                                this.Controls.Remove(x);
                                atirainimigo = true;
                            }
                        }
                    }
                }
            }

            InimgoDano();
        }

        private void InimgoDano()
        {
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

                        if (infinitoligado == false)
                        {
                            this.Controls.Remove(vida[vidas]);
                            vidas--;
                        }
                        atirainimigo = true;
                    }

                    x.BringToFront();
                }
            }
        }

    }
}
