﻿using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class MaterialAlloy
    {
        public MaterialAlloy()
        {
            OprMaterialPrice = new HashSet<OprMaterialPrice>();
            OrderHead = new HashSet<OrderHead>();
            Part = new HashSet<Part>();
            Rack = new HashSet<Rack>();
        }

        public string AlloyCd { get; set; }
        public string Description { get; set; }
        public string SeriesCd { get; set; }

        public virtual MaterialSeries SeriesCdNavigation { get; set; }
        public virtual ICollection<OprMaterialPrice> OprMaterialPrice { get; set; }
        public virtual ICollection<OrderHead> OrderHead { get; set; }
        public virtual ICollection<Part> Part { get; set; }
        public virtual ICollection<Rack> Rack { get; set; }
    }
}
