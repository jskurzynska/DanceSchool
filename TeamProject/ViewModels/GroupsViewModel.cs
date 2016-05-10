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
using TeamProject.Repositories;
using TeamProject.Services;

namespace TeamProject.ViewModels
{
    public class GroupsViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly ManageRepositoriesService _manageRepositoriesService = new ManageRepositoriesService();

        public GroupsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Groups = new ObservableCollection<GroupModel>(_manageRepositoriesService.GroupRepository.GetAll());
        }

        private ObservableCollection<GroupModel> _groups;
        public ObservableCollection<GroupModel> Groups
        {
            get { return _groups; }
            set
            {
                _groups = value;
                RaisePropertyChanged();
            }
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
                ShowSelectedGroupParticipants();
            }
        }

        public async void ShowSelectedGroupParticipants()
        {
            var participantModels = await GetParticipantsList(SelectedGroup.Id);
            Tuple<GroupModel, ObservableCollection<ParticipantModel>> data = 
                new Tuple<GroupModel, ObservableCollection<ParticipantModel>>(SelectedGroup, participantModels);
            Messenger.Default.Send(data);
            _navigationService.NavigateTo("PresencePage");
        }

        public async Task<ObservableCollection<ParticipantModel>> GetParticipantsList(int id)
        {
            GetDataService getDataService = new GetDataService();
            return await getDataService.GetPresenceList(id);
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
