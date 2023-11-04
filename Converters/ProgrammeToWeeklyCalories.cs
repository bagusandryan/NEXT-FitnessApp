using redraven.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redraven.Converters
{
    public class ProgrammeToWeeklyCalories : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double totalCaloriesWeekly = 0;
            if (value is Programme programme)
            {
                return CalculateTotalWeeklyCalories(programme);
            }
            return totalCaloriesWeekly + " kcal";
        }

        public static string CalculateTotalWeeklyCalories(Programme programme)
        {
            double totalCaloriesWeekly = 0;

            foreach (var week in programme.TrainingWeeks)
            {
                totalCaloriesWeekly = ObjectToDoubleTotalCalories.CalculateTotalCalories(week);
            }

            totalCaloriesWeekly = totalCaloriesWeekly / programme.TrainingWeeks.Count;
            return totalCaloriesWeekly + " kcal";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}