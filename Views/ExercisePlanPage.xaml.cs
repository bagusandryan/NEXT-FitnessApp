using redraven.ContentViews;
using redraven.ViewModels;

namespace redraven.Views;

public partial class ExercisePlanPage : ContentPage
{
    readonly ExercisePlanViewModel _viewModel;

    public ExercisePlanPage(ExercisePlanViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }


    protected override void OnAppearing()
    {
        _viewModel.OnAppearing();
    }

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        _viewModel.OnNavigatedFrom();
    }

    private void InputWeightUnderlineEntry_OnEntryUIOnTextChanged(object sender, TextChangedEventArgs e)
    {
        EnableDisableSaveWeightRepButton();
    }

    private void InputRepUnderlineEntry_OnEntryUIOnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue.Contains(".") || e.NewTextValue.Contains(","))
        {
            (sender as Entry).Text = e.OldTextValue;
        };
        EnableDisableSaveWeightRepButton();

    }

    private void InputWeightUnderlineEntry_OnLoaded(object sender, EventArgs e)
    {
        EnableDisableSaveWeightRepButton();
    }

    private void EnableDisableSaveWeightRepButton()
    {
        if (!string.IsNullOrWhiteSpace(InputWeightUnderlineEntry.Text) && !string.IsNullOrWhiteSpace(InputRepUnderlineEntry.Text)) SaveWeightRepButton.IsEnabled = true;
        else SaveWeightRepButton.IsEnabled = false;
    }

    private void SaveWeightRepButton_OnClicked(object sender, EventArgs e)
    {
        _viewModel.SaveCurrentGoNextSet(InputWeightUnderlineEntry.Text, InputRepUnderlineEntry.Text, SetInputCard);
    }

    private void SetInputCard_OnLoaded(object sender, EventArgs e)
    {
        _viewModel.SetInputEntires(new List<UnderlineEntry>()
        {
            InputWeightUnderlineEntry,
            InputRepUnderlineEntry
        });
    }
}