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
        bool mutedSound = false;
        bool mutedMusic = false;
        WMPLib.WindowsMediaPlayer menuSound = new WMPLib.WindowsMediaPlayer();

        public frmOptions()
        {
            InitializeComponent();
            panelSoundsOptions.BackColor = Color.Transparent;

            btnMusic.Parent = panelSoundsOptions;
            btnMusic.BackColor = Color.Transparent;

            btnSounds.Parent = panelSoundsOptions;
            btnSounds.BackColor = Color.Transparent;

            lblDificuldade.Text = clsConfig.difficulty;

            VerifySound();
            VerifyMusic();

            foreach(Control x in Controls)
            {
                if (x is Button)
                    x.Cursor = Cursors.Hand;
            }
        }

        void VerifySound()
        {
            if (clsConfig.sounds == "on")
            {
                btnSounds.BackgroundImage = Properties.Resources.switch_on;
                mutedSound = false;
            }
            else if (clsConfig.sounds == "off")
            {
                btnSounds.BackgroundImage = Properties.Resources.switch_off;
                mutedSound = true;
            }
        }

        void VerifyMusic()
        {
            if (clsConfig.music == "on")
            {
                btnMusic.BackgroundImage = Properties.Resources.switch_on;
                mutedMusic = false;
            }
            else if (clsConfig.music == "off")
            {
                btnMusic.BackgroundImage = Properties.Resources.switch_off;
                mutedMusic = true;
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
            if (mutedSound == false)
            {
                btnSounds.BackgroundImage = Properties.Resources.switch_off;
                mutedSound = true;
            }
            else if (mutedSound == true)
            {
                btnSounds.BackgroundImage = Properties.Resources.switch_on;
                mutedSound = false;
            }
        }

        private void btnMusica_Click(object sender, EventArgs e)
        {
            if (mutedMusic == false)
            {
                btnMusic.BackgroundImage = Properties.Resources.switch_off;
                mutedMusic = true;
            }
            else if (mutedMusic == true)
            {
                btnMusic.BackgroundImage = Properties.Resources.switch_on;
                mutedMusic = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsConfig.difficulty = lblDificuldade.Text;
            ChangeMusic();
            ChangeSound();

            this.Close();
        }

        void ChangeMusic()
        {
            if (mutedMusic)
            {
                clsConfig.music = "off";

            }
            else
            {
                clsConfig.music = "on";
            }
        }

        void ChangeSound()
        {
            if (mutedSound)
                clsConfig.sounds = "off";
            else
                clsConfig.sounds = "on";
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
