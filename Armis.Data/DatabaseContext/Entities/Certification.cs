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
        public string QualStdCd { get; set; }
        public string Description { get; set; }

        public virtual QualityStandard QualStdCdNavigation { get; set; }
        public virtual Specification Spec { get; set; }
        public virtual ICollection<CustForm> CustForm { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<OrderHead> OrderHead { get; set; }
    }
}
