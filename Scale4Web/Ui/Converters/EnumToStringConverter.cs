using Scale4Web.i18n;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Scale4Web.Ui.Converters
{
    public sealed class EnumToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            { return null; }

            return Strings.ResourceManager.GetString(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string str = (string)value;

            foreach (object enumValue in Enum.GetValues(targetType))
            {
                if (str == Strings.ResourceManager.GetString(enumValue.ToString()))
                { return enumValue; }
            }

            throw new ArgumentException(null, "value");
        }
    }
}
