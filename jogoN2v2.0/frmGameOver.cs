using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jogoN2v2._0
{
    public partial class frmGameOver : Form
    {
        public frmGameOver()
        {
            InitializeComponent();
            
            lblPointsMainGame.Text = "Jogo principal: " + clsConfig.pontosPrincipal;
            lblPointsInvaders.Text = "Jogo Invaders: " + clsConfig.pontosInvaders;
            lblPointsDino.Text = "Jogo Dinossauro: " + clsConfig.pontosDino;
            lblPointsPong.Text = "Jogo Pong: " + clsConfig.pontosPong;
            lblTotalPoints.Text = "Total: " + totalPontos();

            if(clsConfig.nome == "pacote")
                MessageBox.Show("Por seu nome ser pacote, você ganha 100 pontos!!!");
            enviaParaArquivo();
        }

        void enviaParaArquivo()
        {
            if (File.Exists("ranking.txt"))
            {
                string conteudo = $"{clsConfig.nome};{clsConfig.dificuldade};{totalPontos()}\n";
                File.AppendAllText("ranking.txt", conteudo);
            }
        }
        int totalPontos()
        {
            int hackNome = 0;
            if (clsConfig.nome == "pacote")
                hackNome = 100;
                
            return Convert.ToInt32(clsConfig.pontosPrincipal + clsConfig.pontosInvaders + clsConfig.pontosDino + clsConfig.pontosPong + hackNome);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }

        private void btnMenu_MouseMove(object sender, MouseEventArgs e)
        {
            btnMenu.BackColor = Color.White;
            btnMenu.ForeColor = Color.Black;
        }

        private void btnMenu_MouseLeave(object sender, EventArgs e)
        {
            btnMenu.BackColor = Color.Black;
            btnMenu.ForeColor = Color.White;
        }
    }
}
