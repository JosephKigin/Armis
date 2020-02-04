using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class OrderLocation
    {
        public int OrderId { get; set; }
        public byte OrderLine { get; set; }
        public string LocationCd { get; set; }
        public string ContainerCd { get; set; }

        public virtual Container ContainerCdNavigation { get; set; }
        public virtual Location LocationCdNavigation { get; set; }
        public virtual OrderDetail Order { get; set; }
    }
}
