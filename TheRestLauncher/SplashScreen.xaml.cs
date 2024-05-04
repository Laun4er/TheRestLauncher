using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using TheRest;
using TheRestLauncher.Settings;

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
            string StartFirst = Launcher.Default.FirstStart;
            if (StartFirst == "False")
            {
                MainWindow window = new MainWindow();
                window.Show();
            }
            else
            {
                FirstStartLauncher launcher = new FirstStartLauncher();
                launcher.Show();
            }
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