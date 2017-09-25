using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kadnet.Api.Models
{
    public enum RequestType
    {
        EgrnObject,
        EgrnRightList
    }

    public enum ResultFormat
    {
        Xml,
        Pdf,
        Html
    }
}
