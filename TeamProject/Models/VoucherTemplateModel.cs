using System.Collections.Generic;
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

        public override string ToString()
        {
            return $"{DecodeVoucherValue()} - {ManipulatePrice()} zl";
        }

        public string DecodeVoucherValue()
        {
            return Value.Contains("P")  ? DecodeTimeValue() : DecodeAmountType();
        }


        public string ManipulatePrice()
        {
            var result = Price.ToString().Replace(".", ",");
            var strings = result.Split(',');
            if (strings[1].Length < 2)
            {
                result += "0";
            }
            return result;
        }

        private string DecodeAmountType()
        {
            return $"{Value} wejść ";
        }

        private readonly Dictionary<string,string> _dictionary;
        
        public VoucherTemplateModel()
        {
            _dictionary = new Dictionary<string, string>()
            {
                {"P", " "},
                {"Y", " lat "},
                {" 1 lat", " 1 rok "},
                {" 2 lat", " 2 lata "},
                {" 3 lat", " 3 lata "},
                {" 4 lat", " 4 lata "},
                {"M", " miesięcy "},
                {" 1 miesięcy", " 1 miesiąc "},
                {" 2 miesięcy", " 2 miesiące "},
                {" 3 miesięcy", " 3 miesiące "},
                {" 4 miesięcy", " 4 miesiące "},
                {"D", " dni "},
                {" 1 dni", " 1 dzień "}
            };
        }

        public string DecodeTimeValue()
        {
            var result = Value;

            foreach (var keyValue in _dictionary)
            {
                result = result.Replace(keyValue.Key, keyValue.Value);
            }

            return result;
        }
    }
}
