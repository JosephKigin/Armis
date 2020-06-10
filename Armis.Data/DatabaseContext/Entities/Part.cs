﻿using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Part
    {
        public Part()
        {
            CustomerPart = new HashSet<CustomerPart>();
            OrderDetail = new HashSet<OrderDetail>();
            PartTran = new HashSet<PartTran>();
            SpecProcessAssignHist = new HashSet<SpecProcessAssignHist>();
        }

        public int PartId { get; set; }
        public string PartName { get; set; }
        public bool Inactive { get; set; }
        public string ExternalRev { get; set; }
        public string Description { get; set; }
        public string Dimensions { get; set; }
        public int? RackId { get; set; }
        public decimal? SurfaceArea { get; set; }
        public string SauoM { get; set; }
        public decimal? PieceWeight { get; set; }
        public short? StandardDept { get; set; }
        public string Bake { get; set; }
        public decimal? BasePrice { get; set; }
        public decimal? MinLotCharge { get; set; }
        public int? PartsPerLoad { get; set; }
        public int? MaskPcsPerHour { get; set; }
        public bool? NotifyWhenMasking { get; set; }
        public int? Alloy { get; set; }
        public int? SeriesId { get; set; }
        public int CreatedByEmp { get; set; }
        public DateTime DateCreated { get; set; }
        public TimeSpan TimeCreated { get; set; }

        public virtual MaterialAlloy AlloyNavigation { get; set; }
        public virtual Employee CreatedByEmpNavigation { get; set; }
        public virtual MaterialSeries Series { get; set; }
        public virtual Department StandardDeptNavigation { get; set; }
        public virtual PartComment PartComment { get; set; }
        public virtual ICollection<CustomerPart> CustomerPart { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<PartTran> PartTran { get; set; }
        public virtual ICollection<SpecProcessAssignHist> SpecProcessAssignHist { get; set; }
    }
}
