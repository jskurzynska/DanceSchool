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
using TeamProject.Services;

namespace TeamProject.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private ObservableCollection<GroupModel> _nearestGroups  = new ObservableCollection<GroupModel>();

        public ObservableCollection<GroupModel> NearestGroups
        {
            get { return _nearestGroups; }
            set
            {
                _nearestGroups = value;
                RaisePropertyChanged();
            }
        }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            CreateGroups();
            //TODO: Poprawic bo bez sensu
            Messenger.Default.Register<TrainerModel>(this, user => User = user);
        }

        //TODO: Ogarnac zeby mialo rece i nogi
        public TrainerModel User
        {
            get { return _user; }
            set
            {
                if (_user != value)
                {
                    _user = value;
                    RaisePropertyChanged();
                }
            }
        }
        private TrainerModel _user = new TrainerModel() {Name = "ASIUNIA"};

        //TODO: rozdzielic powyższy model na to co poniżej
        /*public string UserName
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
        private string _userName;

        public string City
        {
            get { return _city; }
            set
            {
                if (_city != value)
                {
                    _city = value;
                    RaisePropertyChanged();
                }
            }
        }
        private string _city;
        */

        public void CreateGroups()
        {

            NearestGroups = new ObservableCollection<GroupModel>()
            {
                new GroupModel
                {
                    Name = "Salsa grupa początkująca ",
                    Date = "Środa 16:45-17:15",
                    Place = "ul. Piłsudzkiego 34/1"
                },
                new GroupModel
                {
                    Name = "Salsa grupa początkująca ",
                    Date = "Środa 16:45-17:15",
                    Place = "ul. Piłsudzkiego 34/1"
                },
                new GroupModel
                {
                    Name = "Salsa grupa początkująca ",
                    Date = "Środa 16:45-17:15",
                    Place = "ul. Piłsudzkiego 34/1"
                },
                new GroupModel
                {
                    Name = "Taniec towarzyski grupa początkująca ",
                    Date = "Poniedziałek 16:45-17:15",
                    Place = "ul. Piłsudzkiego 34/1"
                }

            };
        }
        public ICommand MyGroupsCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
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
                    _navigationService.GoBack();
                });
            }
        }

    }
}
