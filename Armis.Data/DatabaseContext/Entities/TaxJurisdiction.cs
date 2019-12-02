using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class TaxJurisdiction
    {
        public TaxJurisdiction()
        {
            Customer = new HashSet<Customer>();
            TaxAuthority = new HashSet<TaxAuthority>();
        }

        public int JurisdictionId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<TaxAuthority> TaxAuthority { get; set; }
    }
}
