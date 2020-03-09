using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class SpecChoice
    {
        public SpecChoice()
        {
            SpecProcessAssignSpecChoice = new HashSet<SpecProcessAssign>();
            SpecProcessAssignSpecChoice1 = new HashSet<SpecProcessAssign>();
            SpecProcessAssignSpecChoice2 = new HashSet<SpecProcessAssign>();
            SpecProcessAssignSpecChoice3 = new HashSet<SpecProcessAssign>();
            SpecProcessAssignSpecChoice4 = new HashSet<SpecProcessAssign>();
            SpecProcessAssignSpecChoiceNavigation = new HashSet<SpecProcessAssign>();
        }

        public int SpecId { get; set; }
        public short SpecRevId { get; set; }
        public byte SubLevelSeqId { get; set; }
        public byte ChoiceSeqId { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; }

        public virtual SpecSubLevel S { get; set; }
        public virtual ICollection<SpecProcessAssign> SpecProcessAssignSpecChoice { get; set; }
        public virtual ICollection<SpecProcessAssign> SpecProcessAssignSpecChoice1 { get; set; }
        public virtual ICollection<SpecProcessAssign> SpecProcessAssignSpecChoice2 { get; set; }
        public virtual ICollection<SpecProcessAssign> SpecProcessAssignSpecChoice3 { get; set; }
        public virtual ICollection<SpecProcessAssign> SpecProcessAssignSpecChoice4 { get; set; }
        public virtual ICollection<SpecProcessAssign> SpecProcessAssignSpecChoiceNavigation { get; set; }
    }
}
