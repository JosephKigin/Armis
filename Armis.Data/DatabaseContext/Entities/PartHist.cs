using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class PartHist
    {
        public long TranSeqNum { get; set; }
        public string TranType { get; set; }
        public int? OrderId { get; set; }
        public int? QuoteNum { get; set; }
        public DateTime? Date { get; set; }
        public int? TranQty { get; set; }
        public int? ProcessId { get; set; }
        public decimal? PiecePrice { get; set; }
        public string PriceCd { get; set; }
        public string LegacyProcess { get; set; }
        public DateTime SysDate { get; set; }
        public TimeSpan SysTime { get; set; }

        public virtual OrderHead Order { get; set; }
        public virtual PriceCode PriceCdNavigation { get; set; }
        public virtual Process Process { get; set; }
    }
}
