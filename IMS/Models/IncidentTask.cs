using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.Models
{
    public class IncidentTask
    {
        public int ID { get; set; }
        public string ESname { get; set; }
        public int SID { get; set; }
        public string Floor { get; set; }
        public string Department { get; set; }
        public string TableNo { get; set; }
        public int IID { get; set; }
        public string Iname { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public DateTime EDate { get; set; }
        public string Status { get; set; }
        public DateTime SDate { get; set; }
        public int EID { get; set; }
        public string Ename { get; set; }
        public string Eway { get; set; }
        public string Satisfication { get; set; }
        public string FeedBack { get; set; }
    }
}
