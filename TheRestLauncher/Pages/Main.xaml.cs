using System;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace TheRestLauncher.Pages
{
    public partial class Main : Page
    {
        private const string ServerVer = "";
        private const string LocalVer = "";
        public Main()
        {
            InitializeComponent();
        }
        private void PlayM(object sender, RoutedEventArgs e)
        {
            if(Start != null)
            {
                Start.Visibility = Visibility.Hidden;
                StartM.Visibility = Visibility.Visible;
            }
            CheckVersion();
        }

        private async void CheckVersion()
        {
            string LocalVerContent = LoadLocalFile();
            if (LocalVerContent == null)
            {
                MessageBox.Show("Обратитесь к Laun4er за помощью", "Проблема с загрузкой локальной версии", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            string ServerVerContent = LoadServerFile();
            if (ServerVerContent == null)
            {
                MessageBox.Show("Обратитесь к Laun4er за помощью", "Проблема с загрузкой серверного обновления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (LocalVerContent.Equals(ServerVerContent))
            {

            }
            else
            {
                NewSeason();

            }

        }
        private string LoadLocalFile()
        {
            try
            {
                return File.ReadAllText(LocalVer);
            }
            catch (Exception)
            {
                return null;
            }
        }
        private string LoadServerFile()
        {
            try
            {
                using (var client = new WebClient())
                {
                    return client.DownloadString(ServerVer);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void CheckMinecraft()
        {

        }

        private void Play()
        {
            string StartM = "C:\\TheRest\\Launcher\\StartM.bat";

            Process myProcess = new Process();
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.FileName = StartM;
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.Start();
        }
        
        public void NewSeason()
        {

        }
        
        public void DownloadMinecraft()
        {

        }

        public void RestoreFiles()
        {

        }
    }
}
