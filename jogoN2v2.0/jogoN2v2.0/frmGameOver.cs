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
            
            lblPontosPrincipal.Text = "Jogo principal: " + clsConfig.pontosPrincipal;
            lblPontosInvaders.Text = "Jogo Invaders: " + clsConfig.pontosInvaders;
            lblTotal.Text = "Total: " + totalPontos();

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
            return Convert.ToInt32(clsConfig.pontosPrincipal + clsConfig.pontosInvaders);
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
