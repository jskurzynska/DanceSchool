using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Models
{
    public class PaymentModel: BaseModel
    {
        private bool _oneDayTicket;
        private bool _monthTicket;
        private bool _seasonTicket;

        public PaymentModel()
        {
            OneDayTicket = false;
            MonthTicket = false;
            SeasonTicket = false;
        }

        public bool MonthTicket
        {
            get { return _monthTicket; }
            set
            {
                if ( _monthTicket != value)
                {
                    _monthTicket = value;
                    RaisePropertyChanged("MonthTicket");
                }
            }
        }

        public bool SeasonTicket
        {
            get { return _seasonTicket; }
            set
            {
                if (_seasonTicket != value)
                {
                    _seasonTicket = value;
                    RaisePropertyChanged("SeasonTicket");
                }
            }
        }

        public bool OneDayTicket
        {
            get { return _oneDayTicket; }
            set
            {
                if (_oneDayTicket != value)
                {
                    _oneDayTicket = value;
                    RaisePropertyChanged("OneDayTicket");
                }
            }
        }
    }
}
