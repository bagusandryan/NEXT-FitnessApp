using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using redraven.Models;

namespace redraven.Helper
{
    public static class DataTest
    {
        public static void GenerateTrainingDayTestData(DateTimeOffset dateTime)
        {
            TrainingDay trainingDay = new TrainingDay();
            trainingDay.UnixTimestamp = dateTime.ToUnixTimeSeconds();
            trainingDay.Name = "Test data " + trainingDay.UnixTimestamp.ToString().Substring(7, 3);
            trainingDay.ExercisePlans = new ObservableCollection<ExercisePlan>()
            {
                new ExercisePlan()
                {
                    Comment = "Lorem ipsum dolor sitamet",
                    ExerciseId = "Alternate_Hammer_Curl",
                    RestTimer = 90,
                    Sets = new ObservableCollection<Set>()
                    {
                        new()
                        {
                            Id = 1,
                            IsSetDone = true,
                            Repetition = 5,
                            Weight = 80
                        }
                    }
                }
            };

            string targetFile = Path.Combine(UserDirectory.GetTrainingDayHistoryDirectory(CalendarSystem.GetCurrentCalendarWeek()), trainingDay.UnixTimestamp + ".json");
            Json.Write(targetFile, trainingDay);
        }
    }
}