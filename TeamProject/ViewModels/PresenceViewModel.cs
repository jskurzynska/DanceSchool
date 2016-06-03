using System;
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
using TeamProject.Services;

namespace TeamProject.ViewModels
{
    public class PresenceViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly PostDataService _postDataService = new PostDataService();
        private bool _isFlyoutClosed;
        private GroupModel _group;
        private ObservableCollection<VoucherTemplateModel> _voucherTemplate;
        private PaymentModel _paymentModel = new PaymentModel() { VoucherType = VoucherType.AMOUNT };
        private ObservableCollection<ParticipantModel> _participants = new ObservableCollection<ParticipantModel>();

        public PresenceViewModel(INavigationService navigationService) 
        {
            _navigationService = navigationService;
           Messenger.Default.Register<KeyValuePair<GroupModel, ObservableCollection<ParticipantModel>>>(this, data =>
           {
               Group = data.Key ;
               Participants = data.Value;
           });
            Messenger.Default.Register<ObservableCollection<VoucherTemplateModel>>(this, vouchers => VoucherTemplate = vouchers);
        }

       
        public bool IsFlyoutClosed
        {
            get { return _isFlyoutClosed; }
            set
            {
                Set(() => IsFlyoutClosed, ref _isFlyoutClosed, value);
                if (value)
                    IsFlyoutClosed = false;
            }
        }

        public GroupModel Group
        {
            get { return _group; }
            set
            {
                _group = value; 
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<VoucherTemplateModel> VoucherTemplate
        {
            get { return _voucherTemplate; }
            set
            {
                _voucherTemplate = value;   
                RaisePropertyChanged();
            }
        }

        public PaymentModel PaymentModel
        {
            get { return _paymentModel; }
            set
            {
                _paymentModel = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<ParticipantModel> Participants
        {
            get { return _participants; }
            set
            {
                _participants = value;
                RaisePropertyChanged();
            }
        }

        public ICommand GoBackCommand =>  new RelayCommand(_navigationService.GoBack);

        public async void SendPresenceList()
        {
            await _postDataService.PostPresenceList(Participants, Group.Id);
        }

        public ICommand SendPresenceListCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    SendPresenceList();
                    _navigationService.GoBack();
                });
            }
        }

        public async void SendPayment()
        {
            await _postDataService.PostPayment(PaymentModel);
        }

        public ICommand SendPaymentCommand  
        {
            get
            {
                return new RelayCommand(() =>
                {
                    SendPayment();
                    CloseFlyout();
                });
            }
        }

        public void CloseFlyout()
        {
            IsFlyoutClosed = true;
        }

        public ICommand CancelPaymentCommand => new RelayCommand(CloseFlyout);

        private VoucherTemplateModel _chosenVoucher = new VoucherTemplateModel();

        public VoucherTemplateModel ChosenVoucher
        {
            get { return _chosenVoucher; }
            set
            {
                _chosenVoucher = value;
                RaisePropertyChanged();
            }
        }
    }
}
