using System.IO;
using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Controls;
using CmlLib.Core;
using CmlLib.Core.Auth;
using CmlLib.Core.Installer.Forge;
using TheRest;
using TheRestLauncher.Settings;

namespace TheRestLauncher.Pages
{
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
        }
        private async void PlayM(object sender, RoutedEventArgs e)
        {
            

            string nickname = Launcher.Default.Nickname;

            var main = (MainWindow)Application.Current.MainWindow;
            main.ListBox1.IsEnabled = false;
            main.ListBox2.IsEnabled = false;
            main.ChangeNick.IsEnabled = false;

            if (Start != null)
            {
                Start.Visibility = Visibility.Hidden;
                progressDown.Visibility = Visibility.Visible;
            }
            var minecraftPath = new MinecraftPath();
            var launcher = new CMLauncher(minecraftPath);
            launcher.ProgressChanged += ProgressBarChanged;
            var forge = new MForge(launcher);
            forge.ProgressChanged += ProgressBarChanged;
            var versionName = await forge.Install("1.20.1");
            var launchOption = new MLaunchOption
            {
                MaximumRamMb = int.Parse(StartMinecraft.Default.mRAM),
                ScreenHeight = int.Parse(StartMinecraft.Default.mHeight),
                ScreenWidth = int.Parse(StartMinecraft.Default.mWidth),
                FullScreen = bool.Parse(StartMinecraft.Default.mFullScreen),
                Session = MSession.GetOfflineSession(nickname),
            };
            var process = await launcher.CreateProcessAsync(versionName, launchOption);
            process.Start();
            main.ListBox1.IsEnabled = true;
            main.ListBox2.IsEnabled = true;
            main.ChangeNick.IsEnabled = true;
            progressDown.Visibility = Visibility.Hidden;
            Start.Visibility = Visibility.Visible;
        }
        private async void ProgressBarChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e) //прогрессбар
        {
            this.Dispatcher.Invoke(() =>
            {
                progressDown.Value = e.ProgressPercentage;
            });
        }
    }
}
