using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public static class EnergyButtons
    {
        public static List<Punkt> punkts = new List<Punkt>()
        {
            new Punkt("Адреналайн", "pack://application:,,,/img/Adrenalin.png"),
            new Punkt("Burn", "pack://application:,,,/img/Burn.png"),
            new Punkt("drive", "pack://application:,,,/img/Drive.png"),
            new Punkt("monster", "pack://application:,,,/img/Monster.png")
        };
    }
}
