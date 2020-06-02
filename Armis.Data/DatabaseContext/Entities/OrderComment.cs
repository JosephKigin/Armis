using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class OrderComment
    {
        public int OrderId { get; set; }
        public string OrderComments { get; set; }
        public string InternalComments { get; set; }
        public string Raicomments { get; set; }
        public string CredAuthComments { get; set; }
        public string VoidComments { get; set; }
        public string JobHoldComments { get; set; }

        public virtual OrderHead Order { get; set; }
    }
}
