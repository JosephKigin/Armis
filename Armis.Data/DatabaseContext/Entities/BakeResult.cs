using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class BakeResult
    {
        public int BakeResultId { get; set; }
        public int? OrderId { get; set; }
        public string Status { get; set; }
        public DateTime? StartDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public short? StartedByEmp { get; set; }
        public DateTime? StopDate { get; set; }
        public TimeSpan? StopTime { get; set; }
        public short? StoppedByEmp { get; set; }
        public decimal? OvenTemp { get; set; }
        public string OvenName { get; set; }
        public int? QtyBaked { get; set; }
        public TimeSpan? PlatedTime { get; set; }
        public string Comments { get; set; }

        public virtual OrderHead Order { get; set; }
        public virtual Oven OvenNameNavigation { get; set; }
        public virtual Employee StartedByEmpNavigation { get; set; }
        public virtual Status StatusNavigation { get; set; }
        public virtual Employee StoppedByEmpNavigation { get; set; }
    }
}
