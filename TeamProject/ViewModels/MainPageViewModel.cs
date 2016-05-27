using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using TeamProject.Models;
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
        }

        public void UserNameSet()
        {
            UserName = _manageRepositoriesService.TrainerRepository.GetFirstItem();
        }

        public void NearestGroupsSet()
        {
            if(NearestGroups.Count > 0)
                return;
            var groups = _manageRepositoriesService.GroupRepository.GetAll().ToList();
            for (int i = 0; i < 2 && i < groups.Count(); ++i)
            {
                NearestGroups.Add(groups[i]);    
            }
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

        private TrainerModel _userName;
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
                return new RelayCommand( () =>
                {
                    AppService.DeleteTokenFromAppSettings();
                    _manageRepositoriesService.ClearRepositories();
                    _navigationService.NavigateTo("LoggingPage"); 
                });
            }
        }

    }
}
