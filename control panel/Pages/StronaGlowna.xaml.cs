using Notifications.Wpf;
using System;
using System.Windows;
using System.Windows.Controls;

namespace control_panel.Pages
{
    public partial class StronaGlowna : UserControl
    {
        private readonly NotificationManager _notificationManager = new NotificationManager();
        public StronaGlowna()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //LiveTimeLabel.Content = DateTime.Now.ToString("HH:mm:ss");
        }

        private void Graj_Button(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", $"fivem://connect/hovelrp.pl");
        }
    }
}
