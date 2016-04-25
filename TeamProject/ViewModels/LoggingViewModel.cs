using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using TeamProject.Services;
using TeamProject.Views;

namespace TeamProject.ViewModels
{
    public class LoggingViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly LoginService _loginService;

        public LoggingViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _loginService = new LoginService();
        }

        public string Email { get; set; } 
        public string Password { get; set; }    

        public ICommand Login => new RelayCommand( () =>
        {
          LoginClick();
        });


        private async void LoginClick()
        {
            try
            {
                var result = await _loginService.Login(Email, Password);
                MessageDialog dialog = new MessageDialog("You are now logged in as " + Email, "Success");
                dialog.ShowAsync();
                _navigationService.NavigateTo("MainPage");
            }
            catch (Exception ex)
            {
                MessageDialog dialog = new MessageDialog(ex.Message, "Error");
                dialog.ShowAsync();
            }
        }

    }
}
