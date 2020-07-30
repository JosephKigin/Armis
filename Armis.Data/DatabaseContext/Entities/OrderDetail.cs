using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class OrderDetail
    {
        public OrderDetail()
        {
            OrderLocation = new HashSet<OrderLocation>();
        }

        public int OrderId { get; set; }
        public byte OrderLine { get; set; }
        public int Quantity { get; set; }
        public int? PartId { get; set; }
        public string Description { get; set; }
        public decimal Poprice { get; set; }
        public decimal CalcPrice { get; set; }
        public decimal AssignPrice { get; set; }
        public byte PriceCodeId { get; set; }
        public decimal LotCharge { get; set; }

        public virtual OrderHead Order { get; set; }
        public virtual Part Part { get; set; }
        public virtual PriceCode PriceCode { get; set; }
        public virtual OrderDetailComment OrderDetailComment { get; set; }
        public virtual ICollection<OrderLocation> OrderLocation { get; set; }
    }
}
