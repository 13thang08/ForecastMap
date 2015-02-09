using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastMap.DataModels
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class weatherforecast
    {

        private object scriptField;

        private string titleField;

        private string linkField;

        private string descriptionField;

        private string pubDateField;

        private string authorField;

        private string managingEditorField;

        private weatherforecastPref prefField;

        /// <remarks/>
        public object script
        {
            get
            {
                return this.scriptField;
            }
            set
            {
                this.scriptField = value;
            }
        }

        /// <remarks/>
        public string title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        public string link
        {
            get
            {
                return this.linkField;
            }
            set
            {
                this.linkField = value;
            }
        }

        /// <remarks/>
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public string pubDate
        {
            get
            {
                return this.pubDateField;
            }
            set
            {
                this.pubDateField = value;
            }
        }

        /// <remarks/>
        public string author
        {
            get
            {
                return this.authorField;
            }
            set
            {
                this.authorField = value;
            }
        }

        /// <remarks/>
        public string managingEditor
        {
            get
            {
                return this.managingEditorField;
            }
            set
            {
                this.managingEditorField = value;
            }
        }

        /// <remarks/>
        public weatherforecastPref pref
        {
            get
            {
                return this.prefField;
            }
            set
            {
                this.prefField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class weatherforecastPref
    {

        private weatherforecastPrefArea[] areaField;

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("area")]
        public weatherforecastPrefArea[] area
        {
            get
            {
                return this.areaField;
            }
            set
            {
                this.areaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class weatherforecastPrefArea
    {

        private weatherforecastPrefAreaGeo geoField;

        private weatherforecastPrefAreaInfo[] infoField;

        private string idField;

        /// <remarks/>
        public weatherforecastPrefAreaGeo geo
        {
            get
            {
                return this.geoField;
            }
            set
            {
                this.geoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("info")]
        public weatherforecastPrefAreaInfo[] info
        {
            get
            {
                return this.infoField;
            }
            set
            {
                this.infoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class weatherforecastPrefAreaGeo
    {

        private decimal longField;

        private decimal latField;

        /// <remarks/>
        public decimal @long
        {
            get
            {
                return this.longField;
            }
            set
            {
                this.longField = value;
            }
        }

        /// <remarks/>
        public decimal lat
        {
            get
            {
                return this.latField;
            }
            set
            {
                this.latField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class weatherforecastPrefAreaInfo
    {

        private string weatherField;

        private string imgField;

        private string weather_detailField;

        private string waveField;

        private weatherforecastPrefAreaInfoTemperature temperatureField;

        private weatherforecastPrefAreaInfoRainfallchance rainfallchanceField;

        private string dateField;

        /// <remarks/>
        public string weather
        {
            get
            {
                return this.weatherField;
            }
            set
            {
                this.weatherField = value;
            }
        }

        /// <remarks/>
        public string img
        {
            get
            {
                return this.imgField;
            }
            set
            {
                this.imgField = value;
            }
        }

        /// <remarks/>
        public string weather_detail
        {
            get
            {
                return this.weather_detailField;
            }
            set
            {
                this.weather_detailField = value;
            }
        }

        /// <remarks/>
        public string wave
        {
            get
            {
                return this.waveField;
            }
            set
            {
                this.waveField = value;
            }
        }

        /// <remarks/>
        public weatherforecastPrefAreaInfoTemperature temperature
        {
            get
            {
                return this.temperatureField;
            }
            set
            {
                this.temperatureField = value;
            }
        }

        /// <remarks/>
        public weatherforecastPrefAreaInfoRainfallchance rainfallchance
        {
            get
            {
                return this.rainfallchanceField;
            }
            set
            {
                this.rainfallchanceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class weatherforecastPrefAreaInfoTemperature
    {

        private weatherforecastPrefAreaInfoTemperatureRange[] rangeField;

        private string unitField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("range")]
        public weatherforecastPrefAreaInfoTemperatureRange[] range
        {
            get
            {
                return this.rangeField;
            }
            set
            {
                this.rangeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string unit
        {
            get
            {
                return this.unitField;
            }
            set
            {
                this.unitField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class weatherforecastPrefAreaInfoTemperatureRange
    {

        private string centigradeField;

        private sbyte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string centigrade
        {
            get
            {
                return this.centigradeField;
            }
            set
            {
                this.centigradeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public sbyte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class weatherforecastPrefAreaInfoRainfallchance
    {

        private weatherforecastPrefAreaInfoRainfallchancePeriod[] periodField;

        private string unitField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("period")]
        public weatherforecastPrefAreaInfoRainfallchancePeriod[] period
        {
            get
            {
                return this.periodField;
            }
            set
            {
                this.periodField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string unit
        {
            get
            {
                return this.unitField;
            }
            set
            {
                this.unitField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class weatherforecastPrefAreaInfoRainfallchancePeriod
    {

        private string hourField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string hour
        {
            get
            {
                return this.hourField;
            }
            set
            {
                this.hourField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public byte Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }


}
