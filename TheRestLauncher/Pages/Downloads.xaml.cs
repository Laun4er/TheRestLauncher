using System.Windows.Controls;
using TheRestLauncher.Dev;

namespace TheRestLauncher.Pages
{
    /// <summary>
    /// Логика взаимодействия для Downloads.xaml
    /// </summary>
    public partial class Downloads : Page
    {
        public Downloads()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DevMode mode = new DevMode();
            mode.Show();
        }
    }
}
