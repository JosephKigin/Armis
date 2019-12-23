using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class TaxJurisAuthority
    {
        public int JurisdictionId { get; set; }
        public int TaxAuthId { get; set; }

        public virtual TaxJurisdiction Jurisdiction { get; set; }
        public virtual TaxAuthority TaxAuth { get; set; }
    }
}
