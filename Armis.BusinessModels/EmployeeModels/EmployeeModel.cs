using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.EmployeeModels
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte? DefaultShift { get; set; }
        public bool IsInactive { get; set; }
        public bool IsPriceTraining { get; set; }
        public bool IsShippingLogin { get; set; }
        public string EMail { get; set; }
        public string PhoneNum { get; set; }
        public string ExtUserId { get; set; }
        public bool CanExpedite { get; set; }
        public short? AreaId { get; set; }
    }
}
