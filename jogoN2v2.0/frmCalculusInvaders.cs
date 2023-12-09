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
    public partial class frmCalculusInvaders : Form
    {
        private WMPLib.WindowsMediaPlayer laserSound = new WMPLib.WindowsMediaPlayer();
        private WMPLib.WindowsMediaPlayer enemyDestroyed = new WMPLib.WindowsMediaPlayer();
        private WMPLib.WindowsMediaPlayer invadersSound = new WMPLib.WindowsMediaPlayer();
        private WMPLib.WindowsMediaPlayer gameOverSound = new WMPLib.WindowsMediaPlayer();
        private WMPLib.WindowsMediaPlayer winSound = new WMPLib.WindowsMediaPlayer();

        private bool goLeft, goRight;
        private int characterSpeed = 12;
        private int enemySpeed = 0;
        private int points = 0;
        private int enemyLaserTimer = 300;
        private int record = 0;
        private PictureBox[] invadersVector;
        private bool shoot;
        private bool isGameOver;
        private int lifes = 3;


        public frmCalculusInvaders()
        {
            frmTutorialInvaders t = new frmTutorialInvaders();
            t.ShowDialog();
            InitializeComponent();
            CheckMusic();
            GameSetup();
        }

        void PlayTrack(string trackName, WMPLib.WindowsMediaPlayer sound)
        {
            if (clsConfig.sounds == ConfigurationConstants.MUSIC_ON)
            {
                sound.URL = trackName;
                sound.controls.play();
            }
        }

        private void CheckMusic()
        {
            if (clsConfig.music == ConfigurationConstants.MUSIC_ON)
            {
                PlayTrack(CalculusInvadersConstants.INVADERS_SOUND_TRACK, invadersSound);
                invadersSound.settings.setMode("loop", true);
            }
        }

        private void InvadersTimerEvent(object sender, EventArgs e)
        {
            SetInfoLabels();
            ChangePlayerSpeed();
            CheckEnemyLaserTimer();
            ControlsRoutine(this.Controls);
            CheckScore();
        }

        private void ControlsRoutine(Control.ControlCollection controls)
        {
            foreach (Control x in controls)
            {
                VerifyEnemyCollision(x);
                VerifyLaserCollision(x);
                VerifyEnemyLaserColision(x);
            }
        }

        private void CheckScore()
        {
            if (points > 8)
            {
                ChangeCharacterSpeed();
                ChangeEnemySpeed();
            }

            if (points == invadersVector.Length)
            {
                GameOver(CalculusInvadersConstants.DEFEATED_DERIVATIVES_MESSAGE);
            }
        }

        private void CheckEnemyLaserTimer()
        {
            enemyLaserTimer -= 10;
            if (enemyLaserTimer < 10)
            {
                enemyLaserTimer = 300;
                CreateLaserComponent(CalculusInvadersConstants.INVADER_LASER_TAG);
            }
        }

        private void SetInfoLabels()
        {
            lblPoints.Text = $"{CalculusInvadersConstants.POINTS}: {points}";
            lblLifes.Text = $"{CalculusInvadersConstants.LIFES}: {lifes}";
            lblRecord.Text = $"{CalculusInvadersConstants.BEST_ROUND}: {record}";
        }

        void ChangePlayerSpeed()
        {
            if (goLeft && pcbPlayer.Left > 0)
            {
                pcbPlayer.Left -= characterSpeed;
            }

            if (goRight && pcbPlayer.Left < 620)
            {
                pcbPlayer.Left += characterSpeed;
            }
        }
        void VerifyLaserCollision(Control x)
        {
            if (x is PictureBox && (string)x.Tag == CalculusInvadersConstants.LASER_TAG)
            {
                x.Top -= 20;
                if (x.Top < 15)
                {
                    this.Controls.Remove(x);
                    shoot = false;
                }
            }
        }
        void VerifyEnemyCollision(Control x)
        {
            if (x is PictureBox && (string)x.Tag == CalculusInvadersConstants.INVADER_TAG)
            {
                MoveInvader(x);

                if (x.Bounds.IntersectsWith(pcbPlayer.Bounds))
                {
                    GameOver(CalculusInvadersConstants.CAUGHT_BY_INVADERS);
                    lifes--;
                }
                foreach (Control y in this.Controls)
                {
                    ControlLaserRoutine(x, y);
                }
            }
        }

        private void ControlLaserRoutine(Control invaderControl, Control screenControl)
        {
            if (screenControl is PictureBox && (string)screenControl.Tag == CalculusInvadersConstants.LASER_TAG)
            {
                if (screenControl.Bounds.IntersectsWith(invaderControl.Bounds))
                {
                    PlayTrack(CalculusInvadersConstants.ENEMY_DESTROYED_TRACK, enemyDestroyed);
                    this.Controls.Remove(invaderControl);
                    this.Controls.Remove(screenControl);
                    points += 1;
                    shoot = false;
                }
            }
        }

        void MoveInvader(Control x)
        {
            x.Left += enemySpeed;
            if (x.Left > 730)
            {
                x.Top += 65;
                x.Left = -80;
            }
        }
        void VerifyEnemyLaserColision(Control x)
        {
            if (x is PictureBox && (string)x.Tag == CalculusInvadersConstants.INVADER_LASER_TAG)
            {
                MoveRemoveLaser(x);

                if (x.Bounds.IntersectsWith(pcbPlayer.Bounds))
                {
                    this.Controls.Remove(x);
                    GameOver(CalculusInvadersConstants.CAUGHT_BY_LASER_INVADER);
                    lifes--;
                }
            }
        }
        void MoveRemoveLaser(Control x)
        {
            x.Top += 20;
            if (x.Top > 620)
            {
                this.Controls.Remove(x);
            }
        }
        void ChangeCharacterSpeed()
        {
            switch (clsConfig.difficulty)
            {
                case ConfigurationConstants.EASY:
                    characterSpeed = CalculusInvadersConstants.EASY_CHARACTER_SPEED;
                    break;
                case ConfigurationConstants.NORMAL:
                    characterSpeed = CalculusInvadersConstants.NORMAL_CHARACTER_SPEED;
                    break;
                case ConfigurationConstants.HARD:
                    characterSpeed = CalculusInvadersConstants.HARD_CHARACTER_SPEED;
                    break;
            }
        }

        void ChangeEnemySpeed()
        {
            switch (clsConfig.difficulty)
            {
                case ConfigurationConstants.EASY:
                    enemySpeed = CalculusInvadersConstants.EASY_ENEMY_SPEED;
                    break;
                case ConfigurationConstants.NORMAL:
                    enemySpeed = CalculusInvadersConstants.NORMAL_ENEMY_SPEED;
                    break;
                case ConfigurationConstants.HARD:
                    enemySpeed = CalculusInvadersConstants.HARD_ENEMY_SPEED;
                    break;
            }
        }
        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;

            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
        }

        private void keyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }

            if (e.KeyCode == Keys.Space && shoot == false)
            {
                ShotRoutine();
            }
            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                RestartRoutine();
            }
        }

        private void RestartRoutine()
        {
            if (clsConfig.sounds == ConfigurationConstants.MUSIC_ON)
            {
                invadersSound.controls.play();
                invadersSound.settings.setMode("loop", true);
            }
            RemoveScreen(lifes, points);
            GameSetup();
        }

        private void ShotRoutine()
        {
            PlayTrack(CalculusInvadersConstants.LASER_SOUND_TRACK, laserSound);
            shoot = true;
            CreateLaserComponent("laser");
        }

        private void CreateInvaders()
        {
            invadersVector = new PictureBox[15];
            int left = 0;
            for (int i = 0; i < invadersVector.Length; i++)
            {
                invadersVector[i] = new PictureBox();
                invadersVector[i].Size = new Size(80, 60);
                invadersVector[i].Image = Properties.Resources.derivada_2;
                invadersVector[i].Top = 5;
                invadersVector[i].Tag = CalculusInvadersConstants.INVADER_TAG;
                invadersVector[i].Left = left;
                invadersVector[i].SizeMode = PictureBoxSizeMode.Zoom;
                this.Controls.Add(invadersVector[i]);
                left = left - 80;
            }
        }

        void GameSetup()
        {
            SetSetupVariables();
            ChangeEnemySpeed();
            CreateInvaders();
            gameTimer.Start();
        }

        private void SetSetupVariables()
        {
            lblPoints.Text = $"{CalculusInvadersConstants.POINTS}: 0";
            points = 0;
            isGameOver = false;
            enemyLaserTimer = 300;
            shoot = false;
        }
        
        void RemoveScreen(int lifes, int attemptPoints)
        {
            RemoveFromControls();
            CheckRecord(lifes, attemptPoints);
        }

        private void CheckRecord(int lifes, int attemptPoints)
        {
            if (lifes == 3)
            {
                record = attemptPoints;
            }
            else if (attemptPoints > record)
            {
                record = attemptPoints;
            }

            else if (lifes == 0)
            {
                invadersSound.controls.stop();
                gameOverSound.controls.stop();
                this.Close();
            }
        }

        private void RemoveFromControls()
        {
            foreach (PictureBox i in invadersVector)
            {
                this.Controls.Remove(i);
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == CalculusInvadersConstants.INVADER_TAG || (string)x.Tag == CalculusInvadersConstants.INVADER_LASER_TAG)
                    {
                        this.Controls.Remove(x);
                    }
                }
            }
        }

        void GameOver(string message)
        {
            isGameOver = true;
            gameTimer.Stop();
            invadersSound.controls.stop();
            clsConfig.pointsInvaders = record;
            if (message == CalculusInvadersConstants.CAUGHT_BY_LASER_INVADER || message == CalculusInvadersConstants.CAUGHT_BY_INVADERS)
            {
                ShowLossMessage(message);
            }
            else
            {
                ShowWinMessage(message);
            }
            lblPoints.Text = $"{CalculusInvadersConstants.POINTS}: " + points;
        }

        private void ShowWinMessage(string message)
        {
            PlayTrack(CalculusInvadersConstants.WIN_SOUND_TRACK, winSound);   
            MessageBox.Show($"{message}\n{CalculusInvadersConstants.WIN_MESSAGE}");
            clsConfig.pointsInvaders = invadersVector.Length;
            this.Close();
        }

        private void ShowLossMessage(string message)
        {
            PlayTrack(CalculusInvadersConstants.LOSS_SOUND_TRACK, gameOverSound);
            if (lifes > 1)
                MessageBox.Show($"{message}\n{CalculusInvadersConstants.TRY_AGAIN}");
            if (lifes == 1)
            {
                if (points > record)
                {
                    record = points;
                }
                MessageBox.Show($"{CalculusInvadersConstants.NO_MORE_LIFES}: {record}");
                this.Close();
            }
        }

        void CreateLaserComponent(string laserTag)
        {
            PictureBox laser = new PictureBox();
            laser.Image = Properties.Resources.laser;
            laser.Size = new Size(5, 20);
            laser.Tag = laserTag;
            laser.Left = pcbPlayer.Left + pcbPlayer.Width / 2;

            if ((string)laser.Tag == CalculusInvadersConstants.LASER_TAG)
            {
                laser.Top = pcbPlayer.Top - 20;
            }
            if ((string)laser.Tag == CalculusInvadersConstants.INVADER_LASER_TAG)
            {
                laser.Top = -100;
            }
            this.Controls.Add(laser);
            laser.BringToFront();
        }
    }
}
