using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class CustContNotify
    {
        public int CustId { get; set; }
        public int ContactId { get; set; }
        public short NotifyEventId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Customer Cust { get; set; }
        public virtual NotifyEvent NotifyEvent { get; set; }
    }
}
