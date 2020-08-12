using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class DeptOperation
    {
        public DeptOperation()
        {
            OprLoadPrice = new HashSet<OprLoadPrice>();
            OprMaterialPrice = new HashSet<OprMaterialPrice>();
            OprThickPrice = new HashSet<OprThickPrice>();
        }

        public short DepartmentId { get; set; }
        public int OperationId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Operation Operation { get; set; }
        public virtual ICollection<OprLoadPrice> OprLoadPrice { get; set; }
        public virtual ICollection<OprMaterialPrice> OprMaterialPrice { get; set; }
        public virtual ICollection<OprThickPrice> OprThickPrice { get; set; }
    }
}
