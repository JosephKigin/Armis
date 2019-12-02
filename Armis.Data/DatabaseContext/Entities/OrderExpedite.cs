using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class OrderExpedite
    {
        public int OrderId { get; set; }
        public short ApprovedByEmp { get; set; }
        public bool? IsFree { get; set; }
        public bool? IsOnTime { get; set; }
        public bool? IsEmailOnly { get; set; }
        public decimal? FeeAmount { get; set; }
        public short? ExpeditedByEmp { get; set; }
        public DateTime? ExpeditedDate { get; set; }
        public int? ReworkOrder { get; set; }
        public short? DepartmentId { get; set; }

        public virtual Employee ApprovedByEmpNavigation { get; set; }
        public virtual Department Department { get; set; }
        public virtual Employee ExpeditedByEmpNavigation { get; set; }
        public virtual OrderHead Order { get; set; }
        public virtual OrderHead ReworkOrderNavigation { get; set; }
    }
}
