using System;
using System.Windows.Forms;

namespace PlayPauseTaskbar
{
    internal class Timer
    {
        public static void TimerCallback(object state)
        {
            if (Functions.IsAudioPlaying(Globals.deviceID))
            {
                Globals.playIcon.Icon = Properties.Resources.Pause;
            }
            else
            {
                Globals.playIcon.Icon = Properties.Resources.Play;
            }
            GC.Collect();
        }
    }
}

