using redraven.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redraven.Converters
{
    public class TrainingDayToSummaryString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TrainingDay { ExercisePlans.Count: > 0 } trainingDay)
            {
                return Summary(trainingDay);
            }
            return "Tap here to add exercises to your rest day";
        }

        public static string Summary(TrainingDay trainingDay)
        {
            //total weight
            string totalWeight = ObjectToDoubleTotalWeight.CalculateTotalWeight(trainingDay) + " kg";
            //total calories
            string totalCal = ObjectToDoubleTotalCalories.CalculateTotalCalories(trainingDay) + " kcal";
            //total time
            string totalTime = string.Empty;
            var time = TimeSpan.FromMinutes(ObjectToTotalWorkoutTimeDouble.CalculateTotalTime(trainingDay));
            if (time.Hours == 0) totalTime = string.Format("{0}m {1}s", time.Minutes, time.Seconds);
            if (time.Hours > 0) totalTime = string.Format("{0}h {1}m", time.Hours, time.Minutes);

            return totalWeight + MauiProgram.SeparatorText + totalCal + MauiProgram.SeparatorText + totalTime;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
