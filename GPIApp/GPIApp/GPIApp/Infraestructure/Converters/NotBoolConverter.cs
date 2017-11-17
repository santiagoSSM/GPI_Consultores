using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GPIApp.Infraestructure.Converters
{
    class NotBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                return InvertValue((bool)value);
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                return InvertValue((bool)value);
            }
            return false;
        }

        private bool InvertValue(bool value)
        {
            return !value;
        }
    }
}
