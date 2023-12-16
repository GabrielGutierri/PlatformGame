using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jogoN2v2._0.Constants
{
    public class CalculusInvadersConstants
    {
        public const string TITLE = "Calculus Invaders";
        //labels texts
        public const string POINTS = "Points";
        public const string LIFES = "Lifes";
        public const string BEST_ROUND = "Best round";

        //messages
        public const string DEFEATED_DERIVATIVES_MESSAGE = "You've defeated the derivatives!!! YESSSSSS SIRRRRRRRR";
        public const string CAUGHT_BY_INVADERS = "You have been caught by the invaders...";
        public const string CAUGHT_BY_LASER_INVADER = "You have been caught by the laser of the invaders...";
        public const string WIN_MESSAGE = "HURRAH! Our great master Wuo have defeated the dungeon of derivatives!!!!!";
        public const string TRY_AGAIN = "Go back to the game and try one more time! (Press ENTER to restart)";
        public const string NO_MORE_LIFES = "No more lifes. Your best score";

        //tags
        public const string INVADER_LASER_TAG = "invaderLaser";
        public const string LASER_TAG = "laser";
        public const string INVADER_TAG = "invader";

        //difficulty
        public const int EASY_CHARACTER_SPEED = 14;
        public const int NORMAL_CHARACTER_SPEED = 16;
        public const int HARD_CHARACTER_SPEED = 18;
        public const int EASY_ENEMY_SPEED = 8;
        public const int NORMAL_ENEMY_SPEED = 12;
        public const int HARD_ENEMY_SPEED = 15;

        //tracks
        public const string INVADERS_SOUND_TRACK = "invadersSound.mp3";
        public const string ENEMY_DESTROYED_TRACK = "enemyDestroyed.mp3";
        public const string LASER_SOUND_TRACK = "somLaser.mp3";
        public const string WIN_SOUND_TRACK = "winSound.mp3";
        public const string LOSS_SOUND_TRACK = "gameOver.mp3";
    }
}
