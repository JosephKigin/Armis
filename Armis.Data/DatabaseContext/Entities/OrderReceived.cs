using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class OrderReceived
    {
        public int OrderId { get; set; }
        public short ReceivedNum { get; set; }
        public short ReceivedContainerId { get; set; }
        public int ReceivedContainerQty { get; set; }
        public DateTime ReceivedDate { get; set; }
        public TimeSpan ReceivedTime { get; set; }

        public virtual OrderHead Order { get; set; }
        public virtual Container ReceivedContainer { get; set; }
    }
}
