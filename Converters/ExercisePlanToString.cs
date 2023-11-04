using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using redraven.Models;

namespace redraven.Converters
{
    public class ExercisePlanToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ExercisePlan { Sets.Count: > 0 } exercisePlan)
            {
                string sets = exercisePlan.Sets.Count() + " sets";
                string targetWeight = exercisePlan.Sets[0].Weight + " kg";
                string targetRep = exercisePlan.Sets[0].Repetition + " reps";

                return sets + MauiProgram.SeparatorText + targetWeight + MauiProgram.SeparatorText + targetRep;
            }
            return "nothing planned yet";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}