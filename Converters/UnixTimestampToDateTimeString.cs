using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redraven.Converters
{
    public class UnixTimestampToDateTimeString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return UnixTimestampToDateString.Convert(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public static class UnixTimestampToDateString
    {
        public static string Convert(string unixTimestampString)
        {
            DateTime converteDateTime = UnixTimestampToDateTime.Convert(unixTimestampString);
            if (converteDateTime == DateTime.MinValue) return "Not a valid date";
            return converteDateTime.ToString("dd MMMM");
        }
    }

    public static class UnixTimestampToDateTime
    {
        public static DateTime Convert(string unixTimestampString)
        {
            if (Int32.TryParse(unixTimestampString.ToString(), out int number))
            {
                // Unix timestamp is seconds past epoch
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dateTime = dateTime.AddSeconds(number).ToLocalTime();
                return dateTime;
            }

            return DateTime.MinValue;
        }
    }
}
