using redraven.Helper;
using redraven.Models;
using redraven.ViewModels;

namespace redraven.Views;

public partial class ExercisesSelectionPage : ContentPage
{
    private ExercisesSelectionViewModel _viewModel;
    public ExercisesSelectionPage(ExercisesSelectionViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    private async void SelectExerciseButton_OnClicked(object sender, EventArgs e)
    {
        if (SelectExerciseCollectionView.SelectedItems is { Count: > 0 })
        {
            foreach (Exercise item in SelectExerciseCollectionView.SelectedItems)
            {
                ExercisePlan exercisePlan = new ExercisePlan();
                exercisePlan.Exercise = item;
                exercisePlan.ExerciseId = item.Id;
                if (_viewModel.SelectedTrainingDay.ExercisePlans.Count >= 1)
                {
                    exercisePlan.TargetRepetition = _viewModel.SelectedTrainingDay.ExercisePlans.Last().TargetRepetition;
                    exercisePlan.TargetWeight = _viewModel.SelectedTrainingDay.ExercisePlans.Last().TargetWeight;
                    exercisePlan.TargetSet = _viewModel.SelectedTrainingDay.ExercisePlans.Last().TargetSet;
                    exercisePlan.RestTimer = _viewModel.SelectedTrainingDay.ExercisePlans.Last().RestTimer;
                }
                _viewModel.SelectedTrainingDay.ExercisePlans.Add(exercisePlan);
            }
        }
        await Navigation.PopModalAsync();
        SelectExerciseCollectionView.SelectedItems = null;
    }

    Task _typingTask;
    readonly int timeDelay = 1000;

    void SearchExerciseEntry_OnEntryUIOnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is Entry entry)
        {
            if (_typingTask == null || _typingTask.IsCompleted)
            {
                _typingTask = Task.Run(async () =>
                {
                    await Task.Delay(timeDelay);
                    Search.FilterExerciseListUsingEntry(entry, 3, _viewModel.Exercises, SelectExerciseCollectionView);
                });
            }
        }
    }

    private async void IconTextButton_OnButtonOnClicked(object sender, EventArgs e)
    {
        SearchExerciseEntry.HideKeyboard();
        await Navigation.PopModalAsync();
    }
}