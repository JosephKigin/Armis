using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class NotifyEvent
    {
        public NotifyEvent()
        {
            NotifyContact = new HashSet<NotifyContact>();
        }

        public short NotifyEventId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<NotifyContact> NotifyContact { get; set; }
    }
}
