using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadnet.Api.Models
{
    public class CadastralObjectInfo
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public string Info { get; set; }
        public string ObjectType { get; set; }
        public string Region { get; set; }
        public Guid OrderId { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public double Area { get; set; }
        public double CadCost { get; set; }
        public string Status { get; set; }
        public string Year { get; set; }
        public bool IsCanceled { get; set; }

        public List<Right> Rights { get; set; }
    }

    public class Right
    {
        public string Number { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public List<Encumbrance> Encumbrances { get; set; }
    }

    public class Encumbrance
    {
        public string Number { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}
