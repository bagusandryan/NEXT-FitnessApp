using redraven.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redraven.Converters
{
    internal class TrainingDayToTotalSets : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TrainingDay { ExercisePlans.Count: > 0 } trainingDay)
            {
                double totalSets = 0;
                foreach (var exercisePlan in trainingDay.ExercisePlans)
                {
                    totalSets = totalSets + exercisePlan.Sets.Count;
                }
                return totalSets + " sets";
            }
            else if (value is ExercisePlan exercisePlan)
            {
                double totalSets = 0;
                totalSets = totalSets + exercisePlan.Sets.Count;
                return totalSets + " sets";
            }
            return "0 set";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}