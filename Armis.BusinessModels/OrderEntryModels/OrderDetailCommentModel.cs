using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.OrderEntryModels
{
    public class OrderDetailCommentModel
    {
        public int OrderId { get; set; }
        public byte OrderLine { get; set; }
        public string Comments1 { get; set; }
        public string Comments2 { get; set; }
        public string Comments3 { get; set; }
    }
}
