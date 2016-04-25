using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Models
{
    public class TrainerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Pesel { get; set; }
        public string Address { get; set; }
        public string PhotoName { get; set; }
        public string City { get; set; }     
    }
}
