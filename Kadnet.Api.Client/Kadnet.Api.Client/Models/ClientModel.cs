using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kadnet.Api2.Models
{
    public class ClientModel
    {
        public Guid Id { get; set; }
        public int CompanyType { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string BirthPlace { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Sex { get; set; }
        public bool IsSingle { get; set; }
        public string Snils { get; set; }
        public string InnPerson { get; set; }
        public string Address { get; set; }
        public string Citizenship { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Guid? DocumentTypeId { get; set; }
        public string DocumentSeries { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentIssuer { get; set; }
        public string DocumentIssuerCode { get; set; }
        public DateTime? DocumentDate { get; set; }

        public string CompanyName { get; set; }
        public string Ogrn { get; set; }
        public string Inn { get; set; }
        public string Kpp { get; set; }
        public string AgentTitle { get; set; }
        public Guid AgentKindId { get; set; }
        public string AuthorizationDocument { get; set; }
        public Guid? GovernanceCodeId { get; set; }
        public DateTime? CompanyRegistrationDate { get; set; }
        public bool Visible { get; set; }
    }
}