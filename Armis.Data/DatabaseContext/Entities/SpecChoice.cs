using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class SpecChoice
    {
        public SpecChoice()
        {
            InverseSpecChoiceNavigation = new HashSet<SpecChoice>();
            SpecProcessAssignOption = new HashSet<SpecProcessAssignOption>();
            SpecSubLevel = new HashSet<SpecSubLevel>();
        }

        public int SpecId { get; set; }
        public short SpecRevId { get; set; }
        public byte SubLevelSeqId { get; set; }
        public byte ChoiceSeqId { get; set; }
        public string Description { get; set; }
        public int? ReferenceStepId { get; set; }
        public byte? DependentLevel { get; set; }
        public byte? OnlyValidForChoice { get; set; }

        public virtual Step ReferenceStep { get; set; }
        public virtual SpecSubLevel S { get; set; }
        public virtual SpecChoice SpecChoiceNavigation { get; set; }
        public virtual ICollection<SpecChoice> InverseSpecChoiceNavigation { get; set; }
        public virtual ICollection<SpecProcessAssignOption> SpecProcessAssignOption { get; set; }
        public virtual ICollection<SpecSubLevel> SpecSubLevel { get; set; }
    }
}
