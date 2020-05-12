using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class SpecialHandling
    {
        public int OrderId { get; set; }
        public bool? SpecialPrintFlag { get; set; }
        public int? SpecialPrintByEmp { get; set; }
        public bool? FinalInspectionReq { get; set; }
        public bool? SupApprovalReq { get; set; }
        public int? HoldJobForEmp { get; set; }
        public int? NotifyEmp { get; set; }
        public DateTime? ReviewDate { get; set; }
        public int? ReviewReqByEmp { get; set; }
        public string Comments { get; set; }

        public virtual Employee HoldJobForEmpNavigation { get; set; }
        public virtual Employee NotifyEmpNavigation { get; set; }
        public virtual Employee ReviewReqByEmpNavigation { get; set; }
        public virtual Employee SpecialPrintByEmpNavigation { get; set; }
    }
}
