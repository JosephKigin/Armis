using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Hardness
    {
        public Hardness()
        {
            SpecProcessAssign = new HashSet<SpecProcessAssign>();
        }

        public int HardnessId { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public decimal? HardnessMin { get; set; }
        public decimal? HardnessMax { get; set; }

        public virtual ICollection<SpecProcessAssign> SpecProcessAssign { get; set; }
    }
}
