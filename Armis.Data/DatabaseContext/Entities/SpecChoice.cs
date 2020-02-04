using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class SpecChoice
    {
        public int SpecId { get; set; }
        public byte SublevelSeqId { get; set; }
        public byte ChoiceSeq { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; }

        public virtual SpecSubLevel S { get; set; }
    }
}
