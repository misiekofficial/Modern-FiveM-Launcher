using control_panel.Pages;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;

namespace control_panel
{
    //główne okno [Misiek <3]
    public partial class MainWindow : Window
    {

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
