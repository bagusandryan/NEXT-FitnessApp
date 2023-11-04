using Newtonsoft.Json;
using redraven.Helper;
using redraven.Models;

namespace redraven.Services
{
    public class UserService
    {
        User _currentUser;

        string _userJsonFileName = Path.Combine(FileSystem.AppDataDirectory, "user.json");

        public UserService()
        {
            LoadUser();
        }

        public void LoadUser()
        {
            if (!File.Exists(_userJsonFileName))
            {
                User user = new User
                {
                    Name = string.Empty,
                    RegistrationUnixTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds(),
                    IsNewUser = true
                };
                Json.Write(_userJsonFileName, user);
                _currentUser = user;
                return;
            }
            string jsonString = File.ReadAllText((_userJsonFileName));
            _currentUser = JsonConvert.DeserializeObject<User>(jsonString);
        }

        public string GetUserJsonFileName()
        {
            return _userJsonFileName;
        }

        public void SetCurrentUser(User currentUser)
        {
            _currentUser = currentUser;
        }

        public void UpdateUserName(string newUserName)
        {
            _currentUser.Name = newUserName;
            Json.Write(_userJsonFileName, _currentUser);
        }

        public void UpdateProfilePictureMargin(double[] margins)
        {
            _currentUser.ProfilePictureMargin = margins;
            Json.Write(_userJsonFileName, _currentUser);
        }

        public async Task UpdateCurrentUserProfilePicture()
        {
            var images = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Pick a png image of you",
                FileTypes = FilePickerFileType.Png
            });
            if (images == null) return;

            //move this to AppDataDirectory
            using var stream = await images.OpenReadAsync();
            string targetFileName = DateTimeOffset.Now.ToUnixTimeSeconds() + images.FileName;
            string targetFile = Path.Combine(UserDirectory.GetUserProfilePicturesDirectory(), targetFileName);
            // Copy the file to the AppDataDirectory
            using FileStream outputStream = File.Create(targetFile);
            await stream.CopyToAsync(outputStream);
            _currentUser.ProfilePictureFileName = targetFile;
            Json.Write(_userJsonFileName, _currentUser);
        }

        public User GetCurrentUser()
        {
            return _currentUser;
        }
    }


}