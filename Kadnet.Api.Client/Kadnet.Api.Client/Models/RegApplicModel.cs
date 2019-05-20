using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Kadnet.Api2.Models
{
    public class RegApplicModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid KindId { get; set; }
        public DateTime CreateTime { get; set; }
        public int StatusId { get; set; }
        public string UserDescription { get; set; }
        /// <summary>
        /// Комментарий к заявлению. Будет включен добавлен в заявление и обработан регистраторами в Росреестре.
        /// </summary>
        public string CommentForRosreestr { get; set; }
        /// <summary>
        /// Портальный номер заявления
        /// </summary>
        public string PortalNumber { get; set; }
        /// <summary>
        /// Номер заявления в книге учета входящих документов
        /// </summary>
        public string GeneralNumber { get; set; }
        /// <summary>
        /// Номер основного заявления
        /// </summary>
        public string BaseApplicNumber { get; set; }
        /// <summary>
        /// Дата основного заявления
        /// </summary>
        public DateTime? BaseApplicDate { get; set; }
        /// <summary>
        /// Код платежа
        /// </summary>
        public string PaymentCode { get; set; }
        /// <summary>
        /// Уточненые права
        /// </summary>
        public Guid? SpecifiedDocumentId { get; set; }
        public Guid[] Objects { get; set; }
        public ApplicClientModel[] Clients { get; set; }
        public DocumentModel[] AppliedDocuments { get; set; }

    }
}