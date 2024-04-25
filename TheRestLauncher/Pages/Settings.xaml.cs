using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using TheRest;
using TheRestLauncher.Dev;
using TheRestLauncher.Settings;

namespace TheRestLauncher.Pages
{

    public partial class Settings : Page
    {

        public Settings()
        {
            InitializeComponent();
        }

        private void Set_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Launcher.Default.Nickname = setNick.Text;
            Launcher.Default.Save();
            var main = (MainWindow)Application.Current.MainWindow;
            main.Property = setNick.Text;
            main.UpdateUserName();
            setNick.Clear();
        }

        
    }
}
