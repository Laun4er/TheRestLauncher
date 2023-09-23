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
using System.Windows.Controls.Primitives;
using System.IO;


namespace TheRestLauncher.Pages
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            string Update = "C:\\TheRest\\Updater\\Updater.exe";
            Process.Start(Update);
            App.Current.Shutdown();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            String ChangeNick = "C:\\TheRest\\Launcher\\ChangeNick\\Change Nickname.exe";

            MessageBox.Show("Смена ника пока не готова, ожидайте следующее обновление", "Смена ников");
        }

        private void Reload_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Переустановка клиента невозможна на данный момент", "Переустановка клиента");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Обновление недоступно", "Обновление клиента");
        }

        private void GoM_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Скоро", "Открытие папки майнккрафт");
        }
    }
}
