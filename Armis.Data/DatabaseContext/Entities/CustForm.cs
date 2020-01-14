using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class CustForm
    {
        public int CustId { get; set; }
        public byte? CertId { get; set; }
        public byte? NumCertCopies { get; set; }
        public string WhenToPrint { get; set; }
        public string PackSlipFormId { get; set; }
        public byte? NumPackSlipCopies { get; set; }
        public string InvoiceFormId { get; set; }
        public string ReturnLabelFormId { get; set; }
        public byte? CopiesOfLabel { get; set; }
        public string StatementFormId { get; set; }
        public string InspectionFormId { get; set; }
        public string ConsolidatedInvoiceId { get; set; }

        public virtual Certification Cert { get; set; }
        public virtual Customer Cust { get; set; }
    }
}
