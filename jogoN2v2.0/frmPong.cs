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

        WMPLib.WindowsMediaPlayer raquetada = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer trilha = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer pontosSom = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer gameOverSound = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer winSound = new WMPLib.WindowsMediaPlayer();

        bool vaiCima;
        bool vaiBaixo;
        int velocidade = MudaVelocidade();

        static int MudaVelocidade()
        {
            if (clsConfig.dificuldade == "Easy")
            {
                return 20;
            }
            else if (clsConfig.dificuldade == "Normal")
            {
                return 30;
            }
            else if (clsConfig.dificuldade == "Hard")
            {
                return 40;
            }
            else
                return 0;
        }

        int xBola = 7;
        int yBola = 7;
        int pontos = 0;
        int pontosPC = 0;

        public frmPong()
        {
            frmTutorialPong t = new frmTutorialPong();
            t.ShowDialog();
            InitializeComponent();

            if(clsConfig.musicas == "on")
            {
                trilha.URL = "trilha.mp3";
                trilha.controls.play();
                trilha.settings.setMode("loop", true);
            }
            timer1.Start();
        }
        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                vaiCima = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                vaiBaixo = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                vaiCima = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                vaiBaixo = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblPointsPlayer.Text = "Wuo: " + pontos;
            lblPointsPC.Text = "Limites: " + pontosPC;

            pcbBall.Top -= yBola;
            pcbBall.Left -= xBola;
            pcbPc.Top += velocidade;

            if (pcbPc.Top < 0 || pcbPc.Top > 500)
            {
                velocidade *= -1;
            }

            ChecaColisaoBorda();
            ChecaColisaoBola();
            ChecaMovimentoPlayer();
            

            if (pontos == 5)
            {
                GameOver("O WUO VENCEU OS LIMITES!!!", "venceu");  
            }

            if (pontosPC == 5)
            {
                GameOver("O WUO NÃO SE SAFOU E PERDEU... F!", "perdeu");
            }
        }

        void ChecaColisaoBorda()
        {
            if (pcbBall.Left < 0)
            {
                pcbBall.Left = 400;
                xBola = -xBola;
                xBola -= 2;
                pontosPC++;

                MarcaPonto();
            }

            if (pcbBall.Left + pcbBall.Width > 800)
            {
                pcbBall.Left = 400;
                xBola = -xBola;
                xBola += 2;
                pontos++;

                MarcaPonto();
            }
        }

        void MarcaPonto()
        {
            if (clsConfig.sons == "on")
            {
                pontosSom.URL = "ponto.mp3";
                pontosSom.controls.play();
            }
        }

        void GameOver(string mensagem, string condicao)
        {
            timer1.Stop();
            if (clsConfig.sons == "on")
            {
                trilha.controls.stop();
                if (condicao == "perdeu")
                {
                    gameOverSound.URL = "gameOver.mp3";
                    gameOverSound.controls.play();
                }

                if(condicao == "venceu")
                {
                    trilha.controls.stop();
                    winSound.URL = "winSound.mp3";
                    winSound.controls.play();
                }
            }
            clsConfig.pontosPong = pontos;
            MessageBox.Show(mensagem);
            this.Close();

        }
        
        void ChecaColisaoBola()
        {
            if (pcbBall.Top < 0 || pcbBall.Top + pcbBall.Height > 600)
                yBola *= -1;

            if (pcbBall.Bounds.IntersectsWith(pcbPlayer.Bounds) || pcbBall.Bounds.IntersectsWith(pcbPc.Bounds))
            {
                xBola *= -1;
                if (clsConfig.sons == "on")
                {
                    raquetada.URL = "raquetada.mp3";
                    raquetada.controls.play();
                }
            }
        }

        void ChecaMovimentoPlayer()
        {
            if (vaiCima == true && pcbPlayer.Top > 0)
            {
                pcbPlayer.Top -= 15;
            }

            if (vaiBaixo == true && pcbPlayer.Top < 500)
            {
                pcbPlayer.Top += 15;
            }
        }
    }
}

