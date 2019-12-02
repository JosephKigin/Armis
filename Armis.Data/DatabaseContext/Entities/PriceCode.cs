using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class PriceCode
    {
        public PriceCode()
        {
            OrderDetail = new HashSet<OrderDetail>();
            PartHist = new HashSet<PartHist>();
        }

        public string PriceCd { get; set; }
        public string PriceCdDesc { get; set; }

        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<PartHist> PartHist { get; set; }
    }
}
