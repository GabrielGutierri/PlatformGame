using jogoN2v2._0.Constants;
using jogoN2v2._0.Utils;
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
    public partial class frmDinoGame : Form
    {
        WMPLib.WindowsMediaPlayer jump = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer backgroundSound = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer hit = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer gameOverSound = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer winSound = new WMPLib.WindowsMediaPlayer();

        private bool jumping = false;
        private int jumpSpeed = 10;
        private int force = 12;
        private int score = 0;
        private int obstacleSpeed = 10;
        private Random rand = new Random();
        private int position;
        private bool isGameOver = true;
        private int lifes = 3;
        private int record = 0;

        public frmDinoGame()
        {
            frmTutorialDino f = new frmTutorialDino();
            f.ShowDialog();
            InitializeComponent();
            InitializeMusic();
            txtScore.Text = DinoGameConstants.INTRO_MESSAGE;
        }

        private void InitializeMusic()
        {
            if (clsConfig.music == ConfigurationConstants.MUSIC_ON)
            {
                GameUtils.PlayTrack(DinoGameConstants.BACKGROUND_SOUND_TRACK, backgroundSound);
                backgroundSound.settings.setMode("loop", true);
                backgroundSound.settings.volume = 10;
            }
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            pcbWuo.Top += jumpSpeed;
            SetInfoLabels();
            Jump();
            ControlsRoutine();
            CheckJumping();
            IncreaseSpeed();
            CheckVictory();

        }

        private void CheckJumping()
        {
            if (pcbWuo.Top >= 240 && !jumping)
            {
                force = 12;
                pcbWuo.Top = pcbFloor.Top - pcbWuo.Height;
                jumpSpeed = 0;
            }
        }

        private void ControlsRoutine()
        {
            foreach (Control z in this.Controls)
            {
                if (z is PictureBox && z.Tag == DinoGameConstants.OBSTACLE_TAG)
                {
                    z.Left -= obstacleSpeed;
                    if (z.Left + z.Width < -120)
                    {
                        z.Left = this.ClientSize.Width + rand.Next(200, 800);
                        score++;
                    }
                    VerifyCollision(z);
                }
            }
        }

        private void SetInfoLabels()
        {
            txtScore.Text = $"{GameConstants.POINTS}: " + score;
            txtLifes.Text = $"{GameConstants.LIFES}: " + lifes;
            txtRecord.Text = $"{GameConstants.BEST_ROUND}: " + record;
        }

        void Jump()
        {
            if (jumping && force < 0)
            {
                jumping = false;
            }
            //jump
            if (jumping)
            {
                jumpSpeed = -12;
                force -= 1;
            }
            //fall
            else
            {
                jumpSpeed = 12;
            }
        }

        void VerifyCollision(Control z)
        {
            if (pcbWuo.Bounds.IntersectsWith(z.Bounds))
            {
                timer.Stop();
                GameUtils.PlayTrack(DinoGameConstants.HIT_SOUND_TRACK, hit);
                pcbWuo.Image = Properties.Resources.imagem_wuo_2;
                txtScore.Text += $"  {DinoGameConstants.RESTART_MESSAGE}";
                backgroundSound.controls.stop();
                lifes--;
                isGameOver = true;
            }
        }

        void IncreaseSpeed()
        {
            if (score >= 5)
            {
                if (clsConfig.difficulty == ConfigurationConstants.EASY)
                    obstacleSpeed = 15;
                else if (clsConfig.difficulty == ConfigurationConstants.NORMAL)
                    obstacleSpeed = 20;
            }
            else if (score >= 10)
                obstacleSpeed = 35;
            else
                obstacleSpeed = 25;
        }

        void CheckVictory()
        {
            if (score == 15 && (clsConfig.difficulty == ConfigurationConstants.EASY || clsConfig.difficulty == ConfigurationConstants.NORMAL))
            {
                WinRoutine();
                clsConfig.pointsDino = 15;
                this.Close();
            }
            else if (score == 20 && clsConfig.difficulty == ConfigurationConstants.HARD)
            {
                WinRoutine();
                clsConfig.pointsDino = 20;
                this.Close();
            }
        }

        void WinRoutine()
        {
            timer.Stop();
            pcbWuo.Image = Properties.Resources.imagem_wuo_2;
            MessageBox.Show(DinoGameConstants.WIN_MESSAGE);
            backgroundSound.controls.stop();
            GameUtils.PlayTrack(DinoGameConstants.WIN_SOUND_TRACK, winSound);
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;
                if (clsConfig.sounds == ConfigurationConstants.MUSIC_ON)
                {
                    GameUtils.PlayTrack(DinoGameConstants.JUMP_SOUND_TRACK, jump);
                    jump.settings.volume = 100;
                }
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (jumping == true)
            {
                jumping = false;
            }
            if (e.KeyCode == Keys.R && isGameOver == true)
            {
                timer.Stop();
                VerifyRecord(lifes, score);
                CheckLifes();
                GameReset();
            }
        }

        private void CheckLifes()
        {
            if (lifes == 0)
            {
                GameUtils.PlayTrack(DinoGameConstants.GAMEOVER_SOUND_TRACK, gameOverSound);
                backgroundSound.controls.stop();
                MessageBox.Show($"{DinoGameConstants.NO_LIFES_MESSAGE}: {record}");
                clsConfig.pointsDino = record;
                this.Close();
            }
        }

        void VerifyRecord(int lifes, int score)
        {
            if (lifes == 3)
                record = score;
            else if (score > record)
                record = score;
        }

        private void GameReset()
        {
            SetResetVariables();
            //wuo.Top = 260;
            ResetControls();
            timer.Start();
            backgroundSound.controls.play();
        }

        private void ResetControls()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == DinoGameConstants.OBSTACLE_TAG)
                {
                    int position = rand.Next(600, 1000);
                    x.Left = 640 + (x.Left + position + x.Width * 3);
                    /*
                    position = this.ClientSize.Width + rand.Next(10, 100) + (x.Width * 10);
                    x.Left = position;
                    */
                }
            }
        }

        private void SetResetVariables()
        {
            force = 12;
            jumpSpeed = 10;
            jumping = false;
            score = 0;
            obstacleSpeed = DifficultySpeed();
            txtScore.Text = $"{GameConstants.POINTS}:" + score;
            pcbWuo.Image = Properties.Resources.jogowuogif;
            isGameOver = false;
        }

        private int DifficultySpeed()
        {
            switch (clsConfig.difficulty)
            {
                case ConfigurationConstants.EASY:
                    return 10;
                case ConfigurationConstants.NORMAL:
                    return 15;
                case ConfigurationConstants.HARD:
                    return 20;
                default:
                    return 0;
            }
        }
    }
}
