using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class PriceStatusCode
    {
        public PriceStatusCode()
        {
            OrderHead = new HashSet<OrderHead>();
        }

        public byte PriceStatusId { get; set; }
        public string Code { get; set; }

        public virtual ICollection<OrderHead> OrderHead { get; set; }
    }
}
