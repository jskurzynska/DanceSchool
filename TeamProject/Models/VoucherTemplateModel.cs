using Newtonsoft.Json;

namespace TeamProject.Models
{
    public class VoucherTemplateModel: BaseModel
    {
        private long _id;
        private double _price;
        private string _value;

        [JsonProperty("id")]
        public long Id
        {
            get { return _id; }
            set
            {
                if (_id == value) return;
                _id = value;
                RaisePropertyChanged(nameof(Id));
            }
        }

        [JsonProperty("price")]
        public double Price
        {
            get { return _price; }
            set
            {
                if (_price == value) return;
                _price = value;
                RaisePropertyChanged(nameof(Price));
            }
        }
        
        [JsonProperty("value")]
        public string Value
        {
            get { return _value; }
            set
            {
                if (_value == value) return;
                _value = value;
                RaisePropertyChanged(nameof(Value));
            }
        }

        //private bool _isChecked;
        //[JsonIgnore]
        //public bool IsChecked
        //{
        //    get { return _isChecked; }
        //    set
        //    {
        //        if( _isChecked == value) return;
        //        _isChecked = value;
        //        RaisePropertyChanged(nameof(IsChecked));
        //    }
        //}


        public override string ToString()
        {
            return $"{Value} wejść - {Price} zl";
        }
    }
}
