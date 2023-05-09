using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class Punkt
    {
        public string name;
        public string icon;
        public bool selected = false;
        public Punkt(string name, string icon)
        {
            this.name = name;
            this.icon = icon;
        }
    }

    public class UserSelection
    {
        public DateTime date;
        public List<Punkt> punkts;
        public List<int> selections;
        public UserSelection(DateTime date, List<Punkt> punkts, List<int> selections)
        {
            this.date = date;
            this.punkts = punkts;
            this.selections = selections;
        }
    }
}
