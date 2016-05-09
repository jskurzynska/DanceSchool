using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TeamProject.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using TeamProject.Repositories;
using TeamProject.Services;

namespace TeamProject.ViewModels
{
    public class GroupsViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private ObservableCollection<GroupModel> _groups = new ObservableCollection<GroupModel>();

        public ObservableCollection<GroupModel> Groups
        {
            get { return _groups; }
            set
            {
                _groups = value;
                RaisePropertyChanged();
            }
        }

        public GroupsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Messenger.Default.Register<ObservableCollection<GroupModel>>(this, groups => Groups = groups);
            // CreateGroups();
        }

        public void CreateGroups()
        {

            Groups = new ObservableCollection<GroupModel>()
            {
                new GroupModel
                {
                    GroupName = "Rumba grupa początkująca ",
                    Day = "Środa",
                    Time = " 16:45-17:15",
                    Place = "ul. Piłsudzkiego 34/1",
                    Participants = CreateParticipants()
                },
                new GroupModel
                {
                    GroupName = "Salsa grupa początkująca ",
                    Day = "Środa",
                    Time = " 16:45-17:15",
                    Place = "ul. Piłsudzkiego 34/1",
                    Participants = CreateParticipants()
                },
                new GroupModel
                {
                    GroupName = "Salsa grupa początkująca ",
                    Day = "Środa",
                    Time = " 16:45-17:15",
                    Place = "ul. Piłsudzkiego 34/1",
                    Participants = CreateParticipants()
                },
                new GroupModel
                {
                    GroupName = "Taniec towarzyski grupa początkująca ",
                    Day = "Poniedziałek",
                    Time = " 16:45-17:15",
                    Place = "ul. Piłsudzkiego 34/1",
                    Participants = CreateParticipants()
                },
                 new GroupModel
                {
                    GroupName = "Salsa grupa początkująca ",
                    Day = "Środa",
                    Time = " 16:45-17:15",
                    Place = "ul. Piłsudzkiego 34/1",
                    Participants = CreateParticipants()
                },
                new GroupModel
                {
                    GroupName = "Salsa grupa początkująca ",
                    Day = "Środa",
                    Time = " 16:45-17:15",
                    Place = "ul. Piłsudzkiego 34/1",
                    Participants = CreateParticipants()
                }
            };          
        }

        public ObservableCollection<ParticipantModel> CreateParticipants()
        {
            return new ObservableCollection<ParticipantModel>()
           {
               new ParticipantModel
               {
                   FirstName = "Joanna",
                   LastName = "Skurzyńska",
                   IsPresent = false,
                   HasTicket = true
               },
               new ParticipantModel
               {
                   FirstName = "Tomasz",
                   LastName = "Rojek",
                   HasTicket = false
               },
               new ParticipantModel
               {
                   FirstName = "Alicja",
                   LastName = "Majewska"
               },
               new ParticipantModel
               {
                   FirstName = "Jakub",
                   LastName = "Dymon"
               },
               new ParticipantModel
               {
                   FirstName = "Bartosz",
                   LastName = "Haliniak"
               }
           };

        }

        private GroupModel _selectedGroup;
        public GroupModel SelectedGroup
        {
            get
            {
                return _selectedGroup;
            }

            set
            {
                _selectedGroup = value;
                RaisePropertyChanged();
                ShowThis();
            }
        }

        public void ShowThis()
        {
            Messenger.Default.Send(SelectedGroup);
            _navigationService.NavigateTo("PresencePage");
        }

        public ICommand GoBackCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    _navigationService.GoBack();
                });
            }
        }


        public ICommand ShowThisGroupCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Messenger.Default.Send(SelectedGroup);
                    _navigationService.NavigateTo("PresencePage");
                });
            }
        }
       
    }
}
