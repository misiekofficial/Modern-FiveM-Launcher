using control_panel;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace control_panel.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy GameSelector.xaml
    /// </summary>
    /// 
    public partial class GameSelector : UserControl
    {
        class ConsoleCategories
        {
            public string SendTime { get; set; }
            public string Text { get; set; }
        }

        static public bool FiveM = false;
        static public bool RedM = false;
        string UserDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        Process[] SteamProcess = Process.GetProcessesByName("steam");
        //Console Text
        public void SendConsoleMessage(string type, string text)
        {
            var dt = DateTime.Now;
            MyListView.Items.Add(new ConsoleCategories() { SendTime = "[" + dt.ToString("HH:mm:ss") + "]", Text = "["+ type +"]: => " + text});
        }

        public GameSelector()
        {
            InitializeComponent();

            this.FiveMButton.IsEnabled = false;
            this.RedMButton.IsEnabled = false;
            this.OnFiveM.IsEnabled = false;
            this.OnRedM.IsEnabled = false;
            this.CacheRedMButton.IsEnabled = false;
            this.CacheFiveMButton.IsEnabled = false;

            SendConsoleMessage("LOADING", "Sprawdzanie gier na twoim dysku...");

            if (Directory.Exists(UserDir + "/FiveM"))
            {
                this.FiveMButton.IsEnabled = true;
                this.OnFiveM.IsEnabled = true;
                FiveM = true;
                SendConsoleMessage("SUCCESS", "Wykryto na twoim dysku grę FiveM");
            }
            else if (Directory.Exists(UserDir + "/RedM"))
            {
                this.OnRedM.IsEnabled = true;
                this.RedMButton.IsEnabled = true;
                RedM = true;
                SendConsoleMessage("SUCCESS", "Wykryto na twoim dysku grę RedM");
            }
            else
            {
                this.FiveMButton.IsEnabled = false;
                this.RedMButton.IsEnabled = false;
                SendConsoleMessage("WARNING", "Nie wykryliśmy żadnej gry na twoim dysku");
            }
        }

        private void RedM_Switch(object sender, RoutedEventArgs e)
        {
            if (RedM == true)
            {
                this.OnRedM.IsEnabled = true;
                this.CacheRedMButton.IsEnabled = true;
            }
            else
            {
                this.OnRedM.IsEnabled = false;
                this.CacheRedMButton.IsEnabled = false;
            }
        }

        private void FiveM_Switch(object sender, RoutedEventArgs e)
        {
            if (FiveM == true)
            {
                this.OnFiveM.IsEnabled = true;
                this.CacheFiveMButton.IsEnabled = true;
            }
            else
            {
                this.OnFiveM.IsEnabled = false;
                this.CacheFiveMButton.IsEnabled = false;
            }
        }

        private void Cache_Button(object sender, RoutedEventArgs e)
        {
            var cache_files = new string[]
            {
                "server-cache",
                "server-cache-priv"
            };

            if (FiveM == true)
            {
                if (Directory.Exists(UserDir + "/FiveM"))
                {
                    try
                    {
                        Directory.Delete(UserDir + "/FiveM/FiveM.app/data/" + cache_files, true);
                        Thread.Sleep(3000);
                    }
                    catch (Exception err) { SendConsoleMessage("ERROR", "Nie znaleziono cache, lub został usunięty"); }
                }
                else
                {
                    SendConsoleMessage("ERROR", "Nie można znaleźć ścieżki FiveM");
                }
            }
            else if (RedM == true)
            {
                if (Directory.Exists(UserDir + "/RedM"))
                {
                    try
                    {
                        Directory.Delete(UserDir + "/RedM/RedM.app/cache", true);
                        Thread.Sleep(3000);
                    }
                    catch (Exception err) { SendConsoleMessage("ERROR", "Nie znaleziono cache, lub został usunięty"); }
                }
                else
                {
                    SendConsoleMessage("ERROR", "Nie można znaleźć ścieżki RedM");
                }
            }
        }

        private void Power_Button(object sender, RoutedEventArgs e)
        {
            if (FiveM == true && SteamProcess.Length != 0)
            {
                SendConsoleMessage("SUCCESS", "Uruchamianie aplikacji FiveM...");
                Process.Start(@"" + UserDir + "/FiveM/FiveM.exe");
            }
            else if(RedM == true && SteamProcess.Length != 0)
            {
                SendConsoleMessage("SUCCESS", "Uruchamianie aplikacji RedM...");
                Process.Start(@"" + UserDir + "/RedM/RedM.exe");
            }
            else
            {
                SendConsoleMessage("ERROR", "Nie jesteś zalogowany na Steam...");
            }
        }
    }
}
