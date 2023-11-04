using CommunityToolkit.Maui;
using Microsoft.Maui.LifecycleEvents;
using redraven.Models;
using redraven.Services;
using redraven.ViewModel;
using redraven.ViewModels;
using redraven.Views;

namespace redraven;

public static class MauiProgram
{
    public static readonly string UserSelectedProgramme = Path.Combine(FileSystem.AppDataDirectory, "user_programme.json");
    public static readonly string SeparatorText = " ● ";
    public static double UserBodyWeight = 40;

    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureLifecycleEvents(events =>
            {
#if ANDROID
                events.AddAndroid(android => android.OnCreate((activity, bundle) => MakeStatusBarTranslucent(activity)));
                static void MakeStatusBarTranslucent(Android.App.Activity activity)
                {
                    activity.Window.SetNavigationBarColor(Android.Graphics.Color.ParseColor("#313737"));
                }
#endif
            })
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("OpenSans-Light.ttf", "OpenSansLight");
                fonts.AddFont("OpenSans-ExtraBold.ttf", "OpenSansExtraBold");
            });
        builder.Services.AddSingleton<ExerciseService>();
        builder.Services.AddSingleton<UserService>();
        builder.Services.AddSingleton<ProgrammeService>();
        builder.Services.AddSingleton<TrainingDayService>();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();

        builder.Services.AddTransient<TrainingDayViewModel>();
        builder.Services.AddTransient<TrainingDayPage>();

        builder.Services.AddTransient<OnBoardingViewModel>();
        builder.Services.AddTransient<OnBoardingPage>();

        builder.Services.AddTransient<ProgrammeManagerViewModel>();
        builder.Services.AddTransient<ProgrammeManagerPage>();

        builder.Services.AddTransient<TrainingDayEditorViewModel>();
        builder.Services.AddTransient<TrainingDayEditorPage>();

        builder.Services.AddTransient<ExercisePlanViewModel>();
        builder.Services.AddTransient<ExercisePlanPage>();

        builder.Services.AddTransient<SettingsViewModel>();
        builder.Services.AddTransient<SettingsPage>();

        builder.Services.AddTransient<TrainingHistoryPage>();
        builder.Services.AddTransient<TrainingHistoryViewModel>();

        FormHandler.RemoveBorders();
        return builder.Build();
    }
}

public static class FormHandler
{
    public static void RemoveBorders()
    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("Borderless", (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.Background = null;
            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif IOS
            handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
            handler.PlatformView.Layer.BorderWidth = 0;
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
        });

        Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("Borderless", (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.Background = null;
            handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif IOS
            handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
            handler.PlatformView.Layer.BorderWidth = 0;
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
        });
    }
}