using SilasTube.ViewModels;

namespace SilasTube;

public partial class MainPage : ContentPage
{
    public MainPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}