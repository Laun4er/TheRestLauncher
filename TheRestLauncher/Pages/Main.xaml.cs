using System.Windows;
using System.Windows.Controls;

namespace TheRestLauncher.Pages
{
    public partial class Main : Page
    {
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
        }
    }
}
