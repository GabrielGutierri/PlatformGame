using jogoN2v2._0.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jogoN2v2._0.Utils
{
    public static class GameUtils
    {
        public static void PlayTrack(string trackName, WMPLib.WindowsMediaPlayer sound)
        {
            if (clsConfig.sounds == ConfigurationConstants.MUSIC_ON)
            {
                sound.URL = trackName;
                sound.controls.play();
            }
        }

    }
}
