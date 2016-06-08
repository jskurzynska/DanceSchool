using Newtonsoft.Json;
using SQLite.Net.Attributes;

namespace TestingClasses.Models
{
    public class ParticipantModel : BaseModel
    {
        [JsonProperty("id")]
        [PrimaryKey]
        public int Id { get; set; }

        private string _name;
        [JsonProperty("name")]
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

        private bool _present;
        [JsonProperty("present")]
        public bool? Present
        {
            get { return _present; }
            set
            {
                if (_present != value)
                {
                    if (value != null) _present = (bool) value;
                    RaisePropertyChanged("Present");
                }
            }
        }

        private bool _voucherValid;
        [JsonProperty("voucherValid")]
        public bool VoucherValid
        {
            get { return _voucherValid; }
            set
            {
                if (_voucherValid != value)
                {
                    _voucherValid = value;
                    RaisePropertyChanged("VoucherValid");
                }
            }
        }

    }
}
