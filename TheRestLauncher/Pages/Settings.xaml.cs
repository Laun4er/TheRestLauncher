using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows;
using System.Windows.Controls;

namespace TheRestLauncher.Pages
{
    public partial class Settings : Page
    {

               
        WebClient client = new WebClient();

        public Settings()
        {

            InitializeComponent();
        }

        #region
        // Кнопки
        private void DonateDev_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.donationalerts.com/r/launcher1888") { UseShellExecute = true });
        }

        private void DonateServer_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.donationalerts.com/r/zvezdokot") { UseShellExecute = true });
        }

        private void YouTube_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.youtube.com/channel/UCsB5ly0G_P14UpBzGHYxNcQ") { UseShellExecute = true });
        }

        private void TikTok_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.tiktok.com/@therestmc") { UseShellExecute = true });
        }

        private void VK_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://vk.com/therestmc") { UseShellExecute = true });
        }
        #endregion
        private void Restore_Click(object sender, RoutedEventArgs e)
        {
            string URL = "https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1BkBW3P__uD8c7yzfHv_itUePQCC0ttKS";
            string SavePath = "C:\\TheRest\\Temp\\";
            string Createtemp = "C:\\TheRest\\Temp";
            string DeleteTemp = "C:\\TheRest\\Temp";
            string DeleteMods = "C:\\TheRest\\Minecraft\\game\\mods";
            string Extract = "C:\\TheRest\\Minecraft\\game\\";
            string ZIP = "C:\\TheRest\\Temp\\mods.zip";


            Directory.CreateDirectory(Createtemp);
            Directory.Delete(DeleteMods, true);
            client.DownloadFile(URL, SavePath + "mods.zip");
            ZipFile.ExtractToDirectory(ZIP, Extract);
            Directory.Delete(DeleteTemp, true);
        }

        private void ChangeNick_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
    

}
