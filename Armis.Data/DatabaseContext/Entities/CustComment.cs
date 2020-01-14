using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class CustComment
    {
        public int CustId { get; set; }
        public string Comments { get; set; }

        public virtual Customer Cust { get; set; }
    }
}
