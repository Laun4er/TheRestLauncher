using System;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using TheRestLauncher.Settings;

namespace TheRestLauncher.Pages
{
    
    public partial class Settings : Page
    {
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetPhysicallyInstalledSystemMemory(out long TotalMemoryInKilobytes);
        public Settings()
        {
            InitializeComponent();
            
            WinFull.Checked += WinFull_Checked;
            WinFull.Unchecked += WinFull_Unchecked;
            WinHeight.Text = Minecraft.Default.WinHeigh.ToString();
            WinWidth.Text = Minecraft.Default.WinWidth.ToString();

            long memorykb;
            GetPhysicallyInstalledSystemMemory(out memorykb);
            long memoryMB = memorykb / 1024;

            RAMchanged.Maximum = memoryMB;
            RAMchanged.Minimum = 0;
            RAMchanged.TickFrequency = 192;
            RAMchanged.IsSnapToTickEnabled = true;

            RAMchanged.ValueChanged += RAMchanged_ValueChanged;
            TextBoxRam.TextChanged += TextBoxRam_TextChanged;

            if(Minecraft.Default.WinRAM != 0)
            {
                int savedValue = Minecraft.Default.WinRAM;
                RAMchanged.Value = Convert.ToDouble(savedValue);
            }
        }
        #region
        private void WinFull_Checked(object sender, RoutedEventArgs e)
        {
            WinWidth.IsEnabled = false;
            WinHeight.IsEnabled = false;
            Minecraft.Default.WinFull = true;
        }

        private void WinFull_Unchecked(object sender, RoutedEventArgs e)
        {
            WinWidth.IsEnabled = true;
            WinHeight.IsEnabled = true;
            Minecraft.Default.WinFull = false;
        }

        private void WinWidth_LostFocus(object sender, RoutedEventArgs e)
        {
            Minecraft.Default.WinWidth = int.Parse(WinWidth.Text);
            Minecraft.Default.Save();
        }

        private void WinHeight_LostFocus(object sender, RoutedEventArgs e)
        {
            Minecraft.Default.WinHeigh = int.Parse(WinHeight.Text);
            Minecraft.Default.Save();
        }
        #endregion
        private void RAMchanged_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TextBoxRam.Text = Math.Round(RAMchanged.Value).ToString();
            TextBoxRam.Text = RAMchanged.Value.ToString();
        }

        private void TextBoxRam_TextChanged(object sender, TextChangedEventArgs e)
        {
            double value;
            
            if(double.TryParse(TextBoxRam.Text, out value))
            {
                if(value > RAMchanged.Maximum)
                {
                    value = RAMchanged.Maximum;
                    TextBoxRam.Text = value.ToString();
                }
                RAMchanged.Value = value;

                Minecraft.Default.WinRAM = Convert.ToInt32(RAMchanged.Value);
                Minecraft.Default.Save();
            }
        }

        private void RAMchanged_LostFocus(object sender, RoutedEventArgs e)
        {
            Minecraft.Default.WinRAM = Convert.ToInt32(RAMchanged.Value);
            Minecraft.Default.Save();
        }
    }
}
