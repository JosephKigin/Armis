using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class SpecSubLevel
    {
        public SpecSubLevel()
        {
            SpecChoice = new HashSet<SpecChoice>();
        }

        public int SpecId { get; set; }
        public short SpecRevId { get; set; }
        public byte SubLevelSeqId { get; set; }
        public string Name { get; set; }
        public bool IsRequired { get; set; }
        public byte? DefaultChoice { get; set; }

        public virtual SpecificationRevision Spec { get; set; }
        public virtual SpecChoice SpecChoiceNavigation { get; set; }
        public virtual ICollection<SpecChoice> SpecChoice { get; set; }
    }
}
