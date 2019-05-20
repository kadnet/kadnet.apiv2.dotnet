using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using Kadnet.Objects.Rosreestr;

namespace Kadnet.Api2.Models
{
    public class DocumentModel
    {
        public Guid Id { get; set; }
        public Guid? CodeDocument { get; set; }
        //public Guid? AppId { get; set; }
        public string Name { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        public DateTime? Date { get; set;}
        public string IssueOrgan { get; set; }
        public string FileDataBase64 { get; set; }
        public string SigDataBase64 { get; set; }
        public string Filename { get; set; }
        public bool HasExternalSig { get; set; }
        /// <summary>
        /// Заявители документа. Через ApplicClientModel.Id 
        /// </summary>
        public Guid[] Signers { get; set; }
        //public static DocumentModel ConvertToDocumentModel(Kadnet.Objects.Rosreestr.AppDocument appDocument)
        //{
        //    if (appDocument == null) return null;
        //    var entry = new DocumentModel();
        //    entry.Id = appDocument.Id;
        //    entry.CodeDocument = appDocument.CodeDocument;
        //    //entry.AppId = appDocument.AppId;
        //    entry.Series = appDocument.Series;
        //    entry.Number = appDocument.Number;
        //    entry.Name = appDocument.Name;
        //    entry.Date = appDocument.Date;
        //    entry.IssueOrgan = appDocument.IssueOrgan;

        //    var appliedFile = appDocument.AppFiles.FirstOrDefault();
        //    if (appliedFile != null)
        //    {
        //        entry.Filename = appliedFile.Name;
        //        entry.HasExternalSig = appliedFile.HasExternalSig;
        //    }
        //    if (appDocument?.AppDocumentSigners != null)
        //        entry.Signers = appDocument.AppDocumentSigners.Select(s => s.RosreestrClientId).ToArray();
        //    return entry;
        //}
        //public Kadnet.Objects.Rosreestr.AppDocument ConvertToAppDocument()
        //{
        //    var entry = new AppDocument();
        //    entry.AppFiles = new List<AppFile>();
        //    entry.Id = this.Id == Guid.Empty ? Guid.NewGuid() : this.Id;
        //    entry.CodeDocument = this.CodeDocument;

        //    entry.Series = this.Series;
        //    entry.Number = this.Number;
        //    entry.Name = this.Name;
        //    entry.Date = this.Date;
        //    entry.IssueOrgan = this.IssueOrgan;
        //    entry.Visible = true;

        //    var fileEntry = new AppFile();
        //    fileEntry.Id = Guid.NewGuid();
        //    fileEntry.AppDocumentId = entry.Id;
        //    fileEntry.FileType = DeterminateFileType(this.Filename);
        //    fileEntry.Name = this.Filename;
        //    fileEntry.HasExternalSig = this.HasExternalSig;
        //    fileEntry.Date = DateTime.Now;
        //    entry.AppFiles.Add(fileEntry);

        //    return entry;
        //}
        private Guid DeterminateFileType(string filename)
        {
            switch (filename)
            {
                default:
                    return Guid.Parse("00000000-0001-0001-AC96-F394CA315699"); //Сканированные документы (PDF/JPEG)
            }
        }
    }
}