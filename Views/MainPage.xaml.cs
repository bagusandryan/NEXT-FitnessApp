using System.Diagnostics;
using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using redraven.ViewModel;

namespace redraven.Views;

public partial class MainPage : ContentPage
{
    private MainViewModel _viewModel;

    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;

        var rd = App.Current.Resources.MergedDictionaries.First();
        this.Behaviors.Add(new StatusBarBehavior
        {
            StatusBarColor = (Color)rd["Surface"],
            StatusBarStyle = StatusBarStyle.LightContent
        });
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        App.Current.On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);

        UserImage.Source = File.Exists(_viewModel.User.ProfilePictureFileName) ? _viewModel.User.ProfilePictureFileName : Path.Combine(FileSystem.Current.CacheDirectory, Path.GetFileName(_viewModel.User.ProfilePictureFileName)); ;
    }

    private async void PastWorkoutClicked(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync($"TrainingHistoryPage");
    }

    private async void TrainingChart_OnLoaded(object sender, EventArgs e)
    {
        await _viewModel.LoadTrainingHistory();
    }
}

