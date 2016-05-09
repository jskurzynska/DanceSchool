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
using TeamProject.Repositories;
using TeamProject.Services;
using TeamProject.Views;

namespace TeamProject.ViewModels
{
    public class LoggingViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly GetDataService _getDataService;
        private readonly LoginService _loginService;
        private readonly DbService _dbService = new DbService();
        
        public LoggingViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _loginService = new LoginService();
            _getDataService = new GetDataService();
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
                _dbService.CreateDb();
                TrainerModel trainer = await _getDataService.GetTrainerInfo();
                Repository<TrainerModel> trainerRepository = new Repository<TrainerModel>(DbService.DbConn);
                trainerRepository.Add(trainer);
            }
            catch (Exception ex)
            {
                MessageDialog dialog = new MessageDialog(ex.Message, "Error");
                await dialog.ShowAsync();
            }

        }
    }
}
