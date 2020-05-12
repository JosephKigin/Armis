using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class OrderLocation
    {
        public int OrderId { get; set; }
        public byte OrderLine { get; set; }
        public int LocationId { get; set; }
        public short? ContainerId { get; set; }

        public virtual Container Container { get; set; }
        public virtual ShopLocation Location { get; set; }
        public virtual OrderDetail Order { get; set; }
    }
}
