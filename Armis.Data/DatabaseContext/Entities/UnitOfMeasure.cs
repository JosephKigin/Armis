using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class UnitOfMeasure
    {
        public UnitOfMeasure()
        {
            OprLoadPrice = new HashSet<OprLoadPrice>();
            Part = new HashSet<Part>();
        }

        public int UoMid { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }

        public virtual ICollection<OprLoadPrice> OprLoadPrice { get; set; }
        public virtual ICollection<Part> Part { get; set; }
    }
}
