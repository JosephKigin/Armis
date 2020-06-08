using Armis.BusinessModels.ShopFloorModels.Line;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.ShopFloorModels.Department
{
    public class DepartmentModel
    {
        public short DepartmentId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public bool IsShownOnShopList { get; set; }
        public decimal PlaterBurRate { get; set; }
        public decimal HelperBurRate { get; set; }
        public decimal ReworkBurRate { get; set; }
        public short? ScheduleAreaId { get; set; }
        public decimal? LeadTime { get; set; }

        public DepartmentTypeCodeModel DepartmentTypeCode { get; set; }
        public LoadTypeCodeModel LoadTypeCode { get; set; }
        //public AreaModel ScheduleArea { get; set; }
    }
}
