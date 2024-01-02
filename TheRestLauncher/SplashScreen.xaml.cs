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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using TheRest;

namespace TheRestLauncher
{
    public partial class SplashScreen : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        public SplashScreen()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Start();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Storyboard sb = this.FindResource("ColorTransition") as Storyboard;
            sb.Begin();
        }

        public void OpenMainWindow(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            timer.Stop();

            Storyboard sb = this.FindResource("CloseSplash") as Storyboard;
            sb.Begin();
        }
        public void CloseSplash(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    class Problems()
    {

    }
    public class Updater()
    {

    }
}