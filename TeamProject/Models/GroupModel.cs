using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;
using Windows.Graphics.Printing.OptionDetails;

namespace TeamProject.Models
{
    public class GroupModel : BaseModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        private string _date;
        public string Date
        {
            get { return _date; }
            set
            {
                if (_date != value)
                {
                    _date = value;
                    RaisePropertyChanged("Date");
                }
            }
        }

        private string _place;
        public string Place
        {
            get { return _place; }
            set
            {
                if (_place != value)
                {
                    _place = value;
                    RaisePropertyChanged("Place");
                }
            }
        }

        public ObservableCollection<ParticipantModel> Participants 
        {
            get { return _participants; }
            set
            {
                if (_participants != value)
                {
                    _participants = value;
                    RaisePropertyChanged("Participants");
                }        
            }
        }

        private ObservableCollection<ParticipantModel> _participants  = new ObservableCollection<ParticipantModel>();
    }
}
