﻿using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class PlateResult
    {
        public int PlateResultId { get; set; }
        public int? OrderId { get; set; }
        public DateTime? RunDate { get; set; }
        public short? AreaId { get; set; }
        public short? DepartmentId { get; set; }
        public byte? Shift { get; set; }
        public int? Employee { get; set; }
        public bool? IsCompleted { get; set; }
        public byte? LoadTypeId { get; set; }
        public byte? GoodLoads { get; set; }
        public byte? ReworkLoads { get; set; }
        public int? PartsPerLoad { get; set; }
        public bool? IsHelper { get; set; }
        public string Comments { get; set; }

        public virtual Area Area { get; set; }
        public virtual Department Department { get; set; }
        public virtual Employee EmployeeNavigation { get; set; }
        public virtual LoadTypeCode LoadType { get; set; }
        public virtual OrderHead Order { get; set; }
    }
}
