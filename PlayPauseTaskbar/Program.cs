using System;
using System.Windows.Forms;

namespace PlayPauseTaskbar
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            System.Threading.Timer timer = new System.Threading.Timer(Timer.TimerCallback, null, 0, 50); // Интервал в миллисекундах

            Globals.runOnStartup = (Globals.autorun.GetValue("PlayPauseTaskBar") != null);

            Visual.init();

            //Run
            Application.Run();
        }
    }
}
