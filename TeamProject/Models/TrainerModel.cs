using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SQLite.Net.Attributes;

namespace TeamProject.Models
{
    public class TrainerModel : BaseModel
    {
        private string _name;

        [JsonProperty("id")]
        [PrimaryKey]
        public int Id { get; set; }

        [JsonProperty("frontName")]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged(nameof(Name));
                }
            }
        }

        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonProperty("pesel")]
        public string Pesel { get; set; }
        [JsonProperty("readableAdress")]
        public string Address { get; set; }
        [JsonProperty("avatar")]
        public string PhotoUrl { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
    }
}
