using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Status
    {
        public Status()
        {
            BakeResult = new HashSet<BakeResult>();
            CustomerCreditStatusNavigation = new HashSet<Customer>();
            CustomerStatusNavigation = new HashSet<Customer>();
            OrderHead = new HashSet<OrderHead>();
            PlateResult = new HashSet<PlateResult>();
            ProcessRevision = new HashSet<ProcessRevision>();
            Session = new HashSet<Session>();
            ShipTo = new HashSet<ShipTo>();
            Step = new HashSet<Step>();
            SubOpRevision = new HashSet<SubOpRevision>();
        }

        public string StatusCd { get; set; }
        public string StatusType { get; set; }
        public string Description { get; set; }

        public virtual ICollection<BakeResult> BakeResult { get; set; }
        public virtual ICollection<Customer> CustomerCreditStatusNavigation { get; set; }
        public virtual ICollection<Customer> CustomerStatusNavigation { get; set; }
        public virtual ICollection<OrderHead> OrderHead { get; set; }
        public virtual ICollection<PlateResult> PlateResult { get; set; }
        public virtual ICollection<ProcessRevision> ProcessRevision { get; set; }
        public virtual ICollection<Session> Session { get; set; }
        public virtual ICollection<ShipTo> ShipTo { get; set; }
        public virtual ICollection<Step> Step { get; set; }
        public virtual ICollection<SubOpRevision> SubOpRevision { get; set; }
    }
}
