using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class PartRevision
    {
        public PartRevision()
        {
            CustomerPart = new HashSet<CustomerPart>();
            OrderDetail = new HashSet<OrderDetail>();
            PartSpecProcessAssign = new HashSet<PartSpecProcessAssign>();
            PartTran = new HashSet<PartTran>();
        }

        public int PartId { get; set; }
        public short PartRevId { get; set; }
        public string Description { get; set; }
        public string ExternalRev { get; set; }
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
        public short CreatedByEmp { get; set; }
        public DateTime DateModified { get; set; }
        public TimeSpan TimeModified { get; set; }

        public virtual MaterialAlloy AlloyNavigation { get; set; }
        public virtual Employee CreatedByEmpNavigation { get; set; }
        public virtual Part Part { get; set; }
        public virtual MaterialSeries Series { get; set; }
        public virtual Department StandardDeptNavigation { get; set; }
        public virtual PartComment PartComment { get; set; }
        public virtual ICollection<CustomerPart> CustomerPart { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<PartSpecProcessAssign> PartSpecProcessAssign { get; set; }
        public virtual ICollection<PartTran> PartTran { get; set; }
    }
}
