using System;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace TheRestLauncher.Pages
{

    public partial class Settings : Page //Необходимо сделать анимацию текста заголовка
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void q1_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            double H = q1.ActualHeight;

            DoubleAnimation heightAnimation = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(1),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };

            if (H == 100)
            {
                heightAnimation.From = 100;
                heightAnimation.To = 200;
            }
            else if (H == 200)
            {
                heightAnimation.From = 200;
                heightAnimation.To = 100;
            }
            else
            {
                return;
            }

            q1.BeginAnimation(Border.HeightProperty, heightAnimation);
        }
    }
}
