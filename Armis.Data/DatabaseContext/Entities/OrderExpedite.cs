using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class OrderExpedite
    {
        public int OrderId { get; set; }
        public int ApprovedByEmp { get; set; }
        public bool? IsFree { get; set; }
        public bool? IsOnTime { get; set; }
        public bool? IsEmailOnly { get; set; }
        public decimal? FeeAmount { get; set; }
        public int? ExpeditedByEmp { get; set; }
        public DateTime? ExpeditedDate { get; set; }

        public virtual Employee ApprovedByEmpNavigation { get; set; }
        public virtual Employee ExpeditedByEmpNavigation { get; set; }
        public virtual OrderHead Order { get; set; }
    }
}
