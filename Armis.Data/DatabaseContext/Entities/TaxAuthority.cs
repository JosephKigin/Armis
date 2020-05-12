using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class TaxAuthority
    {
        public TaxAuthority()
        {
            TaxJurisAuthority = new HashSet<TaxJurisAuthority>();
        }

        public int TaxAuthId { get; set; }
        public string Name { get; set; }
        public decimal SalesTaxPerc { get; set; }
        public byte TaxAuthorityLevelId { get; set; }

        public virtual TaxAuthorityLevelCode TaxAuthorityLevel { get; set; }
        public virtual ICollection<TaxJurisAuthority> TaxJurisAuthority { get; set; }
    }
}
