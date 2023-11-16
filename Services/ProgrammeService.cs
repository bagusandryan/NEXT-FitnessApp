using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using redraven.Models;

namespace redraven.Services
{
    public class ProgrammeService
    {
        string _userSelectedProgrammeFileName = Path.Combine(FileSystem.AppDataDirectory, "user_programme.json");

        private Programme _selectedProgramme;
        private ExerciseService _exerciseService;

        public ProgrammeService(ExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
            _ = LoadCurrentProgramme();
        }

        public async Task SetCurrentProgramme(Programme programme)
        {
            _selectedProgramme = programme;
            await LoadExercisesInCurrentProgramme();
        }

        public async Task LoadCurrentProgramme()
        {
            if (File.Exists(_userSelectedProgrammeFileName) && _selectedProgramme == null)
            {
                string jsonString = await File.ReadAllTextAsync(_userSelectedProgrammeFileName);
                JObject elements = JObject.Parse(jsonString);
                if(elements.ContainsKey("Result"))
                {
                    //iOS somehow wraps the JSON with Task properties result 
                    _selectedProgramme = JsonConvert.DeserializeObject<Programme>(elements["Result"].ToString());
                }
                else
                {
                    _selectedProgramme = JsonConvert.DeserializeObject<Programme>(jsonString);
                }

                await LoadExercisesInCurrentProgramme();
            }
        }

        public async Task LoadExercisesInCurrentProgramme()
        {
            List<Exercise> exercises = await _exerciseService.GetExercises();
            foreach (var week in _selectedProgramme.TrainingWeeks)
            {
                foreach (var day in week.TrainingDays)
                {
                    foreach (var exercise in day.ExercisePlans)
                    {
                        exercise.Exercise = exercises.FirstOrDefault(item => item.Id == exercise.ExerciseId) ?? new Exercise();
                    }
                }
            }
        }

        public async Task<Programme> GetCurrentProgramme()
        {
            if (_selectedProgramme == null)
            {
                await LoadCurrentProgramme();
            }
            return _selectedProgramme;
        }

        public string GetUserSelectedProgrammeFileName()
        {
            return _userSelectedProgrammeFileName;
        }
    }
}