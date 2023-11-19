using System;
using System.Collections.Generic;
using System.IO;
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

namespace TheRestLauncher.Pages
{

    public partial class News : Page
    {
        public News()
        {
            InitializeComponent();
            What_New();
        }

        public void What_New()
        {
            string txt = "/Resources/Whats_New.txt";
            string Read = File.ReadAllText(txt);

            WN.Text = Read;
        }
    }
}
