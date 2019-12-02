using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Container
    {
        public Container()
        {
            OrderLocation = new HashSet<OrderLocation>();
        }

        public string ContainerCd { get; set; }
        public string Description { get; set; }

        public virtual ICollection<OrderLocation> OrderLocation { get; set; }
    }
}
