using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastMap.DataModels
{
    class Forecast
    {
        [PrimaryKey, AutoIncrement]
        public int RecordId { get; set; }

        public int AreaId { get; set; }
        public DateTime DateForecast { get; set; }
        public string ForecastInfo { get; set; }
        public byte[] ForecastImage { get; set; }
        public int MaxTemp { get; set; }
        public int MinTemp { get; set; }
        public int ChangeOfRain1 { get; set; }
        public int ChangeOfRain2 { get; set; }
        public int ChangeOfRain3 { get; set; }
        public int ChangeOfRain4 { get; set; }
    }
}
