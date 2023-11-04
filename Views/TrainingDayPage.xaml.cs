using redraven.ViewModels;

namespace redraven.Views;

public partial class TrainingDayPage : ContentPage
{
    private TrainingDayViewModel _viewModel;

    public TrainingDayPage(TrainingDayViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    private async void IconTextButton_OnButtonOnClicked(object sender, EventArgs e)
    {
        if (!GoBackLogic()) await Shell.Current.GoToAsync("///" + nameof(MainPage));
    }

    protected override bool OnBackButtonPressed()
    {
        return GoBackLogic();
    }

    private bool GoBackLogic()
    {
        if (_viewModel.IsHistoryMode)
        {
            Shell.Current.GoToAsync("..");
            return true;
        }

        if (!_viewModel.TrainingDay.IsStarted) return false;

        Device.BeginInvokeOnMainThread(async () =>
        {
            bool answer = await DisplayAlert("Cancel workout?", "Your progress will not be saved.", "Yes", "No");
            if (answer) await Shell.Current.GoToAsync("///" + nameof(MainPage));
        });

        return true;
    }

    private async void SelectOtherPlan_OnClicked(object sender, EventArgs e)
    {
        await _viewModel.SelectOtherPlan();
    }
}