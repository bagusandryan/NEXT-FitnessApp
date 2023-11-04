using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace redraven.Models
{
    public partial class TrainingWeek : ObservableObject
    {
        [JsonProperty("id")]
        [ObservableProperty]
        [property: JsonIgnore]
        private int _id;

        [JsonProperty("training_days")]
        [ObservableProperty]
        [property: JsonIgnore]
        private ObservableCollection<TrainingDay> _trainingDays;
    }
}

