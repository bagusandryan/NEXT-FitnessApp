using Newtonsoft.Json;
using redraven.Models;

namespace redraven.Services
{
    public class ProgrammeService
    {
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
            if (File.Exists(MauiProgram.UserSelectedProgramme) && _selectedProgramme == null)
            {
                _selectedProgramme =
                    JsonConvert.DeserializeObject<Programme>(
                        await File.ReadAllTextAsync(MauiProgram.UserSelectedProgramme));
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
    }
}