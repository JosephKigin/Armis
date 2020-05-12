using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Container
    {
        public Container()
        {
            OrderHead = new HashSet<OrderHead>();
            OrderLocation = new HashSet<OrderLocation>();
        }

        public short ContainerId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<OrderHead> OrderHead { get; set; }
        public virtual ICollection<OrderLocation> OrderLocation { get; set; }
    }
}
