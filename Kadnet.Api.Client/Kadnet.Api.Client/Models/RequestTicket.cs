using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadnet.Api.Models
{
    public class RequestTicket
    {
        public bool Result { get; set; }
        public Data Data { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class Data
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string CadastralNumber { get; set; }
    }
}
