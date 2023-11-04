using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using redraven.Models;

namespace redraven.Helper
{
    public static class UserFile
    {
        public static string UserJsonFileName = Path.Combine(FileSystem.AppDataDirectory, "user.json");


        public static async Task UpdateUserProfilePicture(User user)
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
            user.ProfilePictureFileName = targetFile;
            Json.Write(UserJsonFileName, user);
        }

        public static void UpdateUserName(User user, string newUserName)
        {
            user.Name = newUserName;
            Json.Write(UserJsonFileName, user);
        }
    }
}