using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class MaterialSeries
    {
        public MaterialSeries()
        {
            MaterialAlloy = new HashSet<MaterialAlloy>();
            Part = new HashSet<Part>();
            SpecProcessAssign = new HashSet<SpecProcessAssign>();
        }

        public int SeriesId { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public virtual ICollection<MaterialAlloy> MaterialAlloy { get; set; }
        public virtual ICollection<Part> Part { get; set; }
        public virtual ICollection<SpecProcessAssign> SpecProcessAssign { get; set; }
    }
}
