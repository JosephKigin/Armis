using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Driver
    {
        public int DriverId { get; set; }
        public string Name { get; set; }
        public int CustId { get; set; }
        public bool? Inactive { get; set; }
        public DateTime? AssignedDate { get; set; }

        public virtual Customer Cust { get; set; }
    }
}
