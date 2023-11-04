using Newtonsoft.Json;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace redraven.Models
{
    public partial class Programme : ObservableObject
    {
        [JsonProperty("id")]
        [ObservableProperty]
        [property: JsonIgnore]
        int _id;

        [JsonProperty("name")]
        [ObservableProperty]
        [property: JsonIgnore]
        string _name;

        [ObservableProperty]
        private string _description;

        [JsonProperty("training_weeks")]
        [ObservableProperty]
        [property: JsonIgnore]
        public ObservableCollection<TrainingWeek> _trainingWeeks;
    }
}