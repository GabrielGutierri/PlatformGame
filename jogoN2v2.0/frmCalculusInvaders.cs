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
        WMPLib.WindowsMediaPlayer laserSound = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer enemyDestroyed = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer invadersSound = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer gameOverSound = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer winSound = new WMPLib.WindowsMediaPlayer();

        bool goLeft, goRight;
        int characterSpeed = 12;
        int enemySpeed = 0;
        int points = 0;
        int enemyLaserTimer = 300;
        int record = 0;
        PictureBox[] invadersVector;
        bool shoot;
        bool isGameOver;
        int lifes = 3;


        public frmCalculusInvaders()
        {
            frmTutorialInvaders t = new frmTutorialInvaders();
            t.ShowDialog();
            InitializeComponent();
            if (clsConfig.music == "on")
            {
                invadersSound.URL = "invadersSound.mp3";
                invadersSound.controls.play();
                invadersSound.settings.setMode("loop", true);
            }
            GameSetup();
        }
        private void InvadersTimerEvent(object sender, EventArgs e)
        {
            lblPoints.Text = "Points: " + points;
            lblLifes.Text = "Lifes: " + lifes;
            lblRecord.Text = "Best round: " + record;
            if (goLeft && pcbPlayer.Left > 0)
            {
                pcbPlayer.Left -= characterSpeed;
            }

            if (goRight && pcbPlayer.Left < 620)
            {
                pcbPlayer.Left += characterSpeed;
            }

            enemyLaserTimer -= 10;
            if (enemyLaserTimer < 10)
            {
                enemyLaserTimer = 300;
                CreateLaserComponent("invaderLaser");
            }

            foreach (Control x in this.Controls)
            {

                VerifyEnemyCollision(x);
                VerifyLaserCollision(x);
                VerifyEnemyLaserColision(x);

            }

            if (points > 8)
            {
                ChangeSpeed();
            }

            if (points == invadersVector.Length)
            {
                GameOver("You've defeated the derivatives!!! YESSSSSS SIRRRRRRRR");
            }
        }

        void VerifyLaserCollision(Control x)
        {
            if (x is PictureBox && (string)x.Tag == "laser")
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
            if (x is PictureBox && (string)x.Tag == "invader")
            {
                MoveInvader(x);

                if (x.Bounds.IntersectsWith(pcbPlayer.Bounds))
                {
                    GameOver("You have been caught by the invaders...");
                    lifes--;
                }

                foreach (Control y in this.Controls)
                {
                    if (y is PictureBox && (string)y.Tag == "laser")
                    {
                        if (y.Bounds.IntersectsWith(x.Bounds))
                        {
                            if (clsConfig.sounds == "on")
                            {
                                enemyDestroyed.URL = "enemyDestroyed.mp3";
                                enemyDestroyed.controls.play();
                            }
                            this.Controls.Remove(x);
                            this.Controls.Remove(y);
                            points += 1;
                            shoot = false;
                        }
                    }
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
            if (x is PictureBox && (string)x.Tag == "invaderLaser")
            {
                MoveRemoveLaser(x);

                if (x.Bounds.IntersectsWith(pcbPlayer.Bounds))
                {
                    this.Controls.Remove(x);
                    GameOver("You have been caught by the laser of the invaders...");
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
        void ChangeSpeed()
        {
            if (clsConfig.difficulty == "Easy")
            {
                characterSpeed = 14;
                enemySpeed = 8;
            }
            else if (clsConfig.difficulty == "Normal")
            {
                characterSpeed = 16;
                enemySpeed = 12;
            }
            else if (clsConfig.difficulty == "Hard")
            {
                characterSpeed = 18;
                enemySpeed = 15;
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
                if (clsConfig.sounds == "on")
                {
                    laserSound.URL = "somLaser.mp3";
                    laserSound.controls.play();
                }
                shoot = true;
                CreateLaserComponent("laser");
            }
            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                if (clsConfig.sounds == "on")
                {
                    invadersSound.controls.play();
                    invadersSound.settings.setMode("loop", true);
                }
                RemoveScreen(lifes, points);

                GameSetup();
            }
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
                invadersVector[i].Tag = "invader";
                invadersVector[i].Left = left;
                invadersVector[i].SizeMode = PictureBoxSizeMode.Zoom;
                this.Controls.Add(invadersVector[i]);
                left = left - 80;
            }
        }

        void GameSetup()
        {
            lblPoints.Text = "Points: 0";
            points = 0;
            isGameOver = false;
            enemyLaserTimer = 300;
            ChangeEnemySpeed();

            shoot = false;

            CreateInvaders();
            gameTimer.Start();
        }

        void ChangeEnemySpeed()
        {
            if (clsConfig.difficulty == "Easy")
            {
                enemySpeed = 5;
            }
            else if (clsConfig.difficulty == "Normal")
            {
                enemySpeed = 8;
            }
            else if (clsConfig.difficulty == "Hard")
            {
                enemySpeed = 12;
            }
        }
        

        void RemoveScreen(int lifes, int attemptPoints)
        {
            foreach (PictureBox i in invadersVector)
            {
                this.Controls.Remove(i);
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "laser" || (string)x.Tag == "invaderLaser")
                    {
                        this.Controls.Remove(x);
                    }
                }
            }
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
        void GameOver(string message)
        {
            isGameOver = true;
            gameTimer.Stop();
            invadersSound.controls.stop();
            clsConfig.pointsInvaders = record;
            if (message == "You have been caught by the laser of the invaders.." || message == "\"You have been caught by the invaders...")
            {
                if (clsConfig.sounds == "on")
                {
                    gameOverSound.URL = "gameOver.mp3";
                    gameOverSound.controls.play();
                }
                if (lifes > 1)
                    MessageBox.Show($"{message}\nGo back to the game and try one more time! (Press ENTER to restart)");
                if (lifes == 1)
                {
                    if (points > record)
                    {
                        record = points;
                    }
                    MessageBox.Show($"No more lifes. Your best score: {record}");
                    this.Close();
                }
            }
            else
            {
                if (clsConfig.sounds == "on")
                {
                    winSound.URL = "winSound.mp3";
                    winSound.controls.play();
                }
                MessageBox.Show($"{message}\nHURRAH! Our great master Wuo have defeated the dungeon of derivatives!!!!!");
                clsConfig.pointsInvaders = invadersVector.Length;
                this.Close();
            }
            lblPoints.Text = "Points: " + points;
        }

        void CreateLaserComponent(string laserTag)
        {
            PictureBox laser = new PictureBox();
            laser.Image = Properties.Resources.laser;
            laser.Size = new Size(5, 20);
            laser.Tag = laserTag;
            laser.Left = pcbPlayer.Left + pcbPlayer.Width / 2;

            if ((string)laser.Tag == "laser")
            {
                laser.Top = pcbPlayer.Top - 20;
            }
            if ((string)laser.Tag == "invaderLaser")
            {
                laser.Top = -100;
            }
            this.Controls.Add(laser);
            laser.BringToFront();
        }
    }
}
