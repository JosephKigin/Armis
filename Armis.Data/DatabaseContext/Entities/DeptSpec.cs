using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class DeptSpec
    {
        public short DepartmentId { get; set; }
        public int SpecId { get; set; }
        public short SpecRevId { get; set; }
        public short ListPrioritySeq { get; set; }

        public virtual Department Department { get; set; }
        public virtual Specification Spec { get; set; }
    }
}
