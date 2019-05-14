using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Models
{
    public class Staff
    {
        public int ID { get; set; }
        public string Sname { get; set; }
        public long IC { get; set; }
        public string Designation { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int MobileNo { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Floor { get; set; }
        public string Department { get; set; }
        public string TableNo { get; set; }
        public string Status { get; set; }
        public int Spoint { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public DateTime JoinedDate { get; set; }
    }

}
