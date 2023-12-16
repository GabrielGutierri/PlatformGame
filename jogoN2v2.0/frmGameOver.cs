using jogoN2v2._0.Constants;
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
            SetGameOverLabels();
            //a brazilian easter egg xD
            if (clsConfig.name == GameOverConstants.PACOTE_EASTER_EGG)
                MessageBox.Show(GameOverConstants.PACOTE_MESSAGE);
            SendToFile();
        }

        private void SetGameOverLabels()
        {
            lblPointsMainGame.Text = MainGameConstants.TITLE + ": " + clsConfig.pointsMainGame;
            lblPointsInvaders.Text = CalculusInvadersConstants.TITLE + ": " + clsConfig.pointsInvaders;
            lblPointsDino.Text = DinoGameConstants.TITLE + ": " + clsConfig.pointsDino;
            lblPointsPong.Text = PongConstants.TITLE + ": " + clsConfig.pointsPong;
            lblTotalPoints.Text = GameConstants.TOTAL + ": " + TotalPoints();
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
            if (clsConfig.name == GameOverConstants.PACOTE_EASTER_EGG)
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
