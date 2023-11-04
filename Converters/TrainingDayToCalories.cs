using redraven.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redraven.Converters
{
    public class TrainingDayToCalories : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TrainingDay { ExercisePlans.Count: > 0 } trainingDay)
            {
                //source https://www.strengthlog.com/calories-burned-lifting-weights/
                return ObjectToDoubleTotalCalories.CalculateTotalCalories(trainingDay) + " kcal";
            }
            return "0 kcal";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public static class ObjectToDoubleTotalCalories
    {
        public static double CalculateTotalCalories(TrainingWeek trainingWeek)
        {
            double totalCalories = 0;

            foreach (var day in trainingWeek.TrainingDays)
            {
                totalCalories = totalCalories + CalculateTotalCalories(day);
            }

            return totalCalories;
        }


        public static double CalculateTotalCalories(TrainingDay trainingDay)
        {
            double totalCalories = ((int)(ObjectToTotalWorkoutTimeDouble.CalculateTotalTime(trainingDay) * 40 * 0.0675));

            return totalCalories;
        }
    }
}