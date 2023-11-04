using redraven.Services;
using redraven.ViewModels;

namespace redraven.Views;

public partial class TrainingDayEditorPage : ContentPage
{
    readonly TrainingDayEditorViewModel _viewModel;

    public TrainingDayEditorPage(TrainingDayEditorViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    private async void IconTextButton_OnButtonOnClicked(object sender, EventArgs e)
    {
        await _viewModel.GoBack();
    }

    private async void AddExerciseToPlanButton_OnClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ExercisesSelectionPage(new ExercisesSelectionViewModel(Application.Current.Handler.MauiContext.Services.GetService<ExerciseService>(), _viewModel.GetSelectedTrainingDay())));
    }
}