using redraven.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redraven.Converters
{
    public class ProgrammeToWeeklyTime : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double totalTimeAllWeek = 0;
            if (value is Programme programme)
            {
                CalculateWeeklyTime(programme);
            }

            return "0h 00m";
        }

        public static string CalculateWeeklyTime(Programme programme)
        {
            double totalTimeAllWeek = 0;
            foreach (var week in programme.TrainingWeeks)
            {
                totalTimeAllWeek = ObjectToTotalWorkoutTimeDouble.CalculateTotalTime(week);
            }

            totalTimeAllWeek = totalTimeAllWeek / programme.TrainingWeeks.Count;

            var time = TimeSpan.FromMinutes(totalTimeAllWeek);

            if (time.Hours == 0) return string.Format("{0}m {1}s", time.Minutes, time.Seconds);
            if (time.Hours > 0) return string.Format("{0}h {1}m", time.Hours, time.Minutes);

            return "0h 00m";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}