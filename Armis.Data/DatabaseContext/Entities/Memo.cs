using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Memo
    {
        public long MemoId { get; set; }
        public int? CustId { get; set; }
        public int? OrderId { get; set; }
        public string Comment { get; set; }
        public short? DepartmentId { get; set; }
        public bool? IsMemoRead { get; set; }
        public bool? IsComplete { get; set; }
        public string InteractionGroup { get; set; }
        public DateTime? InteractionDate { get; set; }
        public TimeSpan? InteractionTime { get; set; }
        public string InteractionMethod { get; set; }
        public int? ContactId { get; set; }
        public DateTime? FollowupDate { get; set; }
        public bool? IsFollowupDone { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Customer Cust { get; set; }
        public virtual Department Department { get; set; }
        public virtual OrderHead Order { get; set; }
    }
}
