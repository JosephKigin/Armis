using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class TaxAuthLevelCode
    {
        public TaxAuthLevelCode()
        {
            TaxAuthority = new HashSet<TaxAuthority>();
        }

        public string AuthorityLevelCd { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TaxAuthority> TaxAuthority { get; set; }
    }
}
