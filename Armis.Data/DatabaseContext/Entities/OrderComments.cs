using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class OrderComments
    {
        public int OrderId { get; set; }
        public string OrderComments1 { get; set; }
        public string Raicomments { get; set; }
        public string CredAuthComments { get; set; }
        public string VoidComments { get; set; }
        public string JobHoldComments { get; set; }

        public virtual OrderHead Order { get; set; }
    }
}
