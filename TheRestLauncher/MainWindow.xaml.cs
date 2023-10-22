using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.ServiceProcess;
using TheRest;
using TheRestLauncher;
using System.Diagnostics.Metrics;
using TheRestLauncher.Pages;
using System.IO;
using System.Net;
using System.Diagnostics.Eventing.Reader;
using System.IO.Compression;

namespace TheRest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CheckFiles();
            PageFrame.Content = new Main();
            User.Text = File.ReadAllText("C:\\TheRest\\User\\Data\\User.txt");

        }
        private void CheckFiles()
        {
            //стринги
            string mods = "C:\\TheRest\\Minecraft\\game\\mods";

            if (Directory.Exists(mods)) //Если не найдена папка с модами, то скачивается новая папка
            {

            }
            else 
            {
                nomods();
            }
        }

        private void nomods ()
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
            MessageBox.Show("Не удалось сменить ник"); //Смена ника
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