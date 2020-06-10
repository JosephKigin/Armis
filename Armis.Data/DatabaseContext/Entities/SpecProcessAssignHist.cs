using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class SpecProcessAssignHist
    {
        public int PartId { get; set; }
        public int SpecId { get; set; }
        public short SpecRevId { get; set; }
        public int SpecAssignId { get; set; }
        public DateTime? LastUsedDate { get; set; }
        public bool Inactive { get; set; }
        public int? RackId { get; set; }
        public string DocumentToPrint { get; set; }
        public int? MaskPiecesPerHour { get; set; }
        public bool NotifyPricingOfMask { get; set; }
        public string ProcessComments { get; set; }
        public string MaskingInstructions { get; set; }
        public string PriceComments { get; set; }

        public virtual Part Part { get; set; }
        public virtual Rack Rack { get; set; }
        public virtual SpecProcessAssign Spec { get; set; }
    }
}
