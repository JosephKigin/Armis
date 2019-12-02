using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Operation
    {
        public Operation()
        {
            DeptOperations = new HashSet<DeptOperations>();
            OprLoadPrice = new HashSet<OprLoadPrice>();
            OprMaterialPrice = new HashSet<OprMaterialPrice>();
            OprThickPrice = new HashSet<OprThickPrice>();
            ProcessSubOprList = new HashSet<ProcessSubOprList>();
        }

        public int OperationId { get; set; }
        public string OperationCd { get; set; }
        public string Name { get; set; }
        public string OperationGroupCd { get; set; }
        public int? DefaultDueDays { get; set; }
        public bool? ThicknessIsRequired { get; set; }
        public string Type { get; set; }

        public virtual OperationGroup OperationGroupCdNavigation { get; set; }
        public virtual ICollection<DeptOperations> DeptOperations { get; set; }
        public virtual ICollection<OprLoadPrice> OprLoadPrice { get; set; }
        public virtual ICollection<OprMaterialPrice> OprMaterialPrice { get; set; }
        public virtual ICollection<OprThickPrice> OprThickPrice { get; set; }
        public virtual ICollection<ProcessSubOprList> ProcessSubOprList { get; set; }
    }
}
