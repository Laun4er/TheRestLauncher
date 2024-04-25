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
using System.Windows.Shapes;
using TheRest;
using TheRestLauncher.Settings;

namespace TheRestLauncher.Dev
{
    public partial class DevMode : Window
    {
        public DevMode()
        {
            InitializeComponent();
        }

        private void RestartL_Click(object sender, RoutedEventArgs e)
        {
            Launcher.Default.Nickname = "Steve";
            Launcher.Default.FirstStart = "False";
            Launcher.Default.Save();

            MainWindow window = new MainWindow();
            window.Close();
            this.Close();
        }
    }
}
