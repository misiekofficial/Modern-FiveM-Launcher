using control_panel.Pages;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;

namespace control_panel
{
    //główne okno [Misiek <3]
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        public static extern int FindWindowEx(int hwndParent, int hwndEnfant, int lpClasse, string lpTitre);

        public MainWindow()
        {
            InitializeComponent();

            Switcher.pageSwitcher = this;
            Switcher.Switch(new StronaGlowna());
        }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }
    }
}
