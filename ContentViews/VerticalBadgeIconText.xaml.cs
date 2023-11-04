namespace redraven.ContentViews;

public partial class VerticalBadgeIconText : ContentView
{
    public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(ImageSource), typeof(VerticalBadgeIconText), null);

    public ImageSource ImageSource
    {
        get => (ImageSource)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }

    public static readonly BindableProperty IsBadgeVisibleProperty = BindableProperty.Create(nameof(IsBadgeVisible), typeof(bool), typeof(VerticalBadgeIconText), false);

    public bool IsBadgeVisible
    {
        get => (bool)GetValue(IsBadgeVisibleProperty);
        set => SetValue(IsBadgeVisibleProperty, value);
    }

    public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(nameof(TitleText), typeof(string), typeof(VerticalBadgeIconText), string.Empty);

    public string TitleText
    {
        get => (string)GetValue(TitleTextProperty);
        set => SetValue(TitleTextProperty, value);
    }

    public static readonly BindableProperty DescriptionTextProperty = BindableProperty.Create(nameof(DescriptionText), typeof(string), typeof(VerticalBadgeIconText), string.Empty);

    public string DescriptionText
    {
        get => (string)GetValue(DescriptionTextProperty);
        set => SetValue(DescriptionTextProperty, value);
    }

    public VerticalBadgeIconText()
    {
        InitializeComponent();
    }
}