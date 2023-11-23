using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace TheRestLauncher.Pages
{

    public partial class News : Page
    {
        public News()
        {
            InitializeComponent();
            Whats_New();
        }

       public void Whats_New()
        {
            string text = "C:\\TheRest\\Launcher\\Whats_New";
            string Read = File.ReadAllText(text);

            WN.Text = Read;
            
        }


    }
}
