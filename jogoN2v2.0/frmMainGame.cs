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
    public partial class frmMainGame : Form
    {
        WMPLib.WindowsMediaPlayer infiniteSound = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer jumpSound = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer damageSound = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer gameOverSound = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer winSound = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer mainGameSound = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer laserSound = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer enemyDestroyed = new WMPLib.WindowsMediaPlayer();
        string addLetters = "";
        bool goRight, goLeft, jumping, hasKey1, hasKey2, hasKey3, wall, shoot, rightDirection = true, immune = false, shootEnemy = true, 
            moveImageDirection, infiniteOn = false, justOneTime = false;
        int jumpSpeed = 10, playerSpeed = 2, force = 8, score = 0, ScreenBackground = 16, lifes, howMuchMiniGames = 0, immuneTime = 0, 
            moveImage, enemyLaserTimer, time;

        PictureBox[] life = new PictureBox[6];
        public frmMainGame()
        {
            frmCutScene f = new frmCutScene();
            f.ShowDialog();
            InitializeComponent();
            if (clsConfig.music == "on")
            {
                mainGameSound.URL = "song-two.mp3";
                mainGameSound.controls.play();
                mainGameSound.settings.setMode("loop", true);
            }
            
            life[1] = pcbHeart1;
            life[2] = pcbHeart2;
            life[3] = pcbHeart3;
            life[4] = pcbHeart4;
            life[5] = pcbHeart5;

            Difficulty();
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score;
            pcbCharacter.Top += jumpSpeed;

            MoveCharacter();
            MoveGame();
            MoveGameElements4();
            VerifyCollision1();
            VerifyCollision2();
            VerifyCollision3();
            VerifyCollision4();
            VerifyCollision6();
            VerifyCollision7();

            foreach (Control x in this.Controls)
            {

                VerifyEnemyCollision(x);
                if (x is PictureBox && (string)x.Tag == "laser")
                {
                    if (rightDirection == true)
                    {
                        x.Left += 20;
                        if (x.Left > 600)
                        {
                            this.Controls.Remove(x);
                            shoot = false;
                        }

                        VerifyCollision(x);

                    }

                    if (rightDirection == false)
                    {
                        x.Left -= 20;
                        if (x.Left < 0)
                        {
                            this.Controls.Remove(x);
                            shoot = false;
                        }

                        VerifyCollision(x);
                    }
                }

            }

            enemyLaserTimer -= 10;
            if (enemyLaserTimer < 10)
            {
                enemyLaserTimer = time;
                CreateLaser("laserinimigo1");
            }

            EnemyShoots();
            Die();
            Win();
            ImmuneDamage();
        }

        void Difficulty()
        {
            if (clsConfig.difficulty == "Easy")
            {
                lifes = 5;
                time = 1200;
            }
            else if (clsConfig.difficulty == "Normal")
            {
                time = 1000;
                lifes = 3;
                this.Controls.Remove(pcbHeart5);
                this.Controls.Remove(pcbHeart4);
            }
            else if (clsConfig.difficulty == "Hard")
            {
                time = 500;
                lifes = 1;
                this.Controls.Remove(pcbHeart5);
                this.Controls.Remove(pcbHeart4);
                this.Controls.Remove(pcbHeart3);
                this.Controls.Remove(pcbHeart2);
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                rightDirection = false;
                pcbCharacter.Image = Properties.Resources.wuo_tras1;
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                rightDirection = true;
                pcbCharacter.Image = Properties.Resources.imagem_wuo_3;
                goRight = true;

            }
            if (e.KeyCode == Keys.Space && jumping == false)
            {
                if (rightDirection == false)
                {
                    pcbCharacter.Image = Properties.Resources.wuo_tras_pulando;
                }
                else
                {
                    pcbCharacter.Image = Properties.Resources.wuo_pulando;
                }

                if (clsConfig.sounds == "on")
                {
                    jumpSound.URL = "som_de_pulo_.mp3";
                    jumpSound.controls.play();
                }
                jumping = true;
            }
            if (e.KeyCode == Keys.Enter && shoot == false)
            {
                if (rightDirection == false)
                {
                    pcbCharacter.Image = Properties.Resources.wuo_tras_atirando;
                }
                else
                {
                    pcbCharacter.Image = Properties.Resources.wuo_atirando;
                }
                if (clsConfig.sounds == "on")
                {
                    laserSound.URL = "somLaser.mp3";
                    laserSound.controls.play();
                }
                shoot = true;
                CreateLaser("laser");
            }

            addLetters += Convert.ToChar(e.KeyValue);
            if (addLetters.ToUpper().Contains("IDKIDNL") && justOneTime == false)
            {
                if (clsConfig.sounds == "on")
                {
                    infiniteSound.URL = "som-upgrade.mp3";
                    infiniteSound.controls.play();
                }
                pcbInfinite.Visible = true;

                this.Controls.Remove(pcbHeart5);
                this.Controls.Remove(pcbHeart4);
                this.Controls.Remove(pcbHeart3);
                this.Controls.Remove(pcbHeart2);
                this.Controls.Remove(pcbHeart1);

                infiniteOn = true;
                justOneTime = true;

            }
            
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                rightDirection = false;
                pcbCharacter.Image = Properties.Resources.wuo_tras2;
                goLeft = false;

            }
            if (e.KeyCode == Keys.Right)
            {
                rightDirection = true;
                pcbCharacter.Image = Properties.Resources.imagem_wuo_2;
                goRight = false;

            }
            if (jumping == true)
            {
                if (rightDirection == false)
                {
                    pcbCharacter.Image = Properties.Resources.wuo_tras2;
                }
                else
                {
                    pcbCharacter.Image = Properties.Resources.imagem_wuo_2;
                }

                jumping = false;
            }
            if (e.KeyCode == Keys.Enter && shoot == true)
            {
                if (rightDirection == false)
                {
                    pcbCharacter.Image = Properties.Resources.wuo_tras2;
                }
                else
                {
                    pcbCharacter.Image = Properties.Resources.imagem_wuo_2;
                }
            }
        }

        private void MoveGameElements1(string direction)
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "platform" || x is PictureBox && (string)x.Tag == "coin" || x is PictureBox && (string)x.Tag == "key")
                {
                    x.BackColor = Color.Transparent;
                    if (direction == "back")
                    {
                        x.Left -= ScreenBackground;
                    }
                    if (direction == "forward")
                    {
                        x.Left += ScreenBackground;
                    }
                }
            }
        }

        private void MoveGameElements2(string direction)
        {
            foreach (Control x in this.Controls)
            { 
                if (x is PictureBox && (string)x.Tag == "door" || x is PictureBox && (string)x.Tag == "wall" || x is PictureBox && (string)x.Tag == "lava")
                {
                    x.BackColor = Color.Transparent;
                    if (direction == "back")
                    {
                        x.Left -= ScreenBackground;
                    }
                    if (direction == "forward")
                    {
                        x.Left += ScreenBackground;
                    }

                }
            }
        }

        private void MoveGameElements3(string direction)
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "enemy" )
                {

                    if (direction == "back")
                    {
                        x.Left -= ScreenBackground;
                    }
                    if (direction == "forward")
                    {
                        x.Left += ScreenBackground;
                    }

                }
            }
        }

        private void MoveGameElements4()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "enemy")
                {
                    int i = 4;

                    if (moveImage == 0)
                    {
                        moveImageDirection = true;
                    }
                    else if (moveImage == 150)
                    {
                        moveImageDirection = false;
                    }

                    if (moveImageDirection == true)
                    {
                        x.Left += i;
                        moveImage++;
                    }
                    else
                    {
                        x.Left -= i;
                        moveImage--;
                    }
                }
            }

        }

        private void MoveCharacter()
        {

            if (goLeft == true && pcbCharacter.Left > 60)
            {
                pcbCharacter.Left -= playerSpeed;
            }
            if (goRight == true && pcbCharacter.Left + (pcbCharacter.Width + 60) < this.ClientSize.Width)
            {
                pcbCharacter.Left += playerSpeed;
            }
            if (jumping == true)
            {
                jumpSpeed = -10;
                force -= 1;
            }
            else
            {
                jumpSpeed = 10;
            }

            if (jumping == true && force < 0)
            {
                jumping = false;
            }

        }

        private void MoveGame()
        {
            if (goLeft == true && pcbPlatform.Left < 0 && wall == false)
            {
                MoveGameElements1("forward");
                MoveGameElements2("forward");
                MoveGameElements3("forward");
            }
            if (goRight == true && pcbPlatform.Left > -2120 && wall == false)
            {
                MoveGameElements1("back");
                MoveGameElements2("back");
                MoveGameElements3("back");

                if (pcbPlatform.Left < -2100)
                {
                    playerSpeed = 10;
                }
                else
                {
                    playerSpeed = 2;
                }
            }
        }

        private void VerifyCollision1()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "wall")
                {
                    if (pcbCharacter.Bounds.IntersectsWith(x.Bounds))
                    {
                        wall = true;
                        force = 8;
                        pcbCharacter.Left = x.Left - (pcbCharacter.Height - 25);

                    }

                    x.BringToFront();
                    wall = false;
                }

                if (x is PictureBox && (string)x.Tag == "coin")
                {
                    if (pcbCharacter.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                    {
                        x.Visible = false;
                        score += 1;

                    }
                }
            }
        }

        private void VerifyCollision2()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "enemy" || x is PictureBox && (string)x.Tag == "lava")
                {
                    if (pcbCharacter.Bounds.IntersectsWith(x.Bounds) && immune == false)
                    {
                        if (clsConfig.sounds == "on")
                        {
                            damageSound.URL = "barulho_de_soco_.mp3";
                            damageSound.controls.play();
                        }
                        immune = true;

                        if (infiniteOn == false)
                        {
                            this.Controls.Remove(life[lifes]);
                            lifes--;
                        }
                    }

                    x.BringToFront();
                }
            }
        }

        private void VerifyCollision3()
        {
            if (pcbCharacter.Bounds.IntersectsWith(pcbKey1.Bounds))
            {
                this.Controls.Remove(pcbKey1);
                hasKey1 = true;
            }
            if (pcbCharacter.Bounds.IntersectsWith(pcbKey2.Bounds))
            {
                this.Controls.Remove(pcbKey2);
                hasKey2 = true;
            }
            if (pcbCharacter.Bounds.IntersectsWith(pcbKey3.Bounds))
            {
                this.Controls.Remove(pcbKey3);
                hasKey3 = true;
            }

        }

        private void VerifyCollision4()
        {
            if (pcbCharacter.Bounds.IntersectsWith(pcbDoor1.Bounds) && hasKey1 == true)
            {
                pcbDoor1.Image = Properties.Resources.porta_aberta;
                if(clsConfig.music == "on")
                    mainGameSound.controls.pause();
                MainGameTimer.Stop();
                frmCalculusInvaders a = new frmCalculusInvaders();
                a.ShowDialog();
                this.Controls.Remove(pcbDoor1);
                MainGameTimer.Start();
                howMuchMiniGames++;
                if(clsConfig.music == "on")
                    mainGameSound.controls.play();
                hasKey1 = false;
                pcbCharacter.Left = pcbCharacter.Left;

            }
            if (pcbCharacter.Bounds.IntersectsWith(pcbDoor2.Bounds) && hasKey2 == true)
            {
                pcbDoor2.Image = Properties.Resources.porta_aberta;
                if(clsConfig.music == "on")
                    mainGameSound.controls.pause();
                MainGameTimer.Stop();
                frmDinoGame b = new frmDinoGame();
                b.ShowDialog();
                this.Controls.Remove(pcbDoor2);
                MainGameTimer.Start();
                howMuchMiniGames++;
                if(clsConfig.music == "on")
                    mainGameSound.controls.play();
                hasKey2 = false;
                pcbCharacter.Left = pcbCharacter.Left;
            }
        }

        private void VerifyCollision7()
        {
            if (pcbCharacter.Bounds.IntersectsWith(pcbDoor3.Bounds) && hasKey3 == true)
            {
                pcbDoor3.Image = Properties.Resources.porta_aberta;
                if (clsConfig.music == "on")
                    mainGameSound.controls.pause();
                MainGameTimer.Stop();
                frmPong c = new frmPong();
                c.ShowDialog();
                this.Controls.Remove(pcbDoor3);
                MainGameTimer.Start();
                howMuchMiniGames++;
                if (clsConfig.music == "on")
                    mainGameSound.controls.play();
                hasKey3 = false;
                pcbCharacter.Left = pcbCharacter.Left;
            }
        }

        void VerifyCollision(Control x)
        {
            if (x is PictureBox && (string)x.Tag == "laser")
            {
                foreach (Control y in this.Controls)
                {
                    if (y is PictureBox && ((string)y.Tag == "platform" || (string)y.Tag == "wall"))
                    {
                        if (x.Bounds.IntersectsWith(y.Bounds))
                        {
                            this.Controls.Remove(x);
                            shoot = false;
                        }
                    }
                }
            }
        }

        private void VerifyCollision6()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "platform" || x is PictureBox && (string)x.Tag == "lava")
                {
                    if (pcbCharacter.Bounds.IntersectsWith(x.Bounds) && jumping == false)
                    {
                        force = 8;
                        pcbCharacter.Top = x.Top - pcbCharacter.Height;
                        jumpSpeed = 0;
                    }

                    x.BringToFront();
                }
            }
        }

        void VerifyEnemyCollision(Control x)
        {
            if (x is PictureBox && (string)x.Tag == "enemy" )
            {
                foreach (Control y in this.Controls)
                {
                    if (y is PictureBox && (string)y.Tag == "laser")
                    {
                        if (y.Bounds.IntersectsWith(x.Bounds))
                        {
                            if (clsConfig.sounds == "on")
                            {
                                enemyDestroyed.URL = "enemyDestroyed2.mp3";
                                enemyDestroyed.controls.play();
                            }
                            x.Visible = false;
                            this.Controls.Remove(x);
                            this.Controls.Remove(y);
                            shoot = false;
                        }
                    }
                }
            }
        }

        private void CreateLaser(string laserTag)
        {
            

            if (laserTag == "laser" && rightDirection == true)
            {
                PictureBox laser = new PictureBox();
                laser.Image = Properties.Resources.laser2;
                laser.Size = new Size(50, 16);
                laser.Tag = laserTag;
                laser.Top = pcbCharacter.Top + 40;
                laser.Left = pcbCharacter.Left + pcbCharacter.Width;
                laser.BackColor = Color.Transparent;

                this.Controls.Add(laser);
                laser.BringToFront();
            }
            else if(laserTag == "laser" && rightDirection == false)
            {
                PictureBox laser = new PictureBox();
                laser.Image = Properties.Resources.laser2;
                laser.Size = new Size(50, 16);
                laser.Tag = laserTag;
                laser.Top = pcbCharacter.Top + 40;
                laser.Left = pcbCharacter.Left - 40;
                laser.BackColor = Color.Transparent;

                this.Controls.Add(laser);
                laser.BringToFront();
            }
            else if(laserTag == "laserinimigo1" && shootEnemy == true)
            {
                if (pcbLimit2.Visible == true)
                {
                    PictureBox laser = new PictureBox();
                    laser.Size = new Size(50, 16);
                    laser.Tag = laserTag;
                    laser.Image = Properties.Resources.laser3;
                    laser.Left = pcbLimit2.Left - 10;
                    laser.Top = pcbLimit2.Top + 20;
                    laser.BackColor = Color.Transparent;
                    shootEnemy = false;

                    this.Controls.Add(laser);
                    laser.BringToFront();
                }

                if (pcbLimit3.Visible == true)
                {
                    PictureBox laser2 = new PictureBox();
                    laser2.Image = Properties.Resources.laser3;
                    laser2.Size = new Size(50, 16);
                    laser2.Tag = laserTag;
                    laser2.BackColor = Color.Transparent;
                    laser2.Left = pcbLimit3.Left - 10;
                    laser2.Top = pcbLimit3.Top + 20;
                    shootEnemy = false;

                    this.Controls.Add(laser2);
                    laser2.BringToFront();
                }
            }
          
        }

        private void ImmuneDamage()
        {
            immuneTime++;

            if (immune == true && immuneTime < 60)
            {
                pcbCharacter.BackColor = Color.Red;
                pcbCharacter.Visible = true;

                if (immuneTime % 2 == 0)
                {
                    pcbCharacter.Visible = false;
                }
            }
            else
            {
                pcbCharacter.Visible = true;
                pcbCharacter.BackColor = Color.Transparent;
                immune = false;
                immuneTime = 0;
            }
        }

        private void Die()
        {
            clsConfig.pointsMainGame = score;
            if (lifes <= 0 && infiniteOn == false)
            {
                if (clsConfig.music == "on")
                    mainGameSound.controls.stop();
                MainGameTimer.Stop();
                if (clsConfig.sounds == "on")
                {
                    gameOverSound.URL = "gameOver.mp3";
                    gameOverSound.controls.play();
                }

                frmGameOver f = new frmGameOver();
                f.ShowDialog();

                if (f.DialogResult == DialogResult.No)
                    this.Close();
            }
        }

        private void Win()
        {
            if (howMuchMiniGames == 3)
            {
                if (clsConfig.music == "on")
                    mainGameSound.controls.stop();
                MainGameTimer.Stop();
                if (clsConfig.sounds == "on")
                {
                    winSound.URL = "winSound.mp3";
                    winSound.controls.play();
                }

                frmGameOver f = new frmGameOver();
                f.ShowDialog();

                if (f.DialogResult == DialogResult.No)
                    this.Close();
            }
        }

        private void EnemyShoots()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "laserinimigo1")
                {
                    x.Left -= 20;
                    if (x.Left < -100)
                    {
                        this.Controls.Remove(x);
                        shootEnemy = true;
                    }

                    foreach (Control y in this.Controls)
                    {
                        if (y is PictureBox && ((string)y.Tag == "platform" || (string)y.Tag == "wall"))
                        {
                            if (x.Bounds.IntersectsWith(y.Bounds))
                            {
                                this.Controls.Remove(x);
                                shootEnemy = true;
                            }
                        }
                    }
                }
            }

            EnemyDamage();
        }

        private void EnemyDamage()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "laserinimigo1")
                {
                    if (pcbCharacter.Bounds.IntersectsWith(x.Bounds) && immune == false)
                    {
                        if (clsConfig.sounds == "on")
                        {
                            damageSound.URL = "barulho_de_soco_.mp3";
                            damageSound.controls.play();
                        }
                        immune = true;

                        if (infiniteOn == false)
                        {
                            this.Controls.Remove(life[lifes]);
                            lifes--;
                        }
                        shootEnemy = true;
                    }

                    x.BringToFront();
                }
            }
        }

    }
}
