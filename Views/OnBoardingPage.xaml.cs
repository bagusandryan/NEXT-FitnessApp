using redraven.ViewModel;

namespace redraven.Views;

public partial class OnBoardingPage : ContentPage
{
    public OnBoardingPage(OnBoardingViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}