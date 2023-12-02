﻿using System;
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
    public partial class frmHomeScreen : Form
    {
        WMPLib.WindowsMediaPlayer menuSound = new WMPLib.WindowsMediaPlayer();
        bool mudo = false;

        public frmHomeScreen()
        {
            frmLoadingGame f = new frmLoadingGame();
            f.ShowDialog();
            menuSound.URL = "menu_2.mp3";
            if (clsConfig.musicas == "on")
            {
                menuSound.controls.play();
                menuSound.settings.setMode("loop", true);
                menuSound.settings.volume = 10;
            }
            else if (clsConfig.musicas == "off")
                menuSound.controls.stop();
            InitializeComponent();
            foreach (Control c in Controls)
            {
                if (c is Button)
                {
                    c.Cursor = Cursors.Hand;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
                MessageBox.Show("Erro!");
            else
            {
                if (mudo == false)
                {
                    menuSound.URL = "menu_2.mp3";
                    menuSound.controls.stop();
                }

                clsConfig.nome = txtName.Text;
                frmMainGame f = new frmMainGame();
                f.ShowDialog();
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            frmOptions f = new frmOptions();
            f.ShowDialog();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
           
        }

        private void btnSound_Click(object sender, EventArgs e)
        {

            if (mudo == false)
            {
                btnSound.BackgroundImage = Properties.Resources.sound_icon;
                mudo = true;
                menuSound.URL = "menu_2.mp3";
                menuSound.controls.stop();

            }

            else if (mudo == true)
            {
                btnSound.BackgroundImage = Properties.Resources.mute_icon;
                mudo = false;
                menuSound.URL = "menu_2.mp3";
                menuSound.controls.play();
                menuSound.settings.setMode("loop", true);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmRanking f = new frmRanking();
            f.Show();
        }

        private void btnJogar_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void btnJogar_MouseMove(object sender, MouseEventArgs e)
        {
            btnPlay.BackColor = Color.White;
            btnPlay.ForeColor = Color.DarkRed;
        }

        private void btnJogar_MouseLeave(object sender, EventArgs e)
        {
            btnPlay.BackColor = Color.DarkRed;
            btnPlay.ForeColor = Color.White;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmHelp t = new frmHelp();
            t.Show();
        }
    }
}

