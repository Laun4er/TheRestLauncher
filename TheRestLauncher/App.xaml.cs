using System.Runtime.CompilerServices;
using System.Windows;
using TheRest;
using TheRestLauncher.Settings;

namespace TheRestLauncher
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            SplashScreen screen = new SplashScreen();
            screen.Show();
        }
    }
}