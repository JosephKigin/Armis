using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class DeptOperation
    {
        public short DepartmentId { get; set; }
        public int OperationId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Operation Operation { get; set; }
    }
}
