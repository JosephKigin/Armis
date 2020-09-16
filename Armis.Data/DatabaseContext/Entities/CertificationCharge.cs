using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class CertificationCharge
    {
        public CertificationCharge()
        {
            Customer = new HashSet<Customer>();
            OrderHead = new HashSet<OrderHead>();
        }

        public short CertChargeId { get; set; }
        public decimal DefaultChargeAmt { get; set; }
        public decimal NadcapChargeAmt { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<OrderHead> OrderHead { get; set; }
    }
}
