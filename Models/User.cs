using CommunityToolkit.Mvvm.ComponentModel;

namespace redraven.Models
{
    public partial class User : ObservableObject
    {
        public User()
        {
            IsNewUser = true;
            RegistrationUnixTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
            ProfilePictureFileName = "placeholder_user.png";
            ProfilePictureMargin = new[] { -68.0, 0.0, 0.0, 0.0 };
        }

        [ObservableProperty]
        double[] _profilePictureMargin;

        [ObservableProperty]
        string _name;

        [ObservableProperty]
        long _registrationUnixTimestamp;

        [ObservableProperty]
        bool _isNewUser;

        [ObservableProperty]
        string _profilePictureFileName;
    }
}

