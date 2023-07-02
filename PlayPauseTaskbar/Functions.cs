using System;
using System.Windows.Forms;
using NAudio.CoreAudioApi;

namespace PlayPauseTaskbar
{
    internal class Functions
    {
        public static void OnRunOnStartupClicked(object sender, EventArgs e)
        {
            Globals.runOnStartup = !Globals.runOnStartup;
            MenuItem menuItem = (MenuItem)sender;
            menuItem.Checked = Globals.runOnStartup;

            if (Globals.runOnStartup) Globals.autorun.SetValue("PlayPauseTaskBar", Application.ExecutablePath); else Globals.autorun.DeleteValue("PlayPauseTaskBar", false);
        }

        public static void PreviousIcon(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Globals.keybd_event(Globals.VK_MEDIA_PREV_TRACK, 0, Globals.KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);
            }
        }

        public static void PlayIcon(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Globals.keybd_event(Globals.VK_MEDIA_PLAY_PAUSE, 0, Globals.KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);
            }
        }

        public static void NextIcon(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Globals.keybd_event(Globals.VK_MEDIA_NEXT_TRACK, 0, Globals.KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);
            }
        }

        public static bool IsAudioPlaying(int deviceID)
        {
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            MMDevice speakers = new MMDeviceEnumerator().EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active)[deviceID];

            AudioMeterInformation meterInformation = speakers.AudioMeterInformation;

            float peakValue = meterInformation.MasterPeakValue;

            if (peakValue > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void About(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        public static void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
