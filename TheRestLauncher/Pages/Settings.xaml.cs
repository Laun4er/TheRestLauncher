using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows;
using System.Windows.Controls;

namespace TheRestLauncher.Pages
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {

        private BackgroundWorker worker;
        
        WebClient client = new WebClient();

        public Settings()
        {

            InitializeComponent();
        }       


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

        private void Restore_Click(object sender, RoutedEventArgs e)
        {
            string DeleteMods = "C:\\TheRest\\game\\Minecraft\\mods";
            string CreateTemp = "C:\\TheRest\\Temp\\";

            Directory.Delete(DeleteMods, true);
            Directory.CreateDirectory(CreateTemp);

            worker.DoWork += DownloadDoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.WorkerReportsProgress = true;
            worker.RunWorkerAsync();
        }
        private void DownloadDoWork(object sender, DoWorkEventArgs e)
        {
            
            
            for(int i = 0; i < 100 ; i++)
            {

               
                string URL = "https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1QiAInjQaL5OiHrkVWlhWPCTtVswGYBFz";
                string Temp = "C:\\TheRest\\Temp";
                string Extract = "C:\\TheRest\\game\\Minecraft\\";
                string forExtract = "C:\\TheRest\\Temp\\mods.zip";

                client.DownloadFile(URL, Temp + "mods.zip");
                ZipFile.ExtractToDirectory(forExtract, Extract);


                int progressPercentage = (int)((i + 1) / (double)1 * 100);

                (sender as BackgroundWorker).ReportProgress(progressPercentage);
            }
        }
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string DeleteTemp = "C:\\TheRest\\Temp";
            Directory.Delete(DeleteTemp, true);
            MessageBox.Show("Моды были сброшены по умолчанию", "Сброс модов");
        }

    }
    

}
