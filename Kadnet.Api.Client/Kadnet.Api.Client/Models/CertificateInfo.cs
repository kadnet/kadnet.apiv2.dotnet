using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadnet.Api2.Models
{
    public class CertificateInfo
    {
        public Guid id { get; set; }
        public DateTime CreateDate { get; set; }
        public string RequestId { get; set; }
        public bool Created { get; set; }
        public bool Approved { get; set; }
        public bool Rejected { get; set; }
        public byte[] Application { get; set; }
        public string RejectComment { get; set; }
        public string CenterName { get; set; }
    }
}
