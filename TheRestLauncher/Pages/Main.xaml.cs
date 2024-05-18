using CmlLib.Core;
using CmlLib.Core.Auth;
using CmlLib.Core.Installer.Forge;
using System.Windows;
using System.Windows.Controls;
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
           
            var minecraftPath = new MinecraftPath();
            var launcher = new CMLauncher(minecraftPath);
            launcher.ProgressChanged += ProgressBarChanged;
            var forge = new MForge(launcher);
            forge.ProgressChanged += ProgressBarChanged;
            var versionName = await forge.Install("1.20.1");

            var launchOption = new MLaunchOption
            {
                MaximumRamMb = StartMinecraft.Default.mRAM,
                ScreenHeight = StartMinecraft.Default.mHeight,
                ScreenWidth = StartMinecraft.Default.mWidth,
                FullScreen = StartMinecraft.Default.mFullScreen,
                Session = MSession.GetOfflineSession(nickname),
            };
            var process = await launcher.CreateProcessAsync(versionName, launchOption);
            process.Start();
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
