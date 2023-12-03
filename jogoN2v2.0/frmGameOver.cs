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
            
            lblPointsMainGame.Text = "Main Game: " + clsConfig.pointsMainGame;
            lblPointsInvaders.Text = "Calculus Invaders: " + clsConfig.pointsInvaders;
            lblPointsDino.Text = "Dinossaur Game: " + clsConfig.pointsDino;
            lblPointsPong.Text = "Pong Game: " + clsConfig.pointsPong;
            lblTotalPoints.Text = "Total: " + TotalPoints();

            //a brazilian easter egg xD
            if(clsConfig.name == "pacote")
                MessageBox.Show("Because your name is pacote, you get more 100 points!!!");
            SendToFile();
        }

        void SendToFile()
        {
            if (File.Exists("ranking.txt"))
            {
                string content = $"{clsConfig.name};{clsConfig.difficulty};{TotalPoints()}\n";
                File.AppendAllText("ranking.txt", content);
            }
        }
        int TotalPoints()
        {
            int nameGlitch = 0;
            if (clsConfig.name == "pacote")
                nameGlitch = 100;
                
            return Convert.ToInt32(clsConfig.pointsMainGame + clsConfig.pointsInvaders + clsConfig.pointsDino + clsConfig.pointsPong + nameGlitch);
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
