using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForecastMap.DataModels;
using System.Xml.Serialization;
using System.IO;

namespace ForecastMap.Logics
{
    class PrefsInfoLoader
    {
        public static async Task<PrefsInfo> getPrefsInfo()
        {
            PrefsInfo prefsInfo = new PrefsInfo();
            var storageFile = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync("Data\\prefecture.xml");
            string text = await Windows.Storage.FileIO.ReadTextAsync(storageFile);
            prefsInfo = (PrefsInfo)ConvertXmlStringtoObject<PrefsInfo>(text);
            return prefsInfo;
        }

        static T ConvertXmlStringtoObject<T>(string xmlString)
        {
            T classObject;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringReader stringReader = new StringReader(xmlString))
            {
                classObject = (T)xmlSerializer.Deserialize(stringReader);
            }
            return classObject;
        }
    }
}
