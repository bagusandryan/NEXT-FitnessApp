using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using redraven.ViewModels;
using Entry = Microsoft.Maui.Controls.Entry;

namespace redraven.Views;

public partial class SettingsPage : ContentPage
{
    SettingsViewModel _viewModel;

    public SettingsPage(SettingsViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        App.Current.On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Pan);
        UserProfileImage.Source = _viewModel.SelectedUser.ProfilePictureFileName;
        MarginLeftEntry.Text = _viewModel.SelectedUser.ProfilePictureMargin[0].ToString();
        MarginTopEntry.Text = _viewModel.SelectedUser.ProfilePictureMargin[1].ToString();
        MarginRightEntry.Text = _viewModel.SelectedUser.ProfilePictureMargin[2].ToString();
        MarginBottomEntry.Text = _viewModel.SelectedUser.ProfilePictureMargin[3].ToString();
        base.OnAppearing();
    }


    private void LeftUnderlineEntry_OnEntryUIOnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is Entry entry && !string.IsNullOrWhiteSpace(entry.Text) && entry.Text is not "-" or ",")
        {
            try
            {
                UserProfileImage.Margin = new Thickness(Convert.ToDouble(entry.Text), UserProfileImage.Margin.Top,
                        UserProfileImage.Margin.Right, UserProfileImage.Margin.Bottom);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    private void TopUnderlineEntry_OnEntryUIOnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is Entry entry && !string.IsNullOrWhiteSpace(entry.Text) && entry.Text is not "-" or ",")
        {
            try
            {
                UserProfileImage.Margin = new Thickness(UserProfileImage.Margin.Left, Convert.ToDouble(entry.Text),
                        UserProfileImage.Margin.Right, UserProfileImage.Margin.Bottom);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    private void RightUnderlineEntry_OnEntryUIOnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is Entry entry && !string.IsNullOrWhiteSpace(entry.Text) && entry.Text is not "-" or ",")
        {
            try
            {
                UserProfileImage.Margin = new Thickness(UserProfileImage.Margin.Left, UserProfileImage.Margin.Top,
                        Convert.ToDouble(entry.Text), UserProfileImage.Margin.Bottom);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    private void BottomUnderlineEntry_OnEntryUIOnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is Entry entry && !string.IsNullOrWhiteSpace(entry.Text) && entry.Text is not "-" or ",")
        {
            try
            {
                UserProfileImage.Margin = new Thickness(UserProfileImage.Margin.Left, UserProfileImage.Margin.Top,
                        UserProfileImage.Margin.Right, Convert.ToDouble(entry.Text));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        _viewModel.UpdateUserMargin(new[]
        {
            UserProfileImage.Margin.Left,
            UserProfileImage.Margin.Top,
            UserProfileImage.Margin.Right,
            UserProfileImage.Margin.Bottom,
        });
    }

    private async void Username_EntryOnTextChanged(object sender, TextChangedEventArgs e)
    {
        await _viewModel.UpdateUserName(UsernameUnderlineEntry.Text);
    }
}