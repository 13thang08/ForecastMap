using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastMap.DataModels
{
    class FavoritesAreas
    {
        [PrimaryKey]
        public int AreaId { get; set; }
        public string AreaName { get; set; }

        public int PrefectureId { get; set; }
        public int PrefectureName { get; set; }

        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public bool DisplayFlag { get; set; }

    }
}
