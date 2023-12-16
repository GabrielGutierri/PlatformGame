using jogoN2v2._0.Constants;
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
        private bool mutedSound = false;
        private bool mutedMusic = false;
        WMPLib.WindowsMediaPlayer menuSound = new WMPLib.WindowsMediaPlayer();

        public frmOptions()
        {
            InitializeComponent();
            SetProperties();
            VerifySound();
            VerifyMusic();
            AddCursorHand();
        }

        private void AddCursorHand()
        {
            foreach (Control x in Controls)
            {
                if (x is Button)
                    x.Cursor = Cursors.Hand;
            }
        }

        private void SetProperties()
        {
            panelSoundsOptions.BackColor = Color.Transparent;

            btnMusic.Parent = panelSoundsOptions;
            btnMusic.BackColor = Color.Transparent;

            btnSounds.Parent = panelSoundsOptions;
            btnSounds.BackColor = Color.Transparent;

            lblDifficulty.Text = clsConfig.difficulty;
        }

        void VerifySound()
        {
            if (clsConfig.sounds == ConfigurationConstants.MUSIC_ON)
            {
                btnSounds.BackgroundImage = Properties.Resources.switch_on;
                mutedSound = false;
            }
            else if (clsConfig.sounds == ConfigurationConstants.MUSIC_OFF)
            {
                btnSounds.BackgroundImage = Properties.Resources.switch_off;
                mutedSound = true;
            }
        }

        void VerifyMusic()
        {
            if (clsConfig.music == ConfigurationConstants.MUSIC_ON)
            {
                btnMusic.BackgroundImage = Properties.Resources.switch_on;
                mutedMusic = false;
            }
            else if (clsConfig.music == ConfigurationConstants.MUSIC_OFF)
            {
                btnMusic.BackgroundImage = Properties.Resources.switch_off;
                mutedMusic = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (lblDifficulty.Text == ConfigurationConstants.NORMAL)
                lblDifficulty.Text = ConfigurationConstants.HARD;
            else if (lblDifficulty.Text == ConfigurationConstants.HARD)
                lblDifficulty.Text = ConfigurationConstants.EASY;
            else if (lblDifficulty.Text == ConfigurationConstants.EASY)
                lblDifficulty.Text = ConfigurationConstants.NORMAL;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (lblDifficulty.Text == ConfigurationConstants.NORMAL)
                lblDifficulty.Text = ConfigurationConstants.EASY;
            else if (lblDifficulty.Text == ConfigurationConstants.HARD)
                lblDifficulty.Text = ConfigurationConstants.NORMAL;
            else if (lblDifficulty.Text == ConfigurationConstants.EASY)
                lblDifficulty.Text = ConfigurationConstants.HARD;
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
            clsConfig.difficulty = lblDifficulty.Text;
            ChangeMusic();
            ChangeSound();

            this.Close();
        }

        void ChangeMusic()
        {
            if (mutedMusic)
            {
                clsConfig.music = ConfigurationConstants.MUSIC_OFF;

            }
            else
            {
                clsConfig.music = ConfigurationConstants.MUSIC_ON;
            }
        }

        void ChangeSound()
        {
            if (mutedSound)
                clsConfig.sounds = ConfigurationConstants.MUSIC_OFF;
            else
                clsConfig.sounds = ConfigurationConstants.MUSIC_ON;
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
