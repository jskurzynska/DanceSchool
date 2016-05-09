using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace TeamProject.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private ObservableCollection<GroupModel> _nearestGroups = new ObservableCollection<GroupModel>();
        private readonly ManageRepositoriesService _manageRepositoriesService = new ManageRepositoriesService();

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            UserName = _manageRepositoriesService.TrainerRepository.GetFirstItem();
            CreateGroups();
        }

        public ObservableCollection<GroupModel> NearestGroups
        {
            get { return _nearestGroups; }
            set
            {
                _nearestGroups = value;
                RaisePropertyChanged();
            }
        }

        public TrainerModel UserName
        {
            get { return _userName; }
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    RaisePropertyChanged();
                }
            }
        }

        private TrainerModel _userName;

        public void CreateGroups()
        {

            NearestGroups = new ObservableCollection<GroupModel>()
            {
                new GroupModel
                {
                    GroupName = "Salsa grupa początkująca ",
                    Day = "Środa",
                    Time = "16:45-17:15",
                    Place = "ul. Piłsudzkiego 34/1"
                },
                new GroupModel
                {
                    GroupName = "Salsa grupa początkująca ",
                    Day = "Środa",
                    Time = "16:45-17:15",
                    Place = "ul. Piłsudzkiego 34/1"
                },
                new GroupModel
                {
                    GroupName = "Salsa grupa początkująca ",
                    Day = "Środa",
                    Time = "16:45-17:15",
                    Place = "ul. Piłsudzkiego 34/1"
                },
                new GroupModel
                {
                    GroupName = "Taniec towarzyski grupa początkująca ",
                    Day = "Poniedziałek",
                    Time = " 16:45-17:15",
                    Place = "ul. Piłsudzkiego 34/1"
                }

            };
        }
        public ICommand MyGroupsCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    await _manageRepositoriesService.GetGroups();
                    _navigationService.NavigateTo("GroupsPage");
                });
            }
        }

        public ICommand LogoutCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    AppService.DeleteTokenFromAppSettings();
                    _navigationService.NavigateTo("LoggingPage"); 
                });
            }
        }

    }
}
