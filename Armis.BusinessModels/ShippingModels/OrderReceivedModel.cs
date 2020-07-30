using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.ShippingModels
{
    public class OrderReceivedModel
    {
        public int OrderId { get; set; }
        public short ReceivedNum { get; set; }
        public short ReceivedContainerId { get; set; }
        public int ReceivedContainerQty { get; set; }
        public DateTime ReceivedDate { get; set; }
        public TimeSpan ReceivedTime { get; set; }

        public ContainerModel ReceivedContainer { get; set; }
    }
}
