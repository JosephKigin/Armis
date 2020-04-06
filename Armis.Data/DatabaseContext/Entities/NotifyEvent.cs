using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class NotifyEvent
    {
        public NotifyEvent()
        {
            CustContNotify = new HashSet<CustContNotify>();
        }

        public short NotifyEventId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<CustContNotify> CustContNotify { get; set; }
    }
}
