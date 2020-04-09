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

        public short PriceCodeId { get; set; }
        public string PriceCode1 { get; set; }
        public string PriceCodeDesc { get; set; }

        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<PartTran> PartTran { get; set; }
    }
}
