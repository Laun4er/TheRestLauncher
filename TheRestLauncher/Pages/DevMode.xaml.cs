using System.Windows;
using System.Windows.Controls;
using TheRest;
using TheRestLauncher.Settings;
using TheRestLauncher.MessageBoxes;

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
            ResetAll reset = new ResetAll();
            reset.Show();
        }

        private void checklauncher_Click(object sender, RoutedEventArgs e)
        {
            Nick.Text = "Никнейм:" + Launcher.Default.Nickname;
            firststart.Text = "Первый запуск:" + Launcher.Default.FirstStart;
        }
    }
}
