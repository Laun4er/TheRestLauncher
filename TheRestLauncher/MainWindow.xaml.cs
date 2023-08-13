using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheRest;

namespace TheRest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PlayM(object sender, RoutedEventArgs e)
        {
            Process.Start("C:\\TheRest\\Minecraft\\launcher\\Play.bat");
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
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



