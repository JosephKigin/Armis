using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Certification
    {
        public Certification()
        {
            CustForm = new HashSet<CustForm>();
            Customer = new HashSet<Customer>();
            OrderHead = new HashSet<OrderHead>();
        }

        public byte CertId { get; set; }
        public decimal? ChargeAmt { get; set; }
        public string Stamp { get; set; }
        public int SpecId { get; set; }
        public short SpecRevId { get; set; }
        public short QualStdId { get; set; }
        public string Description { get; set; }

        public virtual QualityStandard QualStd { get; set; }
        public virtual SpecificationRevision Spec { get; set; }
        public virtual ICollection<CustForm> CustForm { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<OrderHead> OrderHead { get; set; }
    }
}
