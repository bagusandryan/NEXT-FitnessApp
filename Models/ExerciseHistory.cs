using redraven.Converters;
using System.Collections.ObjectModel;

namespace redraven.Models
{
    public class ExerciseHistory : ObservableCollection<Set>
    {
        public ExerciseHistory(string date, ObservableCollection<Set> sets) : base(sets)
        {
            Date = UnixTimestampToDateString.Convert(date);
        }

        public string Date { get; private set; }
    }

}

