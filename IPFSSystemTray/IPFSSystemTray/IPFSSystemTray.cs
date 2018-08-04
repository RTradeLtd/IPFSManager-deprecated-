using System;
using System.Windows.Forms;
using IPFSSystemTray.Properties;

namespace IPFSSystemTray
{
    class IPFSSystemTray : ApplicationContext
    {

        Epona configWindow = new Epona();
        NotifyIcon notifyIcon = new NotifyIcon();
        private MenuItem configMenuItem;
        private MenuItem exitMenuItem;
        static public bool IsVisible = false;

        public IPFSSystemTray()
        {
            configMenuItem = new MenuItem("Show", new EventHandler(ShowConfig));
            exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));
            notifyIcon.Icon = Resources.AppIcon;
            notifyIcon.ContextMenu = new ContextMenu(new MenuItem[]
                { configMenuItem, exitMenuItem });
            notifyIcon.Visible = true;
            notifyIcon.Click += new System.EventHandler(this.ShowConfig);
            //configWindow.LostFocus += new System.EventHandler(this.onLostFocus);
            configWindow.Deactivate += new System.EventHandler(this.onLostFocus);
            notifyIcon.Text = "Epona";
        }

        private void onLostFocus(object sender, EventArgs e)
        {
            SetPopupPosition();
            configWindow.Hide();
            IsVisible = false;
        }


        void ShowConfig(object sender, EventArgs e)
        {
            SetPopupPosition();
            // If we are already showing the window, merely focus it.
            if (!IsVisible)
            {
                configWindow.Show();
                configWindow.BringToFront();
                configMenuItem.Text = "Hide";
            }
            else
            {
                configWindow.Hide();
                configMenuItem.Text = "Show";
            }

            IsVisible = !IsVisible;
            SetPopupPosition();
        }

        void SetPopupPosition()
        {
            if (Taskbar.Position == TaskbarPosition.Bottom)
            {
                configWindow.Left = Cursor.Position.X - (configWindow.Width / 2);
                configWindow.Top = Screen.PrimaryScreen.WorkingArea.Bottom - configWindow.Height;
            }
            else if (Taskbar.Position == TaskbarPosition.Right)
            {
                configWindow.Left = Screen.PrimaryScreen.WorkingArea.Right - configWindow.Width;
                configWindow.Top = Cursor.Position.Y - (configWindow.Height / 2);
            }
            else if (Taskbar.Position == TaskbarPosition.Left)
            {
                configWindow.Left = Screen.PrimaryScreen.WorkingArea.Left;
                configWindow.Top = Cursor.Position.Y - (configWindow.Height / 2);
            }
            else if (Taskbar.Position == TaskbarPosition.Top)
            {
                configWindow.Left = Cursor.Position.X - (configWindow.Width / 2);
                configWindow.Top = Screen.PrimaryScreen.WorkingArea.Top;
            }
        }

        void Exit(object sender, EventArgs e)
        {
            // We must manually tidy up and remove the icon before we exit.
            // Otherwise it will be left behind until the user mouses over.
            notifyIcon.Visible = false;
            Application.Exit();
        }
    }
}
