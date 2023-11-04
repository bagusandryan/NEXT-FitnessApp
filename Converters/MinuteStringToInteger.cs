using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redraven.Converters
{
    public class MinuteStringToInteger : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int intValue and > 0)
            {
                TimeSpan ts = TimeSpan.FromSeconds(intValue);
                int minute = ts.Minutes;
                int seconds = ts.Seconds;
                return minute.ToString() + ":" + seconds.ToString();
            }
            return "0:00";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string minuteHour)
            {
                TimeSpan duration = TimeSpan.Zero;
                bool tryParse = TimeSpan.TryParseExact(minuteHour, "m\\:ss", CultureInfo.InvariantCulture, out duration);
                int seconds = (int)duration.TotalSeconds;
                return seconds;
            }
            return 0;
        }
    }
}