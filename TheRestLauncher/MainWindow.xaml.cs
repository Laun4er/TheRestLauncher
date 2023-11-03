using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using TheRestLauncher;
using TheRestLauncher.Pages;

namespace TheRest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CheckFiles();
            HappyBird();
            PageFrame.Content = new Main();
            User.Text = File.ReadAllText("C:\\TheRest\\User\\Data\\User.txt");

        }

        private void HappyBird()
        {
            if(DateTime.Now.Date == new DateTime(DateTime.Now.Year, 11,5)) 
            {
                SeaSon.Text = "С днём рождения, Karvane!";
            }//Karvane

            if (DateTime.Now.Date == new DateTime(DateTime.Now.Year, 12, 17))
            {
                SeaSon.Text = "С днём рождения, Laun4er!";
            }//Laun4er

            if (DateTime.Now.Date == new DateTime(DateTime.Now.Year, 4, 1))
            {
                SeaSon.Text = "С днём рождения, Izumrudik01!";
            }//izumrudik01

            if (DateTime.Now.Date == new DateTime(DateTime.Now.Year, 1, 8))
            {
                SeaSon.Text = "С днём рождения, Zerokko!";
            }//Zerokko

            if (DateTime.Now.Date == new DateTime(DateTime.Now.Year, 9, 13))
            {
                SeaSon.Text = "С праздником, программисты!";
            }//Программисты

            if (DateTime.Now.Date == new DateTime(DateTime.Now.Year, 12, 31))
            {
                SeaSon.Text = "С Новым Годом!";
            }//НГ


            else
            {
                SeaSon.Text = "TheRest: SEASON 1";
            }//Сюда вписывать нумерацию сезона

        } //Пасхалка с днями рождения


        private void CheckFiles()
        {
            //стринги
            string mods = "C:\\TheRest\\Minecraft\\game\\mods";
            string jre = "C:\\TheRest\\Minecraft\\jre";

            if (Directory.Exists(mods)) //Если не найдена папка с модами, то скачивается новая папка
            {

            }
            else 
            {
                nomods();
            }
            
            if(Directory.Exists(jre))
            {

            }
            else
            {
                nojre();
            }

        }

        private void nojre() //Скачивание джавы, можно ещё прописать открытие отдельного окна
        {
        
        }

        private void nomods () //Скачивание папки с основными модами, можно также прописать открытие отдельного окна
        {
            WebClient client = new WebClient();

            string URL = "https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1QiAInjQaL5OiHrkVWlhWPCTtVswGYBFz";
            string CreateTemp = "C:\\TheRest\\Temp";
            string SavePath = "C:\\TheRest\\Temp\\";
            string Extract = "C:\\TheRest\\Minecraft\\game\\";
            string forExtract = "C:\\TheRest\\Temp\\mods.zip";
            string DeleteTemp = "C:\\TheRest\\Temp";

            Directory.CreateDirectory(CreateTemp);
            client.DownloadFile(URL, SavePath + "mods.zip");
            ZipFile.ExtractToDirectory(forExtract, Extract);
            Directory.Delete(DeleteTemp, true);

        }



        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }


        private void MinimizeButton(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeButton(object sender, RoutedEventArgs e)
        {
            switch (this.WindowState)
            {
                case WindowState.Maximized:
                    this.WindowState = WindowState.Normal;
                    break;
                case WindowState.Normal:
                    this.WindowState = WindowState.Maximized;
                    break;
            }
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool isInitialSelection = true;
        private void PageChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isInitialSelection)
            {
                isInitialSelection = false;
                return;
            }

            if (sender is ListBox listBox)
            {
                if (listBox.SelectedItem is ListBoxItem selectedListBoxItem)
                {
                    switch (listBox.Name)
                    {
                        case "ListBox1":
                            ListBox2.SelectedIndex = -1;
                            break;
                        case "ListBox2":
                            ListBox1.SelectedIndex = -1;
                            break;
                    }
                    Type PageType = Type.GetType($"TheRestLauncher.Pages.{selectedListBoxItem.Name}");
                    PageFrame.Content = Activator.CreateInstance(PageType);
                }
            }
        }

        private void ChangeNick_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(new Uri("/Pages/Settings.xaml", UriKind.Relative));
            

        }
    }
    public static class SelectorBehavior
    {
        #region bool ShouldSelectItemOnMouseUp

        public static readonly DependencyProperty ShouldSelectItemOnMouseUpProperty =
            DependencyProperty.RegisterAttached(
                "ShouldSelectItemOnMouseUp", typeof(bool), typeof(SelectorBehavior),
                new PropertyMetadata(default(bool), HandleShouldSelectItemOnMouseUpChange));

        public static void SetShouldSelectItemOnMouseUp(DependencyObject element, bool value)
        {
            element.SetValue(ShouldSelectItemOnMouseUpProperty, value);
        }

        public static bool GetShouldSelectItemOnMouseUp(DependencyObject element)
        {
            return (bool)element.GetValue(ShouldSelectItemOnMouseUpProperty);
        }

        private static void HandleShouldSelectItemOnMouseUpChange(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Selector selector)
            {
                selector.PreviewMouseDown -= HandleSelectPreviewMouseDown;
                selector.MouseUp -= HandleSelectMouseUp;

                if (Equals(e.NewValue, true))
                {
                    selector.PreviewMouseDown += HandleSelectPreviewMouseDown;
                    selector.MouseUp += HandleSelectMouseUp;
                }
            }
        }

        private static void HandleSelectMouseUp(object sender, MouseButtonEventArgs e)
        {
            var selector = (Selector)sender;

            if (e.ChangedButton == MouseButton.Left && e.OriginalSource is Visual source)
            {
                var container = selector.ContainerFromElement(source);
                if (container != null)
                {
                    var index = selector.ItemContainerGenerator.IndexFromContainer(container);
                    if (index >= 0)
                    {
                        selector.SelectedIndex = index;
                    }
                }
            }
        }

        private static void HandleSelectPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var originalSource = e.OriginalSource as FrameworkElement;
            e.Handled = e.ChangedButton == MouseButton.Left && originalSource != null && originalSource.Parent != null;
        }

        #endregion

    }
}