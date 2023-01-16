using mapos.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace mapos.Converter
{
    class BusTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (BusType)value;
            switch (type)
            {
                case BusType.CREAlIS:
                    return "CREALIS.jpg";
                case BusType.URBANWAY:
                    return "URBANWAY.jpg";
                default:
                    return "CREALIS.jpg";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
