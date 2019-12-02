using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class OprThickPrice
    {
        public int OprThickPriceId { get; set; }
        public int? OperationId { get; set; }
        public short? DepartmentId { get; set; }
        public decimal? MinThickness { get; set; }
        public int? CustId { get; set; }
        public decimal? PercInc { get; set; }
        public decimal? MinLotInc { get; set; }
        public decimal? MinPiecePriceInc { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual Department Department { get; set; }
        public virtual Operation Operation { get; set; }
    }
}
