﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using TestingClasses.Services;


namespace TeamProject.ViewModels
{
    public class LoggingViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly LoginService _loginService = new LoginService();
        private readonly ManageRepositoriesService _manageRepositoriesService;
       
        public LoggingViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _manageRepositoriesService = new ManageRepositoriesService();
        }

        public string Email { get; set; } 
        public string Password { get; set; }

        public ICommand Login => new RelayCommand(async () =>
        {
            await LoginClick();
        });

        private async Task LoginClick()
        {
            try
            {

                await _loginService.Login(Email, Password);
                await _manageRepositoriesService.GetUserData();
                await _manageRepositoriesService.GetGroups();
                _navigationService.NavigateTo("MainPage");
            }
            catch (Exception ex)
            {
                MessageDialog dialog = new MessageDialog("Logowanie się nie powiodło! \n Spróbuj ponownie!");
                await dialog.ShowAsync();
            }
        }

       
    }
}
