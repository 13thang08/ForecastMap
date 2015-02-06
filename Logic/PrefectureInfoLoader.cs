using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ForecastMap.Logic
{
    class PrefectureInfoLoader
    {
        public static async Task<pref_info> getPrefInfo()
        {
            
            var storageFile = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync("Data\\prefecture.xml");
            string text = await Windows.Storage.FileIO.ReadTextAsync(storageFile);
            var buffer = Encoding.UTF8.GetBytes(text);
            var stream = new MemoryStream(buffer);

            var serializer = new XmlSerializer(typeof(pref_info));
            var prefInfo = (pref_info)serializer.Deserialize(stream);
            return prefInfo;
        }
    }
}
