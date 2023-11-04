using Microsoft.Maui.Platform;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using redraven.Views;

namespace redraven;

public partial class App
{
    public App()
    {
        InitializeComponent();
        App.Current.On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
        Routing.RegisterRoute("TrainingDayPage", typeof(Views.TrainingDayPage));
        Routing.RegisterRoute("ExercisePlanPage", typeof(Views.ExercisePlanPage));
        Routing.RegisterRoute("TrainingHistoryPage", typeof(Views.TrainingHistoryPage));
        Routing.RegisterRoute("OnBoardingPage", typeof(Views.OnBoardingPage));
        Routing.RegisterRoute("TrainingDayEditorPage", typeof(Views.TrainingDayEditorPage));
        //Routing.RegisterRoute("SettingsPage", typeof(Views.SettingsPage));
        UserAppTheme = AppTheme.Dark;
        MainPage = new AppShell();
    }
}