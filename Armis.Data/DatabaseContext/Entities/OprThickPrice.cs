using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class OprThickPrice
    {
        public int OperationId { get; set; }
        public short DepartmentId { get; set; }
        public decimal CustSeq { get; set; }
        public int? CustId { get; set; }
        public decimal? MinThickness { get; set; }
        public decimal? MaxThickness { get; set; }
        public decimal PercentIncrease { get; set; }
        public decimal MinLotIncrease { get; set; }
        public decimal MinPiecePriceInc { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual DeptOperation DeptOperation { get; set; }
    }
}
