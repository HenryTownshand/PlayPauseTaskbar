using NAudio.Wave;
using System;
using System.Windows.Forms;

namespace PlayPauseTaskbar
{
    internal class Visual
    {
        public static ContextMenu contextMenu = new ContextMenu();
        public static MenuItem contextItemOutputs = new MenuItem();
        public static MenuItem contextItemStartWin = new MenuItem();
        public static MenuItem contextItemAbout = new MenuItem();
        public static MenuItem contextItemExit = new MenuItem();
        public static void init()
        {
            //Tray Menu
            contextItemOutputs.Text = "Устройства вывода";
            contextItemStartWin.Text = "Запуск вместе с Windows";
            contextItemAbout.Text = "О программе";
            contextItemExit.Text = "Выход";

            contextItemStartWin.Click += new EventHandler(Functions.OnRunOnStartupClicked);
            contextItemAbout.Click += new EventHandler(Functions.About);
            contextItemExit.Click += new EventHandler(Functions.Exit);
            contextMenu.MenuItems.Add(contextItemOutputs);
            contextMenu.MenuItems.Add(contextItemStartWin);
            contextMenu.MenuItems.Add(contextItemAbout);
            contextMenu.MenuItems.Add(contextItemExit);
            contextItemStartWin.Checked = Globals.runOnStartup;

            int deviceCount = WaveOut.DeviceCount;

            for (int id = 0; id < deviceCount; id++)
            {
                WaveOutCapabilities capabilities = WaveOut.GetCapabilities(id);
                MenuItem DeviceItem = new MenuItem();
                DeviceItem.Text = capabilities.ProductName;
                contextItemOutputs.MenuItems.Add(DeviceItem);
                DeviceItem.Tag = id;

                if (id == Globals.deviceID)
                {
                    DeviceItem.Checked = true;
                }

                DeviceItem.Click += (sender, e) =>
                {
                    foreach (MenuItem menuItem in contextItemOutputs.MenuItems)
                    {
                        menuItem.Checked = false;
                    }

                    if (Globals.deviceID == id) { DeviceItem.Checked = true; }
                    DeviceItem.Checked = true;

                    Globals.deviceID = (int)DeviceItem.Tag;
                };
            }

            //Tray Icon
            NotifyIcon previousIcon = new NotifyIcon();
            NotifyIcon nextIcon = new NotifyIcon();

            //Next Icon
            nextIcon.Visible = true;
            nextIcon.Text = "Вперёд";
            nextIcon.Icon = Properties.Resources.Forward;
            nextIcon.MouseClick += new MouseEventHandler(Functions.NextIcon);
            nextIcon.ContextMenu = contextMenu;

            //Play & Pause Icon
            Globals.playIcon.Visible = true;
            Globals.playIcon.Text = "Включить / Выключить";
            Globals.playIcon.MouseClick += new MouseEventHandler(Functions.PlayIcon);
            Globals.playIcon.ContextMenu = contextMenu;

            //Previous Icon
            previousIcon.Visible = true;
            previousIcon.Text = "Назад";
            previousIcon.Icon = Properties.Resources.Backward;
            previousIcon.MouseClick += new MouseEventHandler(Functions.PreviousIcon);
            previousIcon.ContextMenu = contextMenu;
        }
    }
}
