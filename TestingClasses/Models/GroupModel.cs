using Newtonsoft.Json;

namespace TestingClasses.Models
{
    public class GroupModel : BaseModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        private bool _done;
        [JsonProperty("done")]
        public bool Done
        {
            get { return _done; }
            set
            {
                if(_done != value)
                {
                    _done = value;
                    RaisePropertyChanged(nameof(Done));
                }
            }
        }

        private string _groupName;
        [JsonProperty("groupName")]
        public string GroupName
        {
            get { return _groupName; }
            set
            {
                if (_groupName != value)
                {
                    _groupName = value;
                    RaisePropertyChanged(nameof(GroupName));
                }
            }
        }

        private string _day;
        [JsonProperty("day")]
        public string Day
        {
            get { return _day; }
            set
            {
                if (_day != value)
                {
                    _day = value;
                    RaisePropertyChanged(nameof(Day));
                }
            }
        }

        private string _time;
        [JsonProperty("time")]
        public string Time
        {
            get { return _time; }
            set
            {
                if (_time != value)
                {
                    _time = value;
                    RaisePropertyChanged(nameof(Time));
                }
            }
        }

        private string _place;
        [JsonProperty("place")]
        public string Place
        {
            get { return _place; }
            set
            {
                if (_place != value)
                {
                    _place = value;
                    RaisePropertyChanged(nameof(Place));
                }
            }
        }

        private string _address;
        [JsonProperty("address")]
        public string Address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value;
                    RaisePropertyChanged(nameof(Address));
                }
            }
        }
    }
}
