﻿using Armis.BusinessModels.EmployeeModels;
using Armis.BusinessModels.ShopFloorModels.Department;
using Armis.BusinessModels.ShopFloorModels.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.PartModels
{
    public class PartModel
    {
        public int PartId { get; set; }
        public string PartName { get; set; }
        public bool Inactive { get; set; }
        public string ExternalRev { get; set; }
        public string Description { get; set; }
        public string Dimensions { get; set; }
        public int? RackId { get; set; }
        public decimal? SurfaceArea { get; set; }
        public int? SurfaceAreaUoMId { get; set; }
        public decimal? PieceWeight { get; set; }
        public short? StandardDeptId { get; set; }
        public string Bake { get; set; }
        public decimal? BasePrice { get; set; }
        public decimal? MinLotCharge { get; set; }
        public int? PartsPerLoad { get; set; }
        public decimal? MaskPcsPerHour { get; set; }
        public bool? NotifyWhenMasking { get; set; }
        public int? MaterialAlloyId { get; set; }
        public int? MaterialSeriesId { get; set; }
        public int CreatedByEmpId { get; set; }
        public DateTime? DateCreated { get; set; } //Needs to be null so a model can be passed in to post with a null datetime to be filled in the service
        public TimeSpan? TimeCreated { get; set; } //See comment above

        public RackModel Rack { get; set; }
        public UnitOfMeasureModel SurfaceAreaUnitOfMeasure { get; set; }
        public MaterialAlloyModel Alloy { get; set; }
        public EmployeeModel CreatedByEmp { get; set; }
        public MaterialSeriesModel Series { get; set; }
        public DepartmentModel StandardDept { get; set; }
        //public virtual PartComment PartComment { get; set; } TODO: Implement this!
    }
}
