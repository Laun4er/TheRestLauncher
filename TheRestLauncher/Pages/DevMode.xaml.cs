using System.Windows;
using System.Windows.Controls;
using TheRest;
using TheRestLauncher.Settings;

namespace TheRestLauncher.Pages
{
    public partial class DevMode : Page
    {
        public DevMode()
        {
            InitializeComponent();
        }

        private void RefreshAll_Click(object sender, RoutedEventArgs e)
        {
            Launcher.Default.FirstStart = "False";
            Launcher.Default.Nickname = "Steve";
            Launcher.Default.Save();
        }

        private void checklauncher_Click(object sender, RoutedEventArgs e)
        {
            Nick.Text = "Никнейм:" + Launcher.Default.Nickname;
            firststart.Text = "Первый запуск:" + Launcher.Default.FirstStart;
        }

        private void Checkminecraftset_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
