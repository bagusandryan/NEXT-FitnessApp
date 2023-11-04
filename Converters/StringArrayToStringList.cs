using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using redraven.Models;

namespace redraven.Converters
{
    public class StringArrayToList : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<string> stringList = new List<string>();
            if (value is string[] stringArray)
            {
                foreach (var text in stringArray)
                {
                    stringList.Add(text);
                }
            }
            return stringList;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}