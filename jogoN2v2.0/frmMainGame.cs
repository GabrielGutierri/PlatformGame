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
        private string addLetters = "";
        private bool goRight, goLeft, jumping, hasKey1, hasKey2, hasKey3, wall, shoot, rightDirection = true, immune = false, shootEnemy = true, 
            moveImageDirection, infiniteOn = false, justOneTime = false;
        private int jumpSpeed = 10, playerSpeed = 2, force = 8, score = 0, ScreenBackground = 16, lifes, howMuchMiniGames = 0, immuneTime = 0, 
            moveImage, enemyLaserTimer, time;

        private PictureBox[] life = new PictureBox[6];
        public frmMainGame()
        {
            frmCutScene f = new frmCutScene();
            f.ShowDialog();
            InitializeComponent();
            PlayTheme();
            SetLifes();
            Difficulty();
        }

        private void PlayTheme()
        {
            if (clsConfig.music == ConfigurationConstants.MUSIC_ON)
            {
                GameUtils.PlayTrack("song-two.mp3", mainGameSound);
                mainGameSound.settings.setMode("loop", true);
            }
        }

        private void SetLifes()
        {
            life[1] = pcbHeart1;
            life[2] = pcbHeart2;
            life[3] = pcbHeart3;
            life[4] = pcbHeart4;
            life[5] = pcbHeart5;
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = $"{GameConstants.SCORE}: " + score;
            pcbCharacter.Top += jumpSpeed;
            MoveCharacter();
            MoveGame();
            MoveGameElementsEnemyDirection();
            VerifyCollisionCoinWall();
            VerifyCollisionEnemyLava();
            VerifyCollisionKey();
            VerifyCollisionDoor();
            VerifyCollisionPlatformLava();
            ControlsRoutine();
            LaserRoutine();
            EnemyShoots();
            Die();
            Win();
            ImmuneDamage();
        }

        private void LaserRoutine()
        {
            enemyLaserTimer -= 10;
            if (enemyLaserTimer < 10)
            {
                enemyLaserTimer = time;
                CreateLaser(MainGameConstants.ENEMY_LASER_TAG);
            }
        }

        private void ControlsRoutine()
        {
            foreach (Control x in this.Controls)
            {

                VerifyEnemyCollision(x);
                if (x is PictureBox && (string)x.Tag == MainGameConstants.LASER_TAG)
                {
                    if (rightDirection == true)
                    {
                        x.Left += 20;
                        if (x.Left > 600)
                        {
                            this.Controls.Remove(x);
                            shoot = false;
                        }
                        VerifyCollisionLaser(x);
                    }

                    if (rightDirection == false)
                    {
                        x.Left -= 20;
                        if (x.Left < 0)
                        {
                            this.Controls.Remove(x);
                            shoot = false;
                        }
                        VerifyCollisionLaser(x);
                    }
                }

            }
        }

        void Difficulty()
        {
            if (clsConfig.difficulty == ConfigurationConstants.EASY)
            {
                lifes = 5;
                time = 1200;
            }
            else if (clsConfig.difficulty == ConfigurationConstants.NORMAL)
            {
                time = 1000;
                lifes = 3;
                this.Controls.Remove(pcbHeart5);
                this.Controls.Remove(pcbHeart4);
            }
            else if (clsConfig.difficulty == ConfigurationConstants.HARD)
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
                GoLeft();
            if (e.KeyCode == Keys.Right)
                GoRight();
            if (e.KeyCode == Keys.Space && jumping == false)
                Jump();
            if (e.KeyCode == Keys.Enter && shoot == false)
                Shoot();
            LettersEasterEgg(e);
        }

        private void LettersEasterEgg(KeyEventArgs e)
        {
            addLetters += Convert.ToChar(e.KeyValue);
            if (addLetters.ToUpper().Contains("IDKIDNL") && justOneTime == false)
            {
                GameUtils.PlayTrack("som-upgrade.mp3", infiniteSound);
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

        private void Shoot()
        {
            if (rightDirection == false)
            {
                pcbCharacter.Image = Properties.Resources.wuo_tras_atirando;
            }
            else
            {
                pcbCharacter.Image = Properties.Resources.wuo_atirando;
            }
            GameUtils.PlayTrack("somLaser.mp3", laserSound);
            shoot = true;
            CreateLaser(MainGameConstants.LASER_TAG);
        }

        private void Jump()
        {
            if (rightDirection == false)
            {
                pcbCharacter.Image = Properties.Resources.wuo_tras_pulando;
            }
            else
            {
                pcbCharacter.Image = Properties.Resources.wuo_pulando;
            }
            GameUtils.PlayTrack("som_de_pulo_.mp3", jumpSound);
            jumping = true;
        }

        private void GoRight()
        {
            rightDirection = true;
            pcbCharacter.Image = Properties.Resources.imagem_wuo_3;
            goRight = true;
        }

        private void GoLeft()
        {
            rightDirection = false;
            pcbCharacter.Image = Properties.Resources.wuo_tras1;
            goLeft = true;
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                GoBackLeft();
            if (e.KeyCode == Keys.Right)
                GoBackRight();
            if (jumping == true)
                JumpingOrShootingAnimation();
                jumping = false;
            if (e.KeyCode == Keys.Enter && shoot == true)
                JumpingOrShootingAnimation();
        }

        private void JumpingOrShootingAnimation()
        {
            if (rightDirection == false)
                pcbCharacter.Image = Properties.Resources.wuo_tras2;
            else
                pcbCharacter.Image = Properties.Resources.imagem_wuo_2;
        }

        private void GoBackRight()
        {
            rightDirection = true;
            pcbCharacter.Image = Properties.Resources.imagem_wuo_2;
            goRight = false;
        }

        private void GoBackLeft()
        {
            rightDirection = false;
            pcbCharacter.Image = Properties.Resources.wuo_tras2;
            goLeft = false;
        }

        private void MoveGameElementsPlatformCoinKey(string direction)
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == MainGameConstants.PLATFORM_TAG || x is PictureBox && (string)x.Tag == MainGameConstants.COIN_TAG || x is PictureBox && (string)x.Tag == MainGameConstants.KEY_TAG)
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

        private void MoveGameElementsDoorWallLava(string direction)
        {
            foreach (Control x in this.Controls)
            { 
                if (x is PictureBox && (string)x.Tag == MainGameConstants.DOOR_TAG || x is PictureBox && (string)x.Tag == MainGameConstants.WALL_TAG || x is PictureBox && (string)x.Tag == MainGameConstants.LAVA_TAG)
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

        private void MoveGameElementsEnemy(string direction)
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == MainGameConstants.ENEMY_TAG )
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

        private void MoveGameElementsEnemyDirection()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == MainGameConstants.ENEMY_TAG)
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
                MoveGameElementsPlatformCoinKey("forward");
                MoveGameElementsDoorWallLava("forward");
                MoveGameElementsEnemy("forward");
            }
            if (goRight == true && pcbPlatform.Left > -2120 && wall == false)
            {
                MoveGameElementsPlatformCoinKey("back");
                MoveGameElementsDoorWallLava("back");
                MoveGameElementsEnemy("back");

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

        private void VerifyCollisionCoinWall()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == MainGameConstants.WALL_TAG)
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

                if (x is PictureBox && (string)x.Tag == MainGameConstants.COIN_TAG)
                {
                    if (pcbCharacter.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                    {
                        x.Visible = false;
                        score += 1;

                    }
                }
            }
        }

        private void VerifyCollisionEnemyLava()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == MainGameConstants.ENEMY_TAG || x is PictureBox && (string)x.Tag == MainGameConstants.LAVA_TAG)
                {
                    if (pcbCharacter.Bounds.IntersectsWith(x.Bounds) && immune == false)
                    {
                        GameUtils.PlayTrack("barulho_de_soco_.mp3", damageSound);
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

        private void VerifyCollisionKey()
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

        private void VerifyCollisionDoor()
        {
            if (pcbCharacter.Bounds.IntersectsWith(pcbDoor1.Bounds) && hasKey1 == true)
            {
                StartCalculusInvadersGame();

            }
            if (pcbCharacter.Bounds.IntersectsWith(pcbDoor2.Bounds) && hasKey2 == true)
            {
                StartDinoGame();
            }
            if (pcbCharacter.Bounds.IntersectsWith(pcbDoor3.Bounds) && hasKey3 == true)
            {
                StartPongGame();
            }
        }
        private void RestartGameTimerAndSound()
        {
            MainGameTimer.Start();
            howMuchMiniGames++;
            if (clsConfig.music == ConfigurationConstants.MUSIC_ON)
                mainGameSound.controls.play();
        }

        private void StopGameSoundAndSound()
        {
            if (clsConfig.music == ConfigurationConstants.MUSIC_ON)
                mainGameSound.controls.pause();
            MainGameTimer.Stop();
        }

        private void StartPongGame()
        {
            pcbDoor3.Image = Properties.Resources.porta_aberta;
            StopGameSoundAndSound();
            frmPong c = new frmPong();
            c.ShowDialog();
            this.Controls.Remove(pcbDoor3);
            RestartGameTimerAndSound();
            hasKey3 = false;
            pcbCharacter.Left = pcbCharacter.Left;
        }

        

        private void StartDinoGame()
        {
            pcbDoor2.Image = Properties.Resources.porta_aberta;
            StopGameSoundAndSound();
            frmDinoGame b = new frmDinoGame();
            b.ShowDialog();
            this.Controls.Remove(pcbDoor2);
            RestartGameTimerAndSound();
            hasKey2 = false;
            pcbCharacter.Left = pcbCharacter.Left;
        }

        private void StartCalculusInvadersGame()
        {
            pcbDoor1.Image = Properties.Resources.porta_aberta;
            StopGameSoundAndSound();
            frmCalculusInvaders a = new frmCalculusInvaders();
            a.ShowDialog();
            this.Controls.Remove(pcbDoor1);
            RestartGameTimerAndSound();
            hasKey1 = false;
            pcbCharacter.Left = pcbCharacter.Left;
        }

        void VerifyCollisionLaser(Control x)
        {
            if (x is PictureBox && (string)x.Tag == MainGameConstants.LASER_TAG)
            {
                foreach (Control y in this.Controls)
                {
                    if (y is PictureBox && ((string)y.Tag == MainGameConstants.PLATFORM_TAG || (string)y.Tag == MainGameConstants.WALL_TAG))
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

        private void VerifyCollisionPlatformLava()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == MainGameConstants.PLATFORM_TAG || x is PictureBox && (string)x.Tag == MainGameConstants.LAVA_TAG)
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
            if (x is PictureBox && (string)x.Tag == MainGameConstants.ENEMY_TAG )
            {
                foreach (Control y in this.Controls)
                {
                    if (y is PictureBox && (string)y.Tag == MainGameConstants.LASER_TAG)
                    {
                        if (y.Bounds.IntersectsWith(x.Bounds))
                        {
                            GameUtils.PlayTrack("enemyDestroyed2.mp3", enemyDestroyed);
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
            if (laserTag == MainGameConstants.LASER_TAG && rightDirection == true)
            {
                PictureBox laser = SetLaserProperties(laserTag, Properties.Resources.laser2, top: pcbCharacter.Top + 40, left: pcbCharacter.Left + pcbCharacter.Width);
                this.Controls.Add(laser);
                laser.BringToFront();
            }
            else if(laserTag == MainGameConstants.LASER_TAG && rightDirection == false)
            {
                PictureBox laser = SetLaserProperties(laserTag, Properties.Resources.laser2, top: pcbCharacter.Top + 40,  left: pcbCharacter.Left - 40);
                this.Controls.Add(laser);
                laser.BringToFront();
            }
            else if(laserTag == MainGameConstants.ENEMY_LASER_TAG && shootEnemy == true)
            {
                if (pcbLimit2.Visible == true || pcbLimit3.Visible == true)
                {
                    PictureBox laser = SetLaserProperties(laserTag, Properties.Resources.laser3, top: pcbLimit2.Top + 20, left: pcbLimit2.Left - 10);
                    shootEnemy = false;
                    this.Controls.Add(laser);
                    laser.BringToFront();
                }
            }
          
        }

        private static PictureBox SetLaserProperties(string laserTag, Image image, int top, int left)
        {
            PictureBox laser = new PictureBox();
            laser.Image = image;
            laser.Size = new Size(50, 16);
            laser.Tag = laserTag;
            laser.BackColor = Color.Transparent;
            laser.Left = left;
            laser.Top = top;
            return laser;
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
                if (clsConfig.music == ConfigurationConstants.MUSIC_ON)
                    mainGameSound.controls.stop();
                MainGameTimer.Stop();
                GameUtils.PlayTrack("gameOver.mp3", gameOverSound);
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
                if (clsConfig.music == ConfigurationConstants.MUSIC_ON)
                    mainGameSound.controls.stop();
                MainGameTimer.Stop();
                GameUtils.PlayTrack("winSound.mp3", winSound);
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
                if (x is PictureBox && (string)x.Tag == MainGameConstants.ENEMY_LASER_TAG)
                {
                    x.Left -= 20;
                    if (x.Left < -100)
                    {
                        this.Controls.Remove(x);
                        shootEnemy = true;
                    }

                    foreach (Control y in this.Controls)
                    {
                        if (y is PictureBox && ((string)y.Tag == MainGameConstants.PLATFORM_TAG || (string)y.Tag == MainGameConstants.WALL_TAG))
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
                if (x is PictureBox && (string)x.Tag == MainGameConstants.ENEMY_LASER_TAG)
                {
                    if (pcbCharacter.Bounds.IntersectsWith(x.Bounds) && immune == false)
                    {
                        GameUtils.PlayTrack("barulho_de_soco_.mp3", damageSound);
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
