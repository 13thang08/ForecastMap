using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Web.Http;
using ForecastMap.DataModels;
using System.Diagnostics;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;

namespace ForecastMap.Logics
{
    class DataLogics
    {
        public static string forecastUrl = "http://www.drk7.jp/weather/xml/";
        public static async Task<bool> updateForecastData(int areaId)
        {
            int prefId = areaId / 100;
            int areaIndex = areaId % 100;
            string URL;
            if (prefId < 10)
            {
                URL = forecastUrl + "0" + prefId + ".xml";
            }
            else
            {
                URL = forecastUrl + prefId + ".xml";
            }
            weatherforecast forecastInfoByPref = await LoadAsync(URL);

            weatherforecastPrefAreaInfo[] areaForecastByDate = forecastInfoByPref.pref.area[areaIndex].info;

            foreach (var item in areaForecastByDate)
            {
                var forecast = new Forecast();
                forecast.AreaId = areaId;
                forecast.DateForecast = DateTime.Parse(item.date);
                forecast.ForecastInfo = item.weather;
                // set image bitmap
                var imageUrl = new Uri(item.img);
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(imageUrl);
                var buffer = await response.Content.ReadAsBufferAsync();
                DataReader dataReader = DataReader.FromBuffer(buffer);
                byte[] bytes = new byte[buffer.Length];
                dataReader.ReadBytes(bytes);
                forecast.ForecastImage = bytes;

                // end set image bitmap
                forecast.MaxTemp = item.temperature.range[0].Value;
                forecast.MinTemp = item.temperature.range[1].Value;
                forecast.ChangeOfRain1 = item.rainfallchance.period[0].Value;
                forecast.ChangeOfRain2 = item.rainfallchance.period[1].Value;
                forecast.ChangeOfRain3 = item.rainfallchance.period[2].Value;
                forecast.ChangeOfRain4 = item.rainfallchance.period[3].Value;

                // update to database
                using (var db = new SQLite.SQLiteConnection(App.DBName))
                {
                    try
                    {
                        var existingRecord = (db.Table<Forecast>().Where(c => (c.AreaId == forecast.AreaId && c.DateForecast == forecast.DateForecast))).SingleOrDefault();

                        if (existingRecord != null)
                        {
                            forecast.RecordId = existingRecord.RecordId;
                            db.Update(forecast);
                        }
                        else
                        {
                            db.Insert(forecast);
                        }

                        
                    }
                    catch
                    {
                        Debug.WriteLine("Can't update data");
                        return false;
                    }
                }
            }

            using (var db = new SQLite.SQLiteConnection(App.DBName))
            {
                try
                {
                    db.Execute("DELETE FROM Forecast WHERE AreaId = ? AND DateForecast < ?", areaId, DateTime.Today);
                }
                catch
                {
                    Debug.WriteLine("Error when try to run query");
                    return false;
                }
            }

            return true;
        }

        public static async Task<bool> addFavorite(int areaId)
        {
            int prefId = areaId / 100;
            int areaIndex = areaId % 100;
            string URL;
            if (prefId < 10)
            {
                URL = forecastUrl + "0" + prefId + ".xml";
            }
            else
            {
                URL = forecastUrl + prefId + ".xml";
            }
            weatherforecast forecastInfoByPref = await LoadAsync(URL);

            weatherforecastPrefAreaInfo[] areaForecastByDate = forecastInfoByPref.pref.area[areaIndex].info;

            FavoritesAreas favoriteArea = new FavoritesAreas();
            favoriteArea.AreaId = areaId;
            favoriteArea.PrefectureName = forecastInfoByPref.pref.id;
            favoriteArea.AreaName = forecastInfoByPref.pref.area[areaIndex].id;
            favoriteArea.Longitude = (float) forecastInfoByPref.pref.area[areaIndex].geo.@long;
            favoriteArea.Latitude = (float) forecastInfoByPref.pref.area[areaIndex].geo.lat;
            favoriteArea.DisplayFlag = false;

            using (var db = new SQLite.SQLiteConnection(App.DBName))
            {
                bool ret = false;
                try
                {
                    db.Insert(favoriteArea);
                    ret = await updateForecastData(areaId);
                }
                catch
                {
                    Debug.WriteLine("Can't add favorite");
                    return false;
                }

                return ret;
            }

        }

        public static FavoritesAreas getFavoriteArea(int areaId)
        {
            using (var db = new SQLite.SQLiteConnection(App.DBName))
            {
                try
                {
                    var record = db.Table<FavoritesAreas>().Where(c => (c.AreaId == areaId)).SingleOrDefault();
                    return record;
                }
                catch
                {
                    Debug.WriteLine("Can't retrieve favorite area");
                    return null;
                }
            }
        }

        public static List<Forecast> getForecastFromDb(int areaId)
        {
            using (var db = new SQLite.SQLiteConnection(App.DBName))
            {
                try
                {
                    var records = db.Table<Forecast>().Where(c => (c.AreaId == areaId)).ToList();
                    return records;
                }
                catch
                {
                    Debug.WriteLine("Can't retrieve data");
                    return null;
                }
            }
        }

        public static List<FavoritesAreas> getFavoriteAreas()
        {
            using (var db = new SQLite.SQLiteConnection(App.DBName))
            {
                try
                {
                    var records = db.Table<FavoritesAreas>().ToList();
                    return records;
                }
                catch
                {
                    Debug.WriteLine("Can't retrieve favorite area");
                    return null;
                }
            }
        }

        public static bool updateFavoriteArea(FavoritesAreas favoriteArea)
        {
            using (var db = new SQLite.SQLiteConnection(App.DBName))
            {
                try
                {
                    db.Update(favoriteArea);
                    return true;
                }
                catch
                {
                    Debug.WriteLine("Can't update favorite area");
                    return false;
                }
            }
        }

        public static bool deleteFavoriteArea(int areaId)
        {
            FavoritesAreas favoriteArea = new FavoritesAreas();
            favoriteArea.AreaId = areaId;

            using (var db = new SQLite.SQLiteConnection(App.DBName))
            {
                try
                {
                    db.Delete(favoriteArea);
                    db.Execute("DELETE FROM Forecast WHERE AreaId = ?", areaId);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        
        /// <summary>
        /// 天気情報データを取得するメソッド
        /// </summary>
        /// <returns>天気情報を持っているオブジェクト</returns>
        public static async Task<DataModels.weatherforecast> LoadAsync(string URL)
        {
            var httpClient = new HttpClient();
            var uri = new Uri(URL);
            try
            {
                // ストリングとして天気情報データを取得する
                var response = await httpClient.GetAsync(uri);
                response.Content.Headers.ContentType.CharSet = "UTF-8";
                var content = await response.Content.ReadAsStringAsync();

                // ByteStreamにデータを変更する
                var buffer = Encoding.UTF8.GetBytes(content);
                var stream = new MemoryStream(buffer);

                // ByteStreamからDeserializeして、天気情報を持っているオブジェクトを取得する
                var serializer = new XmlSerializer(typeof(DataModels.weatherforecast));
                var weatherforcastInfo = (DataModels.weatherforecast)serializer.Deserialize(stream);

                return weatherforcastInfo;
            }
            catch
            {
                return null;
            }
        }
    }
}
