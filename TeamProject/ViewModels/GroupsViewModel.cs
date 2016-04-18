﻿using System;
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
            CreateGroups();
        }

        public void CreateGroups()
        {

            Groups = new ObservableCollection<GroupModel>()
            {
                new GroupModel
                {
                    Name = "Rumba grupa początkująca ",
                    Date = "Środa 16:45-17:15",
                    Place = "ul. Piłsudzkiego 34/1",
                    Participants = CreateParticipants()
                },
                new GroupModel
                {
                    Name = "Salsa grupa początkująca ",
                    Date = "Środa 16:45-17:15",
                    Place = "ul. Piłsudzkiego 34/1",
                    Participants = CreateParticipants()
                },
                new GroupModel
                {
                    Name = "Salsa grupa początkująca ",
                    Date = "Środa 16:45-17:15",
                    Place = "ul. Piłsudzkiego 34/1",
                    Participants = CreateParticipants()
                },
                new GroupModel
                {
                    Name = "Taniec towarzyski grupa początkująca ",
                    Date = "Poniedziałek 16:45-17:15",
                    Place = "ul. Piłsudzkiego 34/1",
                    Participants = CreateParticipants()
                },
                 new GroupModel
                {
                    Name = "Salsa grupa początkująca ",
                    Date = "Środa 16:45-17:15",
                    Place = "ul. Piłsudzkiego 34/1",
                    Participants = CreateParticipants()
                },
                new GroupModel
                {
                    Name = "Salsa grupa początkująca ",
                    Date = "Środa 16:45-17:15",
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