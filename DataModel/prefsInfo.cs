using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastMap.DataModel
{
    public class PrefsInfo
    {
        public Pref[] Prefs { get; set; }
    }

    public class Pref
    {
        public int PrefId { get; set; }
        public string PrefName { get; set; }
        public Area[] Areas { get; set; }
    }

    public class Area
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
    }
}
