namespace redraven.ContentViews;

public partial class PrimaryIconTextButton : ContentView
{
    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(IconTextButton), string.Empty);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty ButtonWidthProperty = BindableProperty.Create(nameof(ButtonWidth), typeof(double), typeof(IconTextButton), double.NaN);

    public double ButtonWidth
    {
        get => (double)GetValue(ButtonWidthProperty);
        set => SetValue(ButtonWidthProperty, value);
    }

    public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(ImageSource), typeof(IconTextButton), null);

    public ImageSource ImageSource
    {
        get => (ImageSource)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }

    public event EventHandler ButtonOnClicked;
    public PrimaryIconTextButton()
    {
        InitializeComponent();
    }

    void ClickGestureRecognizer_OnClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        ButtonOnClicked.Invoke(sender, e);
    }
}