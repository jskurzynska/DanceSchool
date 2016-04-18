using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace TeamProject.ViewModels
{
    public class LoggingViewModel
    {
        private readonly INavigationService _navigationService;

        public LoggingViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ICommand GoToMainPageCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    _navigationService.NavigateTo("MainPage");
                });
            }
        }

    }
}
