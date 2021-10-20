using Notifications.Wpf;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace control_panel.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy ListaSerwerow.xaml
    /// </summary>
    public partial class ListaSerwerow : UserControl
    {
        Process[] SteamRunning = Process.GetProcessesByName("steam");
        public ListaSerwerow()
        {
            InitializeComponent();
            ServerListColumn.ItemsSource = Servers.LoadListBoxData();
        }

        private void ServerListButtonConnect(object sender, RoutedEventArgs e)
        {
            if (SteamRunning.Length != 0)
            {
                var notificationManager = new NotificationManager();
                string textip = ((ServerComponents)ServerListColumn.SelectedItem).IP.ToString();
                notificationManager.Show(new NotificationContent
                {
                    Title = "Powiadomienie",
                    Message = "Łączenie z Serwerem ...",
                    Type = NotificationType.Success
                });
                Thread.Sleep(3999);
                System.Diagnostics.Process.Start("explorer.exe", $"fivem://connect/" + textip);
            }
            else
            {
                var notificationManager = new NotificationManager();
                notificationManager.Show(new NotificationContent
                {
                    Title = "Powiadomienie",
                    Message = "Nie wykryto uruchomionego Steam'a, prosimy zalogować się i spróbować ponownie później...",
                    Type = NotificationType.Error
                });
                return;
            }

        }
    }
}
