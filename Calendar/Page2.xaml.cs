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
    public partial class Page2 : Page
    {
        public DateTime date;
        private List<Punkt> nrg = EnergyButtons.punkts;
        private List<int> selections = new List<int>();
        private Frame PageFrame;
        private Page1 page1;
        public Page2(DateTime date, ref Frame PageFrame, Page1 page1)
        {
            InitializeComponent();
            this.date = date;
            this.PageFrame= PageFrame;
            this.page1 = page1;
            dateBlock.Text = $"{date.Day} {date.ToString("MMMM")}";
            List<UserSelection> sels = MyJson.Read<List<UserSelection>>("days.json");
            foreach (var i in sels)
            {
                if (date == i.date)
                {
                    nrg = i.punkts;
                    selections = i.selections;
                }
            }
            int gg = 0;
            foreach (Punkt punkt in nrg)
            {
                checkBoxes.Children.Add(new energy(punkt, gg, ref nrg, ref selections));
                gg++;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<UserSelection> sels = MyJson.Read<List<UserSelection>>("days.json");
            for (int i = 0; i < sels.Count; i++)
            {
                if (date == sels[i].date)
                {
                    sels.RemoveAt(i);
                    break;
                }
            }

            UserSelection userSelection = new UserSelection(date, nrg, selections);
            sels.Add(userSelection);

            MyJson.Write("days.json", sels);
            page1.UpdateCalendar();
            PageFrame.Content = page1;
        }
    }
}
