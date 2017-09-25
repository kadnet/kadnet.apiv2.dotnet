using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadnet.Api.Models
{
    public class RequestInfo
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public string Number { get; set; }
        public string RosreestrRequestNumber {get;set;}
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public DateTime RequestDateByRosreestr { get; set; }
        public string Region { get; set; }
        public string ObjectType { get; set; }
        public string Status { get; set; }
        public string RosreestrRequestType { get; set; }
        public int Priority { get; set; }
        public bool Visible { get; set; }
        public bool Read { get; set; }
    }
}
