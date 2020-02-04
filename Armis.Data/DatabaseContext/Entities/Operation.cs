using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Operation
    {
        public Operation()
        {
            DeptOperation = new HashSet<DeptOperation>();
            OprLoadPrice = new HashSet<OprLoadPrice>();
            OprMaterialPrice = new HashSet<OprMaterialPrice>();
            OprThickPrice = new HashSet<OprThickPrice>();
            ProcessStepSeq = new HashSet<ProcessStepSeq>();
        }

        public int OperationId { get; set; }
        public string OperationCd { get; set; }
        public string Name { get; set; }
        public int OperGroupId { get; set; }
        public short? DefaultDueDays { get; set; }
        public bool ThicknessIsRequired { get; set; }

        public virtual OperationGroup OperGroup { get; set; }
        public virtual ICollection<DeptOperation> DeptOperation { get; set; }
        public virtual ICollection<OprLoadPrice> OprLoadPrice { get; set; }
        public virtual ICollection<OprMaterialPrice> OprMaterialPrice { get; set; }
        public virtual ICollection<OprThickPrice> OprThickPrice { get; set; }
        public virtual ICollection<ProcessStepSeq> ProcessStepSeq { get; set; }
    }
}
