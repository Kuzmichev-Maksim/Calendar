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
    /// Логика взаимодействия для day.xaml
    /// </summary>
    public partial class day : UserControl
    {
        public DateTime date;
        private Frame PageFrame;
        private Page1 page1;
        public day(DateTime date, ref Frame PageFrame, Page1 page1)
        {
            this.PageFrame = PageFrame;
            this.page1= page1;
            InitializeComponent();
            this.date = date;
            dayNum.Text= date.Day.ToString();

        }
        private void MouseClicked(object sender, MouseEventArgs e)
        {
            Page2 page2 = new Page2(date, ref PageFrame, page1);
            PageFrame.Content = page2;
        }
    }
}
