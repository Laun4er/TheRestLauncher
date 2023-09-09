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
            string name = NickName.Text;

            string batFilePath = @"C:\TheRest\Minecraft\launcher\PlayM.bat";


            string content = File.ReadAllText(batFilePath);


            content = content.Replace("{name}", name);


            File.WriteAllText(batFilePath, content);

            Process.Start("C:\\TheRest\\Minecraft\\launcher\\PlayM.bat");
        }
    }
}
