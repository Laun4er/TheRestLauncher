using System.Windows;
using TheRest;

namespace TheRestLauncher.MessageBoxes
{
    public partial class ResetAll : Window
    {
        public ResetAll()
        {
            InitializeComponent();
        }

        private void none_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void apply_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Close();
            this.Close();
        }
    }
}
