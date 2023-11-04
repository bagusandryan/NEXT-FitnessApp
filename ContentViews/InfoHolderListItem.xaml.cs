using CommunityToolkit.Maui.Behaviors;

namespace redraven.ContentViews;

public partial class InfoHolderListItem : ContentView
{
    public static readonly BindableProperty ImageSource1Property = BindableProperty.Create(nameof(ImageSource1), typeof(ImageSource), typeof(InfoHolderListItem), null);

    public ImageSource ImageSource1
    {
        get => (ImageSource)GetValue(ImageSource1Property);
        set => SetValue(ImageSource1Property, value);
    }

    public static readonly BindableProperty ImageSource2Property = BindableProperty.Create(nameof(ImageSource2), typeof(ImageSource), typeof(InfoHolderListItem), null);

    public ImageSource ImageSource2
    {
        get => (ImageSource)GetValue(ImageSource2Property);
        set => SetValue(ImageSource2Property, value);
    }

    public static readonly BindableProperty IsImageVisible1Property = BindableProperty.Create(nameof(IsImageVisible1), typeof(bool), typeof(InfoHolderListItem), false);

    public bool IsImageVisible1
    {
        get => (bool)GetValue(IsImageVisible1Property);
        set => SetValue(IsImageVisible1Property, value);
    }

    public static readonly BindableProperty IsImageVisible2Property = BindableProperty.Create(nameof(IsImageVisible2), typeof(bool), typeof(InfoHolderListItem), false);

    public bool IsImageVisible2
    {
        get => (bool)GetValue(IsImageVisible2Property);
        set => SetValue(IsImageVisible2Property, value);
    }

    public static readonly BindableProperty IsRightChevronVisibleProperty = BindableProperty.Create(nameof(IsRightChevronVisible), typeof(bool), typeof(InfoHolderListItem), true);

    public bool IsRightChevronVisible
    {
        get => (bool)GetValue(IsRightChevronVisibleProperty);
        set => SetValue(IsRightChevronVisibleProperty, value);
    }

    public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(nameof(TitleText), typeof(string), typeof(InfoHolderListItem), string.Empty);

    public string TitleText
    {
        get => (string)GetValue(TitleTextProperty);
        set => SetValue(TitleTextProperty, value);
    }

    public static readonly BindableProperty DescriptionTextProperty = BindableProperty.Create(nameof(DescriptionText), typeof(string), typeof(InfoHolderListItem), string.Empty);

    public string DescriptionText
    {
        get => (string)GetValue(DescriptionTextProperty);
        set => SetValue(DescriptionTextProperty, value);
    }

    public static readonly BindableProperty InfoSmallBoxTextProperty = BindableProperty.Create(nameof(InfoSmallBoxText), typeof(string), typeof(InfoHolderListItem), string.Empty);

    public string InfoSmallBoxText
    {
        get => (string)GetValue(InfoSmallBoxTextProperty);
        set => SetValue(InfoSmallBoxTextProperty, value);
    }

    //public static readonly BindableProperty StrokeBrushProperty = BindableProperty.Create(nameof(StrokeBrush), typeof(SolidColorBrush), typeof(InfoHolderListItem), new SolidColorBrush(Colors.Transparent));

    //public SolidColorBrush StrokeBrush
    //{
    //    get => (SolidColorBrush)GetValue(StrokeBrushProperty);
    //    set => SetValue(StrokeBrushProperty, value);
    //}

    public static readonly BindableProperty StrokeThicknessProperty = BindableProperty.Create(nameof(StrokeThickness), typeof(double), typeof(InfoHolderListItem), 0.0);

    public double StrokeThickness
    {
        get => (double)GetValue(StrokeThicknessProperty);
        set => SetValue(StrokeThicknessProperty, value);
    }

    public InfoHolderListItem()
    {
        InitializeComponent();
    }
}