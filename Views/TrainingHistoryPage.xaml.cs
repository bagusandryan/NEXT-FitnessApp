using redraven.Models;
using redraven.ViewModels;

namespace redraven.Views;

public partial class TrainingHistoryPage : ContentPage
{
    TrainingHistoryViewModel viewModel;

    public TrainingHistoryPage(TrainingHistoryViewModel _viewModel)
    {
        InitializeComponent();
        viewModel = _viewModel;
        viewModel.ReadAllHistoryJson();
        BindingContext = viewModel;
    }

    private async void TrainingHistoryCollectionView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        await viewModel.ViewTrainingHistroyDetailPage(TrainingHistoryCollectionView.SelectedItem as TrainingDay);
    }
}