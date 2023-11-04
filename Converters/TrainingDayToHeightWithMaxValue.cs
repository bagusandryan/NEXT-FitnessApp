using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using redraven.Models;

namespace redraven.Converters
{
    public class TrainingDayToHeightWithMaxValue : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null && values.Length != 2) return 0;

            if (values[0] is TrainingDay trainingDay && values[1] is double decimalParameter)
            {
                double trainingDayMaxWeight = ObjectToDoubleTotalWeight.CalculateTotalVolume(trainingDay);
                if (trainingDayMaxWeight == 0) return trainingDayMaxWeight;
                if (trainingDayMaxWeight == decimalParameter)
                {
                    return 80;
                }
                if (trainingDayMaxWeight < decimalParameter)
                {
                    return trainingDayMaxWeight / decimalParameter * 80;
                }
            }
            return 0;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}