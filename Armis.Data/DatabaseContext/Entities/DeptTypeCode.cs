using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class DeptTypeCode
    {
        public DeptTypeCode()
        {
            Area = new HashSet<Area>();
            Department = new HashSet<Department>();
        }

        public byte DeptTypeId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Area> Area { get; set; }
        public virtual ICollection<Department> Department { get; set; }
    }
}
