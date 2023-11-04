using redraven.Models;
using redraven.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redraven.Converters
{
    public class ExercisePlanToExerciseNOfNString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ExercisePlan { Sets.Count: > 0 } exercisePlan && Application.Current.Handler.MauiContext.Services.GetService<TrainingDayService>().GetCurrentTrainingDay() != null)
            {
                int index = Application.Current.Handler.MauiContext.Services.GetService<TrainingDayService>().GetCurrentTrainingDay().ExercisePlans.IndexOf(exercisePlan) + 1;
                return "Exercise " + index.ToString() + " of " +
                       Application.Current.Handler.MauiContext.Services.GetService<TrainingDayService>().GetCurrentTrainingDay().ExercisePlans.Count;
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}