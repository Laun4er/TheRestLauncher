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
using System.IO;
using System.Net;
using System.IO.Compression;

namespace TheRestLauncher.Pages
{
    public partial class Mods : Page
    {
        public Mods()
        {
            InitializeComponent();
        }

        private void StackPanel_DragEnter()
        {

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            string DeleteMods = "";
            string CteateTemp = "";
            string Extract = "";
            string DownloadMods = "";
            string Temp = "";
            string DeleteTemp = "";

            WebClient client = new WebClient();

            Directory.Delete(DeleteMods, true);
            Directory.CreateDirectory(CteateTemp);
            client.DownloadFile(DownloadMods, Temp + "Mods.zip");
            ZipFile.ExtractToDirectory(Temp, Extract);
            Directory.Delete(DeleteTemp, true);
            MessageBox.Show("Успешно переустановлено", "Переустановка сборки");
            
        }
    }
}
