using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class CustomerStatus
    {
        public CustomerStatus()
        {
            Customer = new HashSet<Customer>();
        }

        public byte StatusId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
