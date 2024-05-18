using DiscordRPC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.Reflection.Metadata.Ecma335;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using TheRestLauncher.Classes;
using TheRestLauncher.Pages;
using TheRestLauncher.Settings;

namespace TheRest
{
    public partial class MainWindow : Window
    {
        private Dictionary<string, Page> pages = new Dictionary<string, Page>();

        private Discord_Rich_Presence DRPC;
        public MainWindow()
        {
            InitializeComponent();
            DRPC = new Discord_Rich_Presence("1237463189722103838"); //Заменить на новый
            DRPC.UpdatePresence("Игровое меню");
            HappyBird();
            User.Text = Launcher.Default.Nickname;

            pages.Add("Main", new Main());
            pages.Add("News", new News());
            pages.Add("Mods", new Mods());
            pages.Add("Profile", new Profile());
            pages.Add("Settings", new Settings());

            PageFrame.Content = pages["Main"];
        }
        public void HappyBird()
        {
            if(DateTime.Now.Date == new DateTime(DateTime.Now.Year, 11, 5))
            {
                SeaSon.Text = "С днём рождения, Karvane🎂";
                return;
            }
            if (DateTime.Now.Date == new DateTime(DateTime.Now.Year, 12, 17))
            {
                SeaSon.Text = "С днём рождения, Laun4er🎂";
                return;
            }
            if (DateTime.Now.Date == new DateTime(DateTime.Now.Year, 4, 1))
            {
                SeaSon.Text = "С днём рождения, izumrudic01🎂";
                return;
            }
          if (DateTime.Now.Date == new DateTime(DateTime.Now.Year, 9, 18))
            {
                SeaSon.Text = "С днём рождения, Ivantuz🎂";
                return;
            }
           if (DateTime.Now.Date == new DateTime(DateTime.Now.Year, 6, 8))
            {
                SeaSon.Text = "С днём рождения, Muyklaaa:3🎂";
                return;
            }
            else
            {
                SeaSon.Text = "TheRest: SEASON 2";
            }
        } //Пасхалка с днями рождения
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
                    Page pageInstance = pages[selectedListBoxItem.Name];
                    PageFrame.Content = pageInstance;
                    foreach (var tabControl in FindVisualChildren<TabControl>(pageInstance))
                    {
                        tabControl.SelectedIndex = 0;
                    }
                    if (pageInstance is Page page && page.Title != null)
                    {
                        DRPC.UpdatePresence(page.Title);
                    }
                }
            }
        }
        private IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void ChangeNick_Click(object sender, RoutedEventArgs e)
        {
            ListBox1.SelectedIndex = 0;
            ListBox2.SelectedIndex = 0;
        }

        private void TheRestLogoColored_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Уникальный логотип TheRest", "TheRest");
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
            e.Handled = e.ChangedButton == MouseButton.Left && e.OriginalSource is FrameworkElement originalSource && originalSource.Parent != null;
        }

        #endregion

    }
}