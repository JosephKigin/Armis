using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class SpecProcessAssignOption
    {
        public int SpecId { get; set; }
        public short SpecRevId { get; set; }
        public int SpecAssignId { get; set; }
        public byte SubLevelSeqId { get; set; }
        public byte ChoiceSeqId { get; set; }

        public virtual SpecProcessAssign Spec { get; set; }
        public virtual SpecChoice SpecChoice { get; set; }
    }
}
