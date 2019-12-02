using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class DeptArea
    {
        public short AreaId { get; set; }
        public short DepartmentId { get; set; }

        public virtual Area Area { get; set; }
        public virtual Department Department { get; set; }
    }
}
