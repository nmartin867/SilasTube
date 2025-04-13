using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using SilasTube.Services;

namespace SilasTube.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    private readonly IUserService _userService;

    public LoginViewModel(IUserService userService)
    {

        Title = "Login";
        _userService = userService;
    }


    [RelayCommand]
    async Task LoginAsync()
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;
            await _userService.LoginAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"User Login Failed: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}