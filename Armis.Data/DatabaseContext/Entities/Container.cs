using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Container
    {
        public Container()
        {
            OrderLocation = new HashSet<OrderLocation>();
            OrderReceived = new HashSet<OrderReceived>();
        }

        public short ContainerId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<OrderLocation> OrderLocation { get; set; }
        public virtual ICollection<OrderReceived> OrderReceived { get; set; }
    }
}
