namespace redraven.ContentViews;

public partial class ToggleIconTextButton : ContentView
{
    public bool IsChecked => CheckBox.IsChecked;

    public static readonly BindableProperty IconSourceProperty = BindableProperty.Create(nameof(IconSource), typeof(ImageSource), typeof(ToggleIconTextButton), null);

    public ImageSource IconSource
    {
        get => (ImageSource)GetValue(IconSourceProperty);
        set => SetValue(IconSourceProperty, value);
    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(ToggleIconTextButton), string.Empty);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public ToggleIconTextButton()
    {
        InitializeComponent();
    }

    private void ClickGestureRecognizer_OnClicked(object sender, EventArgs e)
    {
        if (CheckBox.IsChecked)
        {
            CheckBox.IsChecked = false;
        }
        else
        {
            CheckBox.IsChecked = true;
        }
    }

    private void CheckBox_OnCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        Color primaryColor = Colors.Blue;
        Color secondaryColor = Colors.Black;
        if (App.Current.Resources.TryGetValue("Primary", out var colorvalue))
            primaryColor = (Color)colorvalue;
        if (App.Current.Resources.TryGetValue("Surface", out var colorvalue2))
            secondaryColor = (Color)colorvalue2;

        if (CheckBox.IsChecked)
        {
            BorderContent.Background = secondaryColor;
            ToggleLabel.TextColor = primaryColor;
        }
        else
        {
            ToggleLabel.TextColor = secondaryColor;
            BorderContent.Background = primaryColor;
        }
        OnPropertyChanged(nameof(IsChecked));
    }
}