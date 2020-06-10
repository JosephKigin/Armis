using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.OrderEntryModels
{
    public class OrderCommentModel
    {
        public int OrderId { get; set; }
        public string OrderComments { get; set; }
        public string InternalComments { get; set; }
        public string Raicomments { get; set; } // Return As Is Comments
        public string CredAuthComments { get; set; }
        public string VoidComments { get; set; }
        public string JobHoldComments { get; set; }
    }
}
