using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class OprLoadPrice
    {
        public int OprLoadPriceId { get; set; }
        public int? OperationId { get; set; }
        public short? DepartmentId { get; set; }
        public string LoadType { get; set; }
        public int? CustId { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? Lbprice { get; set; }
        public decimal? MinLotCharge { get; set; }
        public decimal? MinPiecePrice { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual Department Department { get; set; }
        public virtual LoadType LoadTypeNavigation { get; set; }
        public virtual Operation Operation { get; set; }
    }
}
