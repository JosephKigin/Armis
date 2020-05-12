using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class BakeResult
    {
        public int BakeResultId { get; set; }
        public int? OrderId { get; set; }
        public DateTime? StartDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public int? StartedByEmp { get; set; }
        public DateTime? StopDate { get; set; }
        public TimeSpan? StopTime { get; set; }
        public int? StoppedByEmp { get; set; }
        public decimal? OvenTemp { get; set; }
        public short? OvenId { get; set; }
        public int? QtyBaked { get; set; }
        public TimeSpan? PlatedTime { get; set; }
        public string Comments { get; set; }

        public virtual OrderHead Order { get; set; }
        public virtual Oven Oven { get; set; }
        public virtual Employee StartedByEmpNavigation { get; set; }
        public virtual Employee StoppedByEmpNavigation { get; set; }
    }
}
