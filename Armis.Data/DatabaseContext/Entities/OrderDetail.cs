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
        public int? Quantity { get; set; }
        public int PartId { get; set; }
        public short? PartRevId { get; set; }
        public decimal? Poprice { get; set; }
        public decimal? AssignedPrice { get; set; }
        public string PriceCd { get; set; }
        public string ProcessComments { get; set; }

        public virtual OrderHead Order { get; set; }
        public virtual Part Part { get; set; }
        public virtual PriceCode PriceCdNavigation { get; set; }
        public virtual ICollection<OrderLocation> OrderLocation { get; set; }
    }
}
