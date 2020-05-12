using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class TaxAuthorityLevelCode
    {
        public TaxAuthorityLevelCode()
        {
            TaxAuthority = new HashSet<TaxAuthority>();
        }

        public byte TaxAuthorityLevelId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TaxAuthority> TaxAuthority { get; set; }
    }
}
