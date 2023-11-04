using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using redraven.Models;

namespace redraven.Converters
{
    public class ProgrammeToWeeklyLift : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double totalWeightAllWeek = 0;
            if (value is Programme programme) return CalculateWeeklyTotalWeight(programme);

            return totalWeightAllWeek + " kg";
        }

        public static string CalculateWeeklyTotalWeight(Programme programme)
        {
            double totalWeightAllWeek = 0;

            foreach (var week in programme.TrainingWeeks)
            {
                totalWeightAllWeek = ObjectToDoubleTotalWeight.CalculateTotalWeight(week);
            }

            totalWeightAllWeek = totalWeightAllWeek / programme.TrainingWeeks.Count;

            return totalWeightAllWeek + " kg";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}