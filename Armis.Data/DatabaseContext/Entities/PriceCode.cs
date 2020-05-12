using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class PriceCode
    {
        public PriceCode()
        {
            OrderDetail = new HashSet<OrderDetail>();
            PartTran = new HashSet<PartTran>();
        }

        public byte PriceCodeId { get; set; }
        public string LongCode { get; set; }
        public string ShortCode { get; set; }
        public string Description { get; set; }

        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<PartTran> PartTran { get; set; }
    }
}
