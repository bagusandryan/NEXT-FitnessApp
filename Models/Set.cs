using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace redraven.Models
{

    public partial class Set : ObservableObject
    {
        public Set()
        {
            IsCurrentSet = false;
            IsEditSet = false;
        }

        [JsonProperty("id")]
        [ObservableProperty]
        [property: JsonIgnore]
        private int _id;

        [JsonProperty("weight")]
        [ObservableProperty]
        [property: JsonIgnore]
        private double _weight;

        [JsonProperty("repetition")]
        [ObservableProperty]
        [property: JsonIgnore]
        private int _repetition;

        [JsonIgnore]
        [property: JsonIgnore]
        [ObservableProperty]
        private bool _isCurrentSet;

        [JsonIgnore]
        [ObservableProperty]
        [property: JsonIgnore]
        private bool _isEditSet;

        [JsonIgnore]
        [ObservableProperty]
        [property: JsonIgnore]
        private bool _isSetDone;

    }
}

