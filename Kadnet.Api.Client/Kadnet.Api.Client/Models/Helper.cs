using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

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
        Html,
        PdfProk
    }

    public static class Helper
    {
        public static void AddParameterAsIs(this RestRequest req, string param)
        {
            if (string.IsNullOrEmpty(param))
                return;
            var parray = param.Split('&');
            foreach (var oneP in parray)
            {
                if (string.IsNullOrEmpty(oneP)) continue;
                var kv = oneP.Split('=');
                if (kv.Length > 1)
                    req.AddParameter(kv[0], kv[1], ParameterType.QueryString);
                else
                    req.AddParameter("", kv[0]);
            }
        }
    }
}
