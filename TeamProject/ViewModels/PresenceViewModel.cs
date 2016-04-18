﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using TeamProject.Models;

namespace TeamProject.ViewModels
{
    public class PresenceViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public PresenceViewModel(INavigationService navigationService) 
        {
            _navigationService = navigationService;
            Messenger.Default.Register<GroupModel>(this, group => Group = group);
        }

        private GroupModel _group = new GroupModel();
        public GroupModel Group
        {
            get { return _group; }
            set
            {
                _group = value;
                RaisePropertyChanged();
            }
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
    }
}