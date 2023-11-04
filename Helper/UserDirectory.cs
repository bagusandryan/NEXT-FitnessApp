using redraven.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redraven.Helper
{
    public static class UserDirectory
    {
        public static string GetCustomExerciseDirectory()
        {
            string dir = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "CustomExercise");
            if (!Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }
            return dir;
        }

        public static string GetCustomProgrammesDirectory()
        {
            string dir = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "CustomProgrammes");
            if (!Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }
            return dir;
        }

        public static string GetTrainingDayHistoryDirectory(int calendarWeek, int calendarYear = 0)
        {
            string year = string.Empty;
            if (calendarYear == 0)
            {
                year = DateTime.Now.Year.ToString();
            }
            else
            {
                year = calendarYear.ToString();
            }

            string dir = Path.Combine(FileSystem.AppDataDirectory, "TrainingDayHistory", year, calendarWeek.ToString());
            if (!Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }
            return dir;
        }

        public static string GetUserProfilePicturesDirectory()
        {
            string dir = Path.Combine(FileSystem.AppDataDirectory, "UserProfilePictures");
            if (!Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }
            return dir;
        }
    }
}