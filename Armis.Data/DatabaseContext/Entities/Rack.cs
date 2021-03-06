﻿using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Rack
    {
        public Rack()
        {
            Part = new HashSet<Part>();
            ProcessLoad = new HashSet<ProcessLoad>();
            SpecProcessAssignHist = new HashSet<SpecProcessAssignHist>();
        }

        public int RackId { get; set; }
        public string Description { get; set; }
        public string Dimensions { get; set; }
        public int? MaterialAlloyId { get; set; }
        public short? AreaId { get; set; }
        public int? ExtensionQty { get; set; }
        public string Photo { get; set; }
        public string Notes { get; set; }

        public virtual Area Area { get; set; }
        public virtual MaterialAlloy MaterialAlloy { get; set; }
        public virtual ICollection<Part> Part { get; set; }
        public virtual ICollection<ProcessLoad> ProcessLoad { get; set; }
        public virtual ICollection<SpecProcessAssignHist> SpecProcessAssignHist { get; set; }
    }
}
