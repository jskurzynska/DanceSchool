using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using TeamProject.Models;
using TeamProject.Services;
using TeamProject.Views;

namespace TeamProject.ViewModels
{
    public class LoggingViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly GetDataService _getDataService;
        private readonly LoginService _loginService;
        

        public LoggingViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _loginService = new LoginService();
            _getDataService = new GetDataService();
        }

        public string Email { get; set; } 
        public string Password { get; set; }

        private TrainerModel _trainerModel = new TrainerModel();
        public TrainerModel TrainerModel
        {
            get { return _trainerModel; }
            set
            {
                _trainerModel = value;
                RaisePropertyChanged();
            }
        }

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
                await dialog.ShowAsync();
                GetUserData();
                _navigationService.NavigateTo("MainPage");
            }
            catch (Exception ex)
            {
                MessageDialog dialog = new MessageDialog(ex.Message, "Error");
                await dialog.ShowAsync();
            }
        }

        private async void GetUserData()
        {
            try
            {
                TrainerModel = await _getDataService.GetTrainerInfo();
                MessageDialog dialog = new MessageDialog("Hello " + TrainerModel.Name, "Success");
                await dialog.ShowAsync();
            }
            catch (Exception ex)
            {
                MessageDialog dialog = new MessageDialog(ex.Message, "Error");
                await dialog.ShowAsync();
            }

        }
    }
}
