using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TeamProject.Models
{
    public class TrainerModel : BaseModel
    {
        private string _name;

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("frontName")]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
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
