using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kadnet.Api2.Models
{
    public class RealtyObject
    {
        public Guid Id { get; set; }
        public Guid KindId { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }
        public double Area { get; set; }
    }
}