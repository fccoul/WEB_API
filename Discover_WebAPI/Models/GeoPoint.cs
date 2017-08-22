using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discover_WebAPI.Models
{
    public class GeoPoint
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    [TypeConverter(typeof(GeoPointConverter))]
    public class GPConverter
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public static bool TryParse(string s, out GPConverter result)
        {
            result = null;
            var parts = s.Split(',');
            if (parts.Length != 2)
                return false;

            double latitude, longitude;
            if (double.TryParse(parts[0], out latitude) && double.TryParse(parts[1],out longitude))
            {
                result = new GPConverter() { Longitude = longitude, Latitude = latitude };
                return true;
            }
            return false;
        }
    }

    class GeoPointConverter:TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                GPConverter point;
                if (GPConverter.TryParse((string)value, out point))
                {
                    return point;
                }
            }

                return base.ConvertFrom(context,culture,value);
        }
    }
}
