using CmlLib.Core;
using CmlLib.Core.Auth;
using CmlLib.Core.Downloader;
using CmlLib.Core.Installer.Forge;
using System.Threading.Tasks;
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
        private async void PlayM()
        {
            string nickname = Launcher.Default.Nickname;

            StartM.Visibility = Visibility.Hidden;
            progressDown.Visibility = Visibility.Visible;

            var minecraftPath = new MinecraftPath();
            var launcher = new CMLauncher(minecraftPath);
            launcher.ProgressChanged += ProgressBarChanged;
            var forge = new MForge(launcher);
            forge.ProgressChanged += ProgressBarChanged;
            var versionName = await forge.Install("1.20.1");
            

            var launchOption = new MLaunchOption
            {
                MaximumRamMb = Minecraft.Default.WinRAM,
                ScreenHeight =Minecraft.Default.WinHeigh,
                ScreenWidth = Minecraft.Default.WinWidth,
                FullScreen = Minecraft.Default.WinFull,
                Session = MSession.GetOfflineSession(nickname),
            };
            var process = await launcher.CreateProcessAsync(versionName, launchOption);
            process.Start();

            StartM.Visibility = Visibility.Visible;
            progressDown.Visibility = Visibility.Hidden;
        }
        private async void ProgressBarChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e) //прогрессбар
        {
            this.Dispatcher.Invoke(() =>
            {
                progressDown.Value = e.ProgressPercentage;
                Percentage.Content = $"{e.ProgressPercentage}%";
            });
        }

        private async void Start_Click(object sender, RoutedEventArgs e)
        {
            PlayM();
            
        }
    }
}
