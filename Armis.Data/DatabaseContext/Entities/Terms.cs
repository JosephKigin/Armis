using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Terms
    {
        public Terms()
        {
            Customer = new HashSet<Customer>();
        }

        public string TermsCd { get; set; }
        public string Description { get; set; }
        public int? DueDays { get; set; }
        public int? PastDueNoticeDays { get; set; }
        public int? StatementDays { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
