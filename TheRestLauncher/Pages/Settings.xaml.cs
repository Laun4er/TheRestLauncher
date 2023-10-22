using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows.Controls.Primitives;
using System.IO;
using Microsoft.Win32;
using System.Net;
using System.ComponentModel;
using System.IO.Compression;
using System.Threading;
using System.Windows.Threading;

namespace TheRestLauncher.Pages
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {

        private BackgroundWorker worker;

        public Settings()
        {
            InitializeComponent();

            worker = new BackgroundWorker(); //Прогресс Бар
            worker.WorkerReportsProgress = true;
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;

        }

        WebClient client = new WebClient();

        //Стринги

        string DeleteMods = "C:\\TheRest\\game\\Minecraft\\mods";
        string CreateTemp = "C:\\TheRest\\Temp\\";
        string SavePath = "C:\\TheRest\\Temp\\";
        string Extract = "C:\\TheRest\\game\\Minecraft\\";
        string DownloadMods = "https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1QiAInjQaL5OiHrkVWlhWPCTtVswGYBFz";
        string DeleteTemp = "C:\\TheRest\\Temp";
        string forExtract = "C:\\TheRest\\Temp\\mods.zip";

        private void Worker_DoWork (object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 10; i++)
            {
                Directory.Delete(DeleteMods, true);

                worker.ReportProgress(i);

            }
            for (int i = 10; i <= 20; i++)
            {
                Directory.CreateDirectory(CreateTemp);
                worker.ReportProgress(i);
            }
            for (int i=20; i <= 60; i++)
            {
                client.DownloadFile(DownloadMods, SavePath + "mods.zip");
                worker.ReportProgress (i);
            }
            for (int i=60; i <=90; i++)
            {
                ZipFile.ExtractToDirectory(forExtract, Extract);
                worker.ReportProgress(i);
            }
            for (int i=90;  i <=100; i++)
            {
                Directory.Delete(DeleteTemp, true);
                worker.ReportProgress(i);
            }
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar.Value = e.ProgressPercentage;
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
            worker.RunWorkerAsync();
        }
    }

}
