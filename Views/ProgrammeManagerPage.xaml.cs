using redraven.Converters;
using redraven.Services;
using redraven.ViewModels;

namespace redraven.Views;

public partial class ProgrammeManagerPage : ContentPage
{

    ProgrammeManagerViewModel _viewModel;

    public ProgrammeManagerPage(ProgrammeManagerViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        //Dirty workaround for binding that is not updated..... :( 
        BindingContext = null;
        _viewModel = new ProgrammeManagerViewModel(Application.Current.Handler.MauiContext.Services.GetService<ProgrammeService>());
        BindingContext = _viewModel;
        WeeklyWeightIconText.TitleText = ProgrammeToWeeklyLift.CalculateWeeklyTotalWeight(_viewModel.SelectedProgramme);
        WeeklyTimeIconText.TitleText = ProgrammeToWeeklyTime.CalculateWeeklyTime(_viewModel.SelectedProgramme);
        WeeklyCaloriesIconText.TitleText = ProgrammeToWeeklyCalories.CalculateTotalWeeklyCalories(_viewModel.SelectedProgramme);
    }

    //Can't get this to work using EventToCommand
    private async void TrainingDayCollectionView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        await _viewModel.TrainingDaySelectionChanged(TrainingDayCollectionView);
    }

    private void SaveProgrammeButton_OnButtonOnClicked(object sender, EventArgs e)
    {
        _viewModel.WriteSelectedProgrammeJSON();
    }
}