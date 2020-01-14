using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Status
    {
        public Status()
        {
            BakeResult = new HashSet<BakeResult>();
            Customer = new HashSet<Customer>();
            OrderHead = new HashSet<OrderHead>();
            PlateResult = new HashSet<PlateResult>();
            Session = new HashSet<Session>();
        }

        public string StatusCd { get; set; }
        public string Description { get; set; }

        public virtual ICollection<BakeResult> BakeResult { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<OrderHead> OrderHead { get; set; }
        public virtual ICollection<PlateResult> PlateResult { get; set; }
        public virtual ICollection<Session> Session { get; set; }
    }
}
