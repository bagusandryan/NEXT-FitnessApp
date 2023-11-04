using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using redraven.Models;

namespace redraven.Converters
{
    public class ProgrammeToTodayExercisePlan : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Programme programme)
            {
                GetTodayTrainingDay(programme);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public static TrainingDay GetTodayTrainingDay(Programme programme)
        {
            if (programme == null) return null;

            foreach (var week in programme.TrainingWeeks)
            {
                foreach (var day in week.TrainingDays)
                    if (day.Today)
                        return day;
            }

            if (programme.TrainingWeeks.Count > 0 && programme.TrainingWeeks[0].TrainingDays.Count > 0)
            {
                return programme.TrainingWeeks[0].TrainingDays[0];
            }

            return null;
        }
    }
}