using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadnet.Api.Models
{
    public class FileResult
    {
        public string Name { get; set; }
        public MemoryStream Data { get; set; }
    }
}
