using redraven.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redraven.Converters
{
    public class TrainingDayToTotalWeight : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string unit = " kg";
            if (parameter is string and "omit") unit = String.Empty;

            if (value is TrainingDay { ExercisePlans.Count: > 0 } trainingDay)
            {
                return ObjectToDoubleTotalWeight.CalculateTotalWeight(trainingDay) + unit;
            }
            if (value is ExercisePlan exercisePlan)
            {
                return ObjectToDoubleTotalWeight.CalculateTotalWeight(exercisePlan) + unit;
            }
            return "0" + unit;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class TrainingDayToTotalVolume : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string unit = " kg";
            if (parameter is string and "omit") unit = String.Empty;

            if (value is TrainingDay { ExercisePlans.Count: > 0 } trainingDay)
            {
                return ObjectToDoubleTotalWeight.CalculateTotalVolume(trainingDay) + unit;
            }
            //if (value is ExercisePlan exercisePlan)
            //{
            //    return ObjectToDoubleTotalWeight.CalculateTotalVolume(exercisePlan) + unit;
            //}
            return "0" + unit;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public static class ObjectToDoubleTotalWeight
    {
        public static double CalculateTotalWeight(TrainingWeek trainingWeek)
        {
            double totalWeight = 0;

            foreach (var day in trainingWeek.TrainingDays)
            {
                foreach (var exercisePlan in day.ExercisePlans)
                {
                    totalWeight = totalWeight + CalculateTotalWeight(exercisePlan);
                }
            }

            return totalWeight;
        }

        public static double CalculateTotalWeight(TrainingDay trainingDay)
        {
            double totalWeight = 0;
            foreach (var exercisePlan in trainingDay.ExercisePlans)
            {
                foreach (var set in exercisePlan.Sets)
                    totalWeight = totalWeight + set.Weight;
            }

            return totalWeight;
        }

        public static double CalculateTotalVolume(TrainingDay trainingDay)
        {
            double totalWeight = 0;
            foreach (var exercisePlan in trainingDay.ExercisePlans)
            {
                foreach (var set in exercisePlan.Sets)
                    totalWeight = totalWeight + set.Weight * set.Repetition;
            }

            return totalWeight;
        }

        public static double CalculateTotalWeight(ExercisePlan exercisePlan)
        {
            double totalWeight = 0;
            foreach (var set in exercisePlan.Sets)
                totalWeight = totalWeight + set.Weight;

            return totalWeight;
        }
    }
}