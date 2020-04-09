using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class MaterialAlloy
    {
        public MaterialAlloy()
        {
            OprMaterialPrice = new HashSet<OprMaterialPrice>();
            PartRevision = new HashSet<PartRevision>();
            Rack = new HashSet<Rack>();
            SpecProcessAssign = new HashSet<SpecProcessAssign>();
        }

        public int AlloyId { get; set; }
        public string Description { get; set; }
        public int? SeriesId { get; set; }

        public virtual MaterialSeries Series { get; set; }
        public virtual ICollection<OprMaterialPrice> OprMaterialPrice { get; set; }
        public virtual ICollection<PartRevision> PartRevision { get; set; }
        public virtual ICollection<Rack> Rack { get; set; }
        public virtual ICollection<SpecProcessAssign> SpecProcessAssign { get; set; }
    }
}
