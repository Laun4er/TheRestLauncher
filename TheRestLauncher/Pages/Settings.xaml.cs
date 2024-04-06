using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace TheRestLauncher.Pages
{

    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void q1_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            double H = q1.ActualHeight;

            double currentHeight = q1.ActualHeight;

            DoubleAnimation heightAnimation = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(3),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };

            if (currentHeight == 50)
            {
                heightAnimation.From = 50;
                heightAnimation.To = 200;
            }
            else if (currentHeight == 200)
            {
                heightAnimation.From = 200;
                heightAnimation.To = 50;
            }
            else
            {
                return;
            }

            q1.BeginAnimation(Border.HeightProperty, heightAnimation);
        }
    }
}
