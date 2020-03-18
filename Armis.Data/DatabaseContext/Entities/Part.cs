﻿using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Part
    {
        public Part()
        {
            OrderDetail = new HashSet<OrderDetail>();
            PartProcessAssign = new HashSet<PartProcessAssign>();
            PartRevNavigation = new HashSet<PartRev>();
        }

        public int PartId { get; set; }
        public string CustPartNum { get; set; }
        public string Description { get; set; }
        public int CustId { get; set; }
        public bool? Inactive { get; set; }
        public int? SamplePlanId { get; set; }
        public int? CurrentRev { get; set; }
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
        public string ProcessComments { get; set; }

        public virtual MaterialAlloy AlloyNavigation { get; set; }
        public virtual Customer Cust { get; set; }
        public virtual PartRev PartRev { get; set; }
        public virtual SamplePlanHead SamplePlan { get; set; }
        public virtual MaterialSeries Series { get; set; }
        public virtual Department StandardDeptNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<PartProcessAssign> PartProcessAssign { get; set; }
        public virtual ICollection<PartRev> PartRevNavigation { get; set; }
    }
}
