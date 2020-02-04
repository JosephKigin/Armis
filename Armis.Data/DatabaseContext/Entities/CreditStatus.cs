using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class CreditStatus
    {
        public CreditStatus()
        {
            Customer = new HashSet<Customer>();
        }

        public string CredStatusCd { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
