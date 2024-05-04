using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using TheRest;
using TheRestLauncher.Resources;
using TheRestLauncher.Settings;

namespace TheRestLauncher.Pages
{
    public partial class DevMode : Page
    {
        public delegate void ImageChanger(string imageKey);
        public event ImageChanger ImageChangerIvent;
        public DevMode()
        {
            InitializeComponent();
        }

        private void RefreshAll_Click(object sender, RoutedEventArgs e)
        {
            Launcher.Default.FirstStart = "False";
            Launcher.Default.Nickname = "Steve";
            Launcher.Default.Save();
        }

        private void checklauncher_Click(object sender, RoutedEventArgs e)
        {
            Nick.Text = "Никнейм:" + Launcher.Default.Nickname;
            firststart.Text = "Первый запуск:" + Launcher.Default.FirstStart;
        }

        private void Checkminecraftset_Click(object sender, RoutedEventArgs e)
        {
            textRam.Text = "ОЗУ: " + StartMinecraft.Default.mRAM.ToString();
            textWidth.Text = "Ширина: " + StartMinecraft.Default.mWidth.ToString();
            textHeight.Text = "Высота: " +  StartMinecraft.Default.mHeight.ToString();
            textFull.Text = "Полноэкранный: " + StartMinecraft.Default.mFullScreen.ToString();
            Descript.Text = "Если параметр полноэкранного режима включен, то ширина и высота отключается";
        }
    }
}
