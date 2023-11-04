using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace redraven.Models
{
    public partial class TrainingDay : ObservableObject
    {
        public TrainingDay()
        {
            Done = false;
            Today = false;
            IsStarted = false;
            ExercisePlans = new ObservableCollection<ExercisePlan>();
        }

        [JsonProperty("day")]
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(DayOfWeekInt))]
        [property: JsonIgnore]
        private DayOfWeek _dayOfWeek;

        [JsonProperty("today")]
        [ObservableProperty]
        [property: JsonIgnore]
        private bool _today;

        [JsonIgnore]
        public int DayOfWeekInt => (int)_dayOfWeek + 1;

        [JsonProperty("name")]
        [ObservableProperty]
        [property: JsonIgnore]
        string _name;

        [JsonProperty("exercise_plan")]
        [ObservableProperty]
        [property: JsonIgnore]
        ObservableCollection<ExercisePlan> _exercisePlans;

        //UnixTimestamp for History  e.g. 1691271826.JSON
        [JsonProperty("unix_timestamp")]
        [ObservableProperty]
        [property: JsonIgnore]
        long _unixTimestamp;

        [JsonProperty("done")]
        [ObservableProperty]
        [property: JsonIgnore]
        bool _done;

        [JsonIgnore]
        [ObservableProperty]
        [property: JsonIgnore]
        private bool _isStarted;

        [JsonIgnore]
        public static TrainingDay Instance { get; set; }
    }

}

