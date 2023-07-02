using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PlayPauseTaskbar
{
    internal class Globals
    {
        public const int KEYEVENTF_EXTENTEDKEY = 1;
        public const int KEYEVENTF_KEYUP = 0;
        public const int VK_MEDIA_NEXT_TRACK = 0xB0;
        public const int VK_MEDIA_PLAY_PAUSE = 0xB3;
        public const int VK_MEDIA_PREV_TRACK = 0xB1;

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);

        public static NotifyIcon playIcon = new NotifyIcon();

        public static int deviceID;
        public static bool runOnStartup = false;
        public static bool musicPlay = false;

        public static Microsoft.Win32.RegistryKey autorun = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
    }
}
