using System;
using System.Windows.Controls;

namespace TheRestLauncher.Classes
{
    public class BirthdayGreeting
    {
        private TextBlock SeaSon;

        public BirthdayGreeting(TextBlock seaSon)
        {
            SeaSon = seaSon;
        }

        public void HappyBird()
        {
            if (DateTime.Now.Date == new DateTime(DateTime.Now.Year, 11, 5))
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
                SeaSon.Text = "С днём рождения, izumrudik01🎂";
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
        }
    }
}
