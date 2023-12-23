using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Controls;

namespace TheRestLauncher.Pages
{
    
    public partial class Settings : Page
    {
        private const string arguments = "C:\\TheRest\\Launcher\\TheRest.arg";

        WebClient client = new WebClient();

        public Settings()
        {
            InitializeComponent();
            CheckUpdate();
        }

        public void CheckUpdate()
        {
            string arg = arguments;
            int line = 10;
            string A1 = "AllowUpdate = true";
            string A2 = "AllowUpdate = false";
            string[] rline = File.ReadAllLines(arg);

            if (rline[line - 1] == A1)
            {
                AllowUpdate.Content = "Обновления разрешены";
            }
            else
            {
                AllowUpdate.Content = "Обновления запрещены";
            }
        }
        private void AllowUpdate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string arg = arguments;
            int lineToReplace = 10;
            string text1 = "AllowUpdate=true";
            string text2 = "AllowUpdate=false";

            string[] line = File.ReadAllLines(arg);
            if (line[lineToReplace - 1] == text1)
            {
                line[lineToReplace - 1] = text2;
                AllowUpdate.Content = "Обновления запрещены";
            }
            else
            {
                line[lineToReplace - 1] = text1;
                AllowUpdate.Content = "Обновления разрешены";
            }
            File.WriteAllLines(arg, line);
        }
    }
    

}
