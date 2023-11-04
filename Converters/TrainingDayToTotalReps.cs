using redraven.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redraven.Converters
{
    internal class TrainingDayToTotalReps : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TrainingDay { ExercisePlans.Count: > 0 } trainingDay)
            {
                double totalReps = 0;
                foreach (var exercisePlan in trainingDay.ExercisePlans)
                {
                    foreach (var set in exercisePlan.Sets)
                        totalReps = totalReps + set.Repetition;
                }
                return totalReps + " X";
            }
            else if (value is ExercisePlan exercisePlan)
            {
                double totalReps = 0;
                foreach (var set in exercisePlan.Sets)
                    totalReps = totalReps + set.Repetition;
                return totalReps + " X";
            }
            return "0 X";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public static class ObjectToTotalRepsInt
    {
        public static int CalculateTotalReps(TrainingDay trainingDay)
        {
            if (trainingDay.ExercisePlans.Count > 0)
            {
                int totalReps = 0;

                foreach (var exercisePlan in trainingDay.ExercisePlans)
                {
                    foreach (var set in exercisePlan.Sets)
                        totalReps = totalReps + set.Repetition;
                }

                return totalReps;
            }

            return 0;
        }
    }

}