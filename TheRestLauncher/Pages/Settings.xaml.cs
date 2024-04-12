using System;
using System.Windows;
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
                heightAnimation.To = 130;
            }
            else if (H == 130)
            {
                heightAnimation.From = 130;
                heightAnimation.To = 100;
            }
            else
            {
                return;
            }
            q1.BeginAnimation(Border.HeightProperty, heightAnimation);
        }

        private void q2_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            double H = q2.ActualHeight;

            DoubleAnimation heightAnimation = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(1),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };

            if (H == 100)
            {
                heightAnimation.From = 100;
                heightAnimation.To = 140;
            }
            else if (H == 140)
            {
                heightAnimation.From = 140;
                heightAnimation.To = 100;
            }
            else
            {
                return;
            }
            q2.BeginAnimation(Border.HeightProperty, heightAnimation);
        }

        private void q3_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            double H = q3.ActualHeight;

            DoubleAnimation heightAnimation = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(1),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };

            if (H == 100)
            {
                heightAnimation.From = 100;
                heightAnimation.To = 140;
            }
            else if (H == 140)
            {
                heightAnimation.From = 140;
                heightAnimation.To = 100;
            }
            else
            {
                return;
            }
            q3.BeginAnimation(Border.HeightProperty, heightAnimation);
        }

        private void q4_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            double H = q4.ActualHeight;

            DoubleAnimation heightAnimation = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(1),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };

            if (H == 100)
            {
                heightAnimation.From = 100;
                heightAnimation.To = 140;
            }
            else if (H == 140)
            {
                heightAnimation.From = 140;
                heightAnimation.To = 100;
            }
            else
            {
                return;
            }
            q4.BeginAnimation(Border.HeightProperty, heightAnimation);
        }

        private void q5_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            double H = q5.ActualHeight;

            DoubleAnimation heightAnimation = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(1),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };

            if (H == 100)
            {
                heightAnimation.From = 100;
                heightAnimation.To = 140;
            }
            else if (H == 140)
            {
                heightAnimation.From = 140;
                heightAnimation.To = 100;
            }
            else
            {
                return;
            }
            q5.BeginAnimation(Border.HeightProperty, heightAnimation);
        }

        private void q6_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            double H = q6.ActualHeight;

            DoubleAnimation heightAnimation = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(1),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };

            if (H == 100)
            {
                heightAnimation.From = 100;
                heightAnimation.To = 140;
            }
            else if (H == 140)
            {
                heightAnimation.From = 140;
                heightAnimation.To = 100;
            }
            else
            {
                return;
            }
            q6.BeginAnimation(Border.HeightProperty, heightAnimation);
        }

        private void q7_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            double H = q7.ActualHeight;

            DoubleAnimation heightAnimation = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(1),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };

            if (H == 100)
            {
                heightAnimation.From = 100;
                heightAnimation.To = 140;
            }
            else if (H == 140)
            {
                heightAnimation.From = 140;
                heightAnimation.To = 100;
            }
            else
            {
                return;
            }
            q7.BeginAnimation(Border.HeightProperty, heightAnimation);
        }

        private void q8_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            double H = q8.ActualHeight;

            DoubleAnimation heightAnimation = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(1),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };

            if (H == 100)
            {
                heightAnimation.From = 100;
                heightAnimation.To = 140;
            }
            else if (H == 140)
            {
                heightAnimation.From = 140;
                heightAnimation.To = 100;
            }
            else
            {
                return;
            }
            q8.BeginAnimation(Border.HeightProperty, heightAnimation);
        }

        private void q9_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            double H = q9.ActualHeight;

            DoubleAnimation heightAnimation = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(1),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };

            if (H == 100)
            {
                heightAnimation.From = 100;
                heightAnimation.To = 140;
            }
            else if (H == 140)
            {
                heightAnimation.From = 140;
                heightAnimation.To = 100;
            }
            else
            {
                return;
            }
            q9.BeginAnimation(Border.HeightProperty, heightAnimation);
        }

        private void q10_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            double H = q10.ActualHeight;

            DoubleAnimation heightAnimation = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(1),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };

            if (H == 100)
            {
                heightAnimation.From = 100;
                heightAnimation.To = 140;
            }
            else if (H == 140)
            {
                heightAnimation.From = 140;
                heightAnimation.To = 100;
            }
            else
            {
                return;
            }
            q10.BeginAnimation(Border.HeightProperty, heightAnimation);
        }

        private void q11_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            double H = q11.ActualHeight;

            DoubleAnimation heightAnimation = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(1),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };

            if (H == 100)
            {
                heightAnimation.From = 100;
                heightAnimation.To = 140;
            }
            else if (H == 140)
            {
                heightAnimation.From = 140;
                heightAnimation.To = 100;
            }
            else
            {
                return;
            }
            q11.BeginAnimation(Border.HeightProperty, heightAnimation);
        }

        private void Offer_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show("Тест", "Предложка");
        }

        private void Complaint_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show("Тест", "Жалоба");
        }

        private void Support_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show("Тест", "Поддержка");
        }
    }
}
