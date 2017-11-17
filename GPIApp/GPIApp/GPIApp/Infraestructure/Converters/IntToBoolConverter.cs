using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GPIApp.Infraestructure.Converters
{
    class IntToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = false;

            if (value is int)
            {
                if ((int)value == 1)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int result = 0;
            if (value is bool)
            {
                if ((bool)value == true)
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }
            return result;
        }
    }
}
