using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace TeamProject.Models
{
    public class ParticipantModel : BaseModel
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    RaisePropertyChanged("FirstName");
                }
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    RaisePropertyChanged("LastName");
                }
            }
        }
        private bool _isPresent;
        public bool IsPresent
        {
            get { return _isPresent; }
            set
            {
                if (_isPresent != value)
                {
                    _isPresent = value;
                    RaisePropertyChanged("IsPresent");
                }
            }
        }

        private bool _hasTicket;
        public bool HasTicket
        {
            get { return _hasTicket; }
            set
            {
                if (_hasTicket != value)
                {
                    _hasTicket = value;
                    RaisePropertyChanged("HasTicket");
                }
            }
        }

        private PaymentModel _payment = new PaymentModel();

        public PaymentModel Payment
        {
            get { return _payment; }
            set
            {
                if (_payment != value)
                {
                    _payment = value;
                    RaisePropertyChanged("Payment");
                }
            }
        }


    }
}
