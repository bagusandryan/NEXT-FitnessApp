using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using redraven.Models;

namespace redraven.Converters
{
    public class TrainingDayToTotalWorkoutTime : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TrainingDay { ExercisePlans.Count: > 0 } trainingDay)
            {
                var time = TimeSpan.FromMinutes(ObjectToTotalWorkoutTimeDouble.CalculateTotalTime(trainingDay));
                if (time.Hours == 0) return string.Format("{0}m {1}s", time.Minutes, time.Seconds);
                if (time.Hours > 0) return string.Format("{0}h {1}m", time.Hours, time.Minutes);
            }
            return "0h 00m";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public static class ObjectToTotalWorkoutTimeDouble
    {
        public static double CalculateTotalTime(TrainingWeek trainingWeek)
        {
            double totalTime = 0;

            foreach (var day in trainingWeek.TrainingDays)
            {
                totalTime = totalTime + CalculateTotalTime(day);
            }

            return totalTime;
        }

        public static double CalculateTotalTime(TrainingDay trainingDay)
        {
            if (trainingDay.ExercisePlans.Count > 0)
            {
                double totalReps = 0;
                double totalRestSeconds = 0;

                foreach (var exercisePlan in trainingDay.ExercisePlans)
                {
                    foreach (var set in exercisePlan.Sets)
                        totalReps = totalReps + set.Repetition;

                    totalRestSeconds = totalRestSeconds + (exercisePlan.Sets.Count * exercisePlan.RestTimer);
                }

                //We assume every rep takes approx 5 seconds
                double totalRepsMinutes = totalReps * 0.08;
                double totalRestMinutes = totalRestSeconds / 60;
                double totalRestRepsMinutes = totalRepsMinutes + totalRestMinutes;

                return totalRestRepsMinutes;
            }

            return 0;
        }
    }
}