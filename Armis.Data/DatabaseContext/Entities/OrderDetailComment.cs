using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class OrderDetailComment
    {
        public int OrderId { get; set; }
        public byte OrderLine { get; set; }
        public string Comments1 { get; set; }
        public string Comments2 { get; set; }
        public string Comments3 { get; set; }

        public virtual OrderHead Order { get; set; }
        public virtual OrderDetail OrderNavigation { get; set; }
    }
}
