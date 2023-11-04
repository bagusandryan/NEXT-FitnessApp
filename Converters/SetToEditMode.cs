using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using redraven.Models;

namespace redraven.Converters
{
    public class SetToEditMode : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null) return false;

            var sets = values.OfType<Set>().ToList();
            if (sets.Count == 2 && sets[0] == sets[1])
            {
                return (bool)values[2];
            }
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}