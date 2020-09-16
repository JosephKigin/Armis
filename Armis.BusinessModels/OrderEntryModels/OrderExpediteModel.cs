using Armis.BusinessModels.EmployeeModels;
using Armis.BusinessModels.ShopFloorModels.Department;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.OrderEntryModels
{
    public class OrderExpediteModel
    {
        public int OrderId { get; set; }
        public bool? IsFree { get; set; }
        public bool? IsOnTime { get; set; }
        public bool? IsEmailOnly { get; set; }
        public decimal? FeeAmount { get; set; }
        public int? ExpeditedByEmp { get; set; }
        public DateTime? ExpeditedDate { get; set; }

        public EmployeeModel ApprovedByEmployee { get; set; }
        public DepartmentModel Department { get; set; }
        public EmployeeModel ExpeditedByEmployee { get; set; }

    }
}
