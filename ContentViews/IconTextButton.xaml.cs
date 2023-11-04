namespace redraven.ContentViews;

public partial class IconTextButton : ContentView
{
    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(IconTextButton), string.Empty);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(ImageSource), typeof(IconTextButton), null);

    public ImageSource ImageSource
    {
        get => (ImageSource)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }

    public event EventHandler ButtonOnClicked;


    public IconTextButton()
    {
        InitializeComponent();
    }

    private void IconTextButton_OnLoaded(object sender, EventArgs e)
    {
        ButtonUI.Clicked -= ButtonOnClicked;
        ButtonUI.Clicked += ButtonOnClicked;
    }
}