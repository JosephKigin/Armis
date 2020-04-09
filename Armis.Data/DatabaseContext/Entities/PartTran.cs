using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class PartTran
    {
        public int PartId { get; set; }
        public short PartRevId { get; set; }
        public int TranSeqNum { get; set; }
        public short TranTypeId { get; set; }
        public int OrderId { get; set; }
        public int? QuoteNum { get; set; }
        public DateTime? Date { get; set; }
        public int? TranQty { get; set; }
        public int ProcessId { get; set; }
        public int ProcessRevId { get; set; }
        public decimal? PiecePrice { get; set; }
        public short? PriceCodeId { get; set; }
        public string LegacyProcess { get; set; }
        public int? FromLocation { get; set; }
        public int? ToLocation { get; set; }
        public DateTime SysDate { get; set; }
        public TimeSpan SysTime { get; set; }

        public virtual ShopLocation FromLocationNavigation { get; set; }
        public virtual OrderHead Order { get; set; }
        public virtual PartRevision Part { get; set; }
        public virtual PriceCode PriceCode { get; set; }
        public virtual ProcessRevision Process { get; set; }
        public virtual ShopLocation ToLocationNavigation { get; set; }
        public virtual TranType TranType { get; set; }
    }
}
