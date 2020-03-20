﻿using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Part
    {
        public Part()
        {
            OrderDetail = new HashSet<OrderDetail>();
            PartSpecProcessAssign = new HashSet<PartSpecProcessAssign>();
        }

        public int PartId { get; set; }
        public short PartRevId { get; set; }
        public string PartName { get; set; }
        public string Description { get; set; }
        public bool Inactive { get; set; }
        public int? SamplePlanId { get; set; }
        public string ExternalRev { get; set; }
        public string Dimensions { get; set; }
        public string SurfaceArea { get; set; }
        public string SauoM { get; set; }
        public decimal? PieceWeight { get; set; }
        public short? StandardDept { get; set; }
        public string Bake { get; set; }
        public int? IntendedPpl { get; set; }
        public int? Alloy { get; set; }
        public int? SeriesId { get; set; }
        public decimal? Weight { get; set; }

        public virtual MaterialAlloy AlloyNavigation { get; set; }
        public virtual SamplePlanHead SamplePlan { get; set; }
        public virtual MaterialSeries Series { get; set; }
        public virtual Department StandardDeptNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<PartSpecProcessAssign> PartSpecProcessAssign { get; set; }
    }
}
