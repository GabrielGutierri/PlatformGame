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
    public partial class frmOptions : Form
    {
        bool somMutado = false;
        bool musicaMutado = false;
        WMPLib.WindowsMediaPlayer menuSound = new WMPLib.WindowsMediaPlayer();

        public frmOptions()
        {
            InitializeComponent();
            panelSoundsOptions.BackColor = Color.Transparent;

            btnMusic.Parent = panelSoundsOptions;
            btnMusic.BackColor = Color.Transparent;

            btnSounds.Parent = panelSoundsOptions;
            btnSounds.BackColor = Color.Transparent;

            lblDificuldade.Text = clsConfig.dificuldade;

            VerificaSom();
            VerificaMusica();

            foreach(Control x in Controls)
            {
                if (x is Button)
                    x.Cursor = Cursors.Hand;
            }
        }

        void VerificaSom()
        {
            if (clsConfig.sons == "on")
            {
                btnSounds.BackgroundImage = Properties.Resources.switch_on;
                somMutado = false;
            }
            else if (clsConfig.sons == "off")
            {
                btnSounds.BackgroundImage = Properties.Resources.switch_off;
                somMutado = true;
            }
        }

        void VerificaMusica()
        {
            if (clsConfig.musicas == "on")
            {
                btnMusic.BackgroundImage = Properties.Resources.switch_on;
                musicaMutado = false;
            }
            else if (clsConfig.musicas == "off")
            {
                btnMusic.BackgroundImage = Properties.Resources.switch_off;
                musicaMutado = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (lblDificuldade.Text == "Normal")
                lblDificuldade.Text = "Hard";
            else if (lblDificuldade.Text == "Hard")
                lblDificuldade.Text = "Easy";
            else if (lblDificuldade.Text == "Easy")
                lblDificuldade.Text = "Normal";
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (lblDificuldade.Text == "Normal")
                lblDificuldade.Text = "Easy";
            else if (lblDificuldade.Text == "Hard")
                lblDificuldade.Text = "Normal";
            else if (lblDificuldade.Text == "Easy")
                lblDificuldade.Text = "Hard";
        }

        private void btnSons_Click(object sender, EventArgs e)
        {
            if (somMutado == false)
            {
                btnSounds.BackgroundImage = Properties.Resources.switch_off;
                somMutado = true;
            }
            else if (somMutado == true)
            {
                btnSounds.BackgroundImage = Properties.Resources.switch_on;
                somMutado = false;
            }
        }

        private void btnMusica_Click(object sender, EventArgs e)
        {
            if (musicaMutado == false)
            {
                btnMusic.BackgroundImage = Properties.Resources.switch_off;
                musicaMutado = true;
            }
            else if (musicaMutado == true)
            {
                btnMusic.BackgroundImage = Properties.Resources.switch_on;
                musicaMutado = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clsConfig.dificuldade = lblDificuldade.Text;
            alteraMusica();
            alteraSom();

            this.Close();
        }

        void alteraMusica()
        {
            if (musicaMutado)
            {
                clsConfig.musicas = "off";

            }
            else
            {
                clsConfig.musicas = "on";
            }
        }

        void alteraSom()
        {
            if (somMutado)
                clsConfig.sons = "off";
            else
                clsConfig.sons = "on";
        }

        void Move(Button bt)
        {
            bt.BackColor = Color.White;
            bt.ForeColor = Color.DarkRed;
        }

        void Leave(Button bt)
        {
            bt.BackColor = Color.DarkRed;
            bt.ForeColor = Color.White;
        }

        private void btnPrev_MouseMove(object sender, MouseEventArgs e)
        {
            Move(btnPrev);
        }

        private void btnPrev_MouseLeave(object sender, EventArgs e)
        {
            Leave(btnPrev);
        }

        private void btnNext_MouseMove(object sender, MouseEventArgs e)
        {
            Move(btnNext);
        }

        private void btnNext_MouseLeave(object sender, EventArgs e)
        {
            Leave(btnNext);
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            Move(btnSave);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            Leave(btnSave);
        }
    }
}
