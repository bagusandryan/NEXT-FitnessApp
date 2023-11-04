using Newtonsoft.Json;
using CommunityToolkit.Mvvm.ComponentModel;

namespace redraven.Models
{
    public partial class Exercise : ObservableObject
    {
        //public MuscleGroup MuscleGroup { get; set; }
        [JsonProperty("id")]
        [property: JsonIgnore]
        [ObservableProperty]
        string _id;

        [JsonProperty("name")]
        [property: JsonIgnore]
        [ObservableProperty]
        string _name;

        [JsonProperty("instructions")]
        [property: JsonIgnore]
        [ObservableProperty]
        string[] _instructions;

        [JsonProperty("youtube_id")]
        [property: JsonIgnore]
        [NotifyPropertyChangedFor(nameof(YouTubeUrl))]
        [ObservableProperty]
        string _youTubeId;

        [JsonProperty("alternativeName")]
        [ObservableProperty]
        [property: JsonIgnore]
        string[] _alternativeName;

        public string YouTubeUrl => "https://www.youtube.com/embed/" + YouTubeId;
    }

}

