using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForecastMap.DataModels;
using System.Diagnostics;

namespace ForecastMap.DataModels
{
    class ForecastView
    {
        public int AreaId { get; set; }
        public string Name { get; set; }

        public DateTime DateForecast { get; set; }
        public string ForecastInfo { get; set; }
        public byte[] ForecastImage { get; set; }
        public int MaxTemp { get; set; }
        public int MinTemp { get; set; }
        public int ChangeOfRain { get; set; }

        public static ForecastView getTodayForecastView(int areaId)
        {
            Forecast todayForecast = Logics.DataLogics.getTodayForecast(areaId);
            if (todayForecast != null)
            {
                ForecastView todayForecastView = copyFromForecast(todayForecast);
                return todayForecastView;
            }
            else
            {
                return null;
            }
        }

        public static ForecastView copyFromForecast(Forecast forecast)
        {
            ForecastView forecastView = new ForecastView();
            FavoritesAreas favoriteArea = Logics.DataLogics.getFavoriteArea(forecast.AreaId);

            if (favoriteArea == null)
            {
                return null;
            }

            forecastView.AreaId = forecast.AreaId;
            forecastView.Name = favoriteArea.PrefectureName + "-" + favoriteArea.AreaName;
            forecastView.DateForecast = forecast.DateForecast;
            forecastView.ForecastInfo = forecast.ForecastInfo;
            forecastView.ForecastImage = forecast.ForecastImage;
            forecastView.MaxTemp = forecast.MaxTemp;
            forecastView.MinTemp = forecast.MinTemp;
            if (forecastView.DateForecast.Equals(DateTime.Today))
            {
                int currentTime = DateTime.Now.TimeOfDay.Hours;

                if (0 <= currentTime && currentTime < 6)
                {
                    forecastView.ChangeOfRain = forecast.ChangeOfRain1;
                }
                if (6 <= currentTime && currentTime < 12)
                {
                    forecastView.ChangeOfRain = forecast.ChangeOfRain2;
                }
                if (12 <= currentTime && currentTime < 18)
                {
                    forecastView.ChangeOfRain = forecast.ChangeOfRain3;
                }
                if (18 <= currentTime && currentTime < 24)
                {
                    forecastView.ChangeOfRain = forecast.ChangeOfRain4;
                }
            }

            return forecastView;
        }

        public static List<ForecastView> getForecastViewItems(int areaId)
        {
            List<Forecast> forecastInfos = Logics.DataLogics.getForecastFromDb(areaId);
            List<ForecastView> forecastViewItems = new List<ForecastView>();
            FavoritesAreas favoriteArea = Logics.DataLogics.getFavoriteArea(areaId);

            if (forecastInfos != null)
            {
                foreach (var item in forecastInfos)
                {
                    ForecastView forecastViewItem = new ForecastView();
                    forecastViewItem.AreaId = areaId;
                    forecastViewItem.Name = favoriteArea.PrefectureName + "-" + favoriteArea.AreaName;
                    forecastViewItem.DateForecast = item.DateForecast;
                    forecastViewItem.ForecastInfo = item.ForecastInfo;
                    forecastViewItem.ForecastImage = item.ForecastImage;
                    forecastViewItem.MaxTemp = item.MaxTemp;
                    forecastViewItem.MinTemp = item.MinTemp;

                    if (forecastViewItem.DateForecast.Equals(DateTime.Today))
                    {
                        int currentTime = DateTime.Now.TimeOfDay.Hours;

                        if (0 <= currentTime && currentTime < 6)
                        {
                            forecastViewItem.ChangeOfRain = item.ChangeOfRain1;
                        }
                        if (6 <= currentTime && currentTime < 12)
                        {
                            forecastViewItem.ChangeOfRain = item.ChangeOfRain2;
                        }
                        if (12 <= currentTime && currentTime < 18)
                        {
                            forecastViewItem.ChangeOfRain = item.ChangeOfRain3;
                        }
                        if (18 <= currentTime && currentTime < 24)
                        {
                            forecastViewItem.ChangeOfRain = item.ChangeOfRain4;
                        }
                    }


                    forecastViewItems.Add(forecastViewItem);
                }
            }
            else
            {
                Debug.WriteLine("list is empty!");
            }

            return forecastViewItems;
        }
    }
}
