using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Models
{
    public class Incident
    {
        public int ID { get; set; }
        public string Iname { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Solution { get; set; }
        public byte[] Images { get; set; }
        public byte[] Videos { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public int Count { get; set; }
    }
}
