using System.Windows;
using TheRest;
using TheRestLauncher.Settings;

namespace TheRestLauncher
{
    public partial class FirstStartLauncher : Window
    {
        public FirstStartLauncher()
        {
            InitializeComponent();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Launcher.Default.FirstStart = "True";
            Launcher.Default.Save();
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
