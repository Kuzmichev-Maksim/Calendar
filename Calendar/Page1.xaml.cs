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

namespace Calendar
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public static DateTime date;
        private static Frame PageFrame;
        public void UpdateCalendar()
        {
            calendar.Children.Clear();
            for (int i = 1; i <= DateTime.DaysInMonth(date.Year, date.Month); i++)
            {
                DateTime subdate = new DateTime(date.Year, date.Month, i);
                day calendar_day = new day(subdate, ref PageFrame, this);
                foreach (UserSelection userSelection in MyJson.Read<List<UserSelection>>("days.json"))
                {
                    if (userSelection.date == subdate)
                    {
                        try
                        {
                            calendar_day.image.Source = new BitmapImage(new Uri(userSelection.punkts[userSelection.selections[0]].icon));
                        }
                        catch { }
                        break;
                    }
                }
                calendar.Children.Add(calendar_day);
                datePicker.Text = date.ToString("MMMM")+", "+date.Year.ToString();
            }
        }
        public Page1(ref Frame _PageFrame)
        {
            PageFrame = _PageFrame;
            InitializeComponent();
            date = DateTime.Now;
            UpdateCalendar();
        }

        private void prevMonth_Click(object sender, RoutedEventArgs e)
        {
            date = date.AddMonths(-1);
            UpdateCalendar();
        }

        private void nextMonth_Click(object sender, RoutedEventArgs e)
        {
            date = date.AddMonths(1);
            UpdateCalendar();
        }
    }
}
