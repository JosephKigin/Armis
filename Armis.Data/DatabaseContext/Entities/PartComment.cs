using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class PartComment
    {
        public int PartId { get; set; }
        public short PartRevId { get; set; }
        public string PartComments { get; set; }
        public string PriceComments { get; set; }
        public string ProcessComments { get; set; }
        public string MaskingInstructions { get; set; }
        public string PrintWithOrder { get; set; }

        public virtual PartRevision Part { get; set; }
    }
}
