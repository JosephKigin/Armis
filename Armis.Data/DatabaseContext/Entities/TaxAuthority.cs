using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class TaxAuthority
    {
        public byte TaxAuthId { get; set; }
        public string Name { get; set; }
        public decimal? SalesTaxPerc { get; set; }
        public string AuthorityLevel { get; set; }
        public int JurisdictionId { get; set; }

        public virtual TaxJurisdiction Jurisdiction { get; set; }
    }
}
