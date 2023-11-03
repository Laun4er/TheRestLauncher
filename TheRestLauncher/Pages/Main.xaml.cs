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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Xml.Linq;
using System.IO;

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


            string StartM = "C:\\TheRest\\Launcher\\StartM.bat";

            Process myProcess = new Process();
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.FileName = StartM;
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.Start();


        }
    }
}
