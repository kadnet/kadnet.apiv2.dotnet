using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// using Kadnet.Objects.Rosreestr;

namespace Kadnet.Api2.Models
{
    using System.Globalization;

   

    public class ApplicClientModel
    {
        public Guid Id {get;set;}
        public Guid ClientId { get; set; }
        public string Role { get; set; }
        /// <summary>
        /// ID основного участника для совместной собственности
        /// </summary>
        public Guid GroupId { get; set; }
        /// <summary>
        /// Доля в формате 1/2
        /// </summary>
        public string OwnerPart { get; set; }
        /// <summary>
        /// Id представителя
        /// </summary>
        public Guid? AgentId { get; set; }

        //public static ApplicClientModel ConvertToApplicClientModel(RosreestrClient rc)
        //{
        //    if (rc == null) return null;
        //    var racm = new ApplicClientModel();
        //    racm.Id = rc.Id;
        //    racm.ClientId = rc.KadnetUserClient;
        //    racm.Role = rc.ClientType;
        //    racm.GroupId = rc.GroupId;
        //    racm.OwnerPart = rc.OwnerPart;
        //    racm.AgentId = rc.AgentId;
        //    return racm;
        //}

        //public RosreestrClient ConvertToRosreestrClient()
        //{
        //    var rc = new RosreestrClient();
        //    rc.Id = this.Id;
        //    rc.KadnetUserClient= this.ClientId;
        //    rc.OwnerPart = this.OwnerPart;
        //    rc.GroupId = this.GroupId;
        //    rc.ClientType = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(this.Role);
        //    rc.AgentId = this.AgentId;
        //    return rc;
        //}
    }
}