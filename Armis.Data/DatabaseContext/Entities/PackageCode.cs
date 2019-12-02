using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class PackageCode
    {
        public PackageCode()
        {
            OrderHead = new HashSet<OrderHead>();
        }

        public string PackageCd { get; set; }
        public string Description { get; set; }

        public virtual ICollection<OrderHead> OrderHead { get; set; }
    }
}
