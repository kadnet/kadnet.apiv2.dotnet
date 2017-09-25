using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Kadnet.Api.Models
{
    public class HistoryEntry
    {
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public string User { get; set; }
    }
}
