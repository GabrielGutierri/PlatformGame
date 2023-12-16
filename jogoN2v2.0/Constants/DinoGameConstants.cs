using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace jogoN2v2._0.Constants
{
    public static class DinoGameConstants
    {
        public const string TITLE = "Dinossaur Game";
        //messages
        public const string INTRO_MESSAGE = "Press the spacebar to jump the integrals! Press R to restart";
        public const string RESTART_MESSAGE = "Press R to restart";
        public const string WIN_MESSAGE = "Congrats! You've won!";
        public const string NO_LIFES_MESSAGE = "No more lifes! Your best round";
        //tags
        public const string OBSTACLE_TAG = "obstacle";

        //tracks
        public const string BACKGROUND_SOUND_TRACK = "FallGuys.mp3";
        public const string HIT_SOUND_TRACK = "MarioHit.mp3";
        public const string WIN_SOUND_TRACK = "winSound.mp3";
        public const string GAMEOVER_SOUND_TRACK = "gameOver.mp3";
        public const string JUMP_SOUND_TRACK = "jump.mp3";
    }
}
