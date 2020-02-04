using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Priority
    {
        public Priority()
        {
            Customer = new HashSet<Customer>();
        }

        public byte PriorityId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
