using Notifications.Wpf;
using System.Windows;

namespace control_panel.loginpanel
{
    //panel do logowanie się [Misiek <3]
    public partial class registerpanel : Window
    {
        private readonly NotificationManager _notificationManager = new NotificationManager();
        public registerpanel()
        {
            InitializeComponent();
        }

        //by osoba mogła sie zalogować musi podać developerowi dane którymi będzie się logował [Misiek <3][ps. nie chciało mi się robić pod bazę danych więc tak jest hehe :)]
        private void Button_Login_1(object sender, RoutedEventArgs e)
        {
            if (TextBoxEmail.Text == "misiek" && TextPassword.Password == "misiek123")
            {
                MainWindow wnd = new MainWindow();
                this.Close();
                wnd.Show();

                var content = new NotificationContent
                {
                    Title = "Sukces!",
                    Message = "Zalogowano się",
                    Type = NotificationType.Success
                };
                _notificationManager.Show(content);
            }
            else
            {
                var content = new NotificationContent
                {
                    Title = "Błąd przy logowaniu się",
                    Message = "Wprowadzony pseudonim lub hasło został wprowadzony błędnie, spróbuj ponownie",
                    Type = NotificationType.Error
                };
                _notificationManager.Show(content);
            }
        }
    }
}
