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
    /// Логика взаимодействия для energy.xaml
    /// </summary>
    public partial class energy : UserControl
    {
        private bool init = false;
        public int id;
        public List<Punkt> punkts;
        public List<int> selections = new List<int>();
        public energy(Punkt punkt, int id, ref List<Punkt> punkts, ref List<int> selections)
        {
            InitializeComponent();
            this.id = id;
            this.punkts = punkts;
            this.selections = selections;
            punktLogo.Source = new BitmapImage(new Uri(punkt.icon));
            selectedBox.Content = punkt.name;
            if (punkt.selected)
            {
                selectedBox.IsChecked = true;
            }
            init = true;
        }
        private void selectedBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!init) { return; }
            punkts[id].selected = false;
            selections.Remove(id);
        }
        private void selectedBox_Checked(object sender, RoutedEventArgs e)
        {
            if (!init) { return; }
            punkts[id].selected = true;
            selections.Add(id);
        }
    }
}
