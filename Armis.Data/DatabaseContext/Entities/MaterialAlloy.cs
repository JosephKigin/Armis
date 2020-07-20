using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class MaterialAlloy
    {
        public MaterialAlloy()
        {
            OprMaterialPrice = new HashSet<OprMaterialPrice>();
            Part = new HashSet<Part>();
            Rack = new HashSet<Rack>();
        }

        public int AlloyId { get; set; }
        public string Description { get; set; }
        public int? SeriesId { get; set; }

        public virtual MaterialSeries Series { get; set; }
        public virtual ICollection<OprMaterialPrice> OprMaterialPrice { get; set; }
        public virtual ICollection<Part> Part { get; set; }
        public virtual ICollection<Rack> Rack { get; set; }
    }
}
