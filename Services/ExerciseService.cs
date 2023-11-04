using Newtonsoft.Json;
using redraven.Models;

namespace redraven.Services
{
    public class ExerciseService
    {
        List<Exercise> exerciseList;
        public ExerciseService()
        {

        }

        public async Task<List<Exercise>> GetExercises()
        {
            if (exerciseList?.Count > 0)
                return exerciseList;

            var stream = await FileSystem.OpenAppPackageFileAsync("yuhonas_github_exercises.json");

            using (StreamReader reader = new StreamReader(stream))
            using (JsonTextReader jsonReader = new JsonTextReader(reader))
            {
                JsonSerializer ser = new JsonSerializer();
                exerciseList = ser.Deserialize<List<Exercise>>(jsonReader);
            }
            return exerciseList;
        }

        public async Task<Exercise> GetExerciseById(string id)
        {
            return await Task.FromResult(GetExercises().Result.FirstOrDefault(item => item.Id == id));
        }

    }
}