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
        public string AuthorityLevelCd { get; set; }

        public virtual TaxAuthLevelCode AuthorityLevelCdNavigation { get; set; }
        public virtual ICollection<TaxJurisAuthority> TaxJurisAuthority { get; set; }
    }
}
