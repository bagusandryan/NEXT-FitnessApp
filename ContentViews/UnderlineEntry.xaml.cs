using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Core.Platform;

namespace redraven.ContentViews;

public partial class UnderlineEntry : ContentView
{
    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(UnderlineEntry), string.Empty);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty HeaderTextProperty = BindableProperty.Create(nameof(HeaderText), typeof(string), typeof(UnderlineEntry), string.Empty);

    public string HeaderText
    {
        get => (string)GetValue(HeaderTextProperty);
        set => SetValue(HeaderTextProperty, value);
    }

    public static readonly BindableProperty PlaceholderTextProperty = BindableProperty.Create(nameof(PlaceholderText), typeof(string), typeof(UnderlineEntry), string.Empty);

    public string PlaceholderText
    {
        get => (string)GetValue(PlaceholderTextProperty);
        set => SetValue(PlaceholderTextProperty, value);
    }

    public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(UnderlineEntry), Application.Current.RequestedTheme == AppTheme.Light ? (Color)App.Current.Resources.MergedDictionaries.First()["Gray950"] : (Color)App.Current.Resources.MergedDictionaries.First()["Gray950"]);

    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(UnderlineEntry), Keyboard.Text);

    public event EventHandler<TextChangedEventArgs> EntryUIOnTextChanged;

    public Keyboard Keyboard
    {
        get => (Keyboard)GetValue(KeyboardProperty);
        set => SetValue(KeyboardProperty, value);
    }

    public UnderlineEntry()
    {
        InitializeComponent();
        EntryUI.Loaded += EntryUI_Loaded;
    }

    public async void HideKeyboard()
    {
        await EntryUI.HideKeyboardAsync(CancellationToken.None);
    }

    private void EntryUI_Loaded(object sender, EventArgs e)
    {
        EntryUI.TextChanged += EntryUIOnTextChanged;
    }

    private void Entry_OnCompleted(object sender, EventArgs e)
    {
        if (sender is Entry entry)
        {
            entry.IsEnabled = false;
            entry.IsEnabled = true;
        }
    }
}