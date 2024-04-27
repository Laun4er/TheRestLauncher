using System.Windows;
using TheRestLauncher.Resources;
using TheRestLauncher.Settings;

namespace TheRestLauncher
{
    public partial class FirstStartLauncher : Window
    {
        public FirstStartLauncher()
        {
            InitializeComponent();
            Content.Text = Assets.What_s_New;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Launcher.Default.FirstStart = "True";
            Launcher.Default.Save();
            this.Close();
        }
    }
}
