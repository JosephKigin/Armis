using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class PlateResult
    {
        public long PlateResultId { get; set; }
        public int? OrderId { get; set; }
        public string Status { get; set; }
        public DateTime? RunDate { get; set; }
        public short? AreaId { get; set; }
        public short? DepartmentId { get; set; }
        public byte? Shift { get; set; }
        public short? Employee { get; set; }
        public bool? IsCompleted { get; set; }
        public string LoadType { get; set; }
        public byte? GoodLoads { get; set; }
        public byte? ReworkLoads { get; set; }
        public int? PartsPerLoad { get; set; }
        public bool? IsHelper { get; set; }
        public string Comments { get; set; }

        public virtual Area Area { get; set; }
        public virtual Department Department { get; set; }
        public virtual Employee EmployeeNavigation { get; set; }
        public virtual LoadType LoadTypeNavigation { get; set; }
        public virtual OrderHead Order { get; set; }
        public virtual Status StatusNavigation { get; set; }
    }
}
