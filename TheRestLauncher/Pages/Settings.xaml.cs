using System.Runtime.CompilerServices;
using System.Windows.Controls;
using TheRestLauncher.Classes;
using TheRestLauncher.Settings;

namespace TheRestLauncher.Pages
{

    public partial class Settings : Page
    {
        private bool RPC;
        private Discord_Rich_Presence DRPC;
        public Settings()
        {
            InitializeComponent();
        }

        private void enableRPC_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DRPC.toggle();
        }
    }
}
