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
