using redraven.Models;

namespace redraven.Services
{
    public class TrainingDayService
    {
        private TrainingDay _currentTrainingDay;

        public void SetCurrentTrainingDay(TrainingDay trainingDay)
        {
            _currentTrainingDay = trainingDay;

            if (_currentTrainingDay.ExercisePlans == null) return;

            int index = 1;
            foreach (var item in _currentTrainingDay.ExercisePlans)
            {
                item.IndexOrder = index;
                index++;
            }
        }

        public TrainingDay GetCurrentTrainingDay()
        {
            return _currentTrainingDay;
        }
    }
}