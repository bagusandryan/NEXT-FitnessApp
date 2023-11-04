using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace redraven.Models
{

    public partial class ExercisePlan : ObservableObject
    {
        public ExercisePlan()
        {
            Sets = new ObservableCollection<Set>();
        }

        [JsonProperty("id")]
        [property: JsonIgnore]
        [ObservableProperty]
        string _exerciseId;

        [JsonProperty("resttimer")]
        [property: JsonIgnore]
        [ObservableProperty]
        private int _restTimer;

        [JsonProperty("sets")]
        [ObservableProperty]
        [property: JsonIgnore]
        private ObservableCollection<Set> _sets;

        [JsonProperty("comment")]
        [ObservableProperty]
        [property: JsonIgnore]
        private string _comment;

        [JsonIgnore]
        [property: JsonIgnore]
        [ObservableProperty]
        private int _targetSet;

        [JsonIgnore]
        [property: JsonIgnore]
        [ObservableProperty]
        private double _targetWeight;

        [JsonIgnore]
        [ObservableProperty]
        [property: JsonIgnore]
        private int _targetRepetition;

        [JsonIgnore]
        [property: JsonIgnore]
        [ObservableProperty]
        private int _indexOrder;

        [JsonIgnore]
        [ObservableProperty]
        [property: JsonIgnore]
        private bool _isCurrentExercisePlan;

        [JsonIgnore]
        [property: JsonIgnore]
        [ObservableProperty]
        private bool _isExerciseDone;

        [JsonIgnore]
        [ObservableProperty]
        [property: JsonIgnore]
        Exercise _exercise;
    }


}

