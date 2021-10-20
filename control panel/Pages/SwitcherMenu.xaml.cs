using control_panel;
using System.Windows;
using System.Windows.Controls;

namespace control_panel.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy SwitcherMenu.xaml
    /// </summary>
    public partial class SwitcherMenu : UserControl
    {
        public SwitcherMenu()
        {
            InitializeComponent();
        }

        private void GameChange_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new GameSelector());
        }

        private void StronaGlowna_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new StronaGlowna());
        }

        private void List_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new ListaSerwerow());
        }
    }
}
