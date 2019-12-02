using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Hardness
    {
        public Hardness()
        {
            OrderHead = new HashSet<OrderHead>();
        }

        public string HardnessCd { get; set; }
        public string Description { get; set; }
        public decimal? HardnessMin { get; set; }
        public decimal? HardnessMax { get; set; }

        public virtual ICollection<OrderHead> OrderHead { get; set; }
    }
}
