using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class SpecProcessAssign
    {
        public SpecProcessAssign()
        {
            OrderHead = new HashSet<OrderHead>();
            PartSpecProcessAssign = new HashSet<PartSpecProcessAssign>();
        }

        public int SpecId { get; set; }
        public short SpecRevId { get; set; }
        public short SpecAssignId { get; set; }
        public byte? SubLevelOption1 { get; set; }
        public byte? ChoiceOption1 { get; set; }
        public byte? SubLevelOption2 { get; set; }
        public byte? ChoiceOption2 { get; set; }
        public byte? SubLevelOption3 { get; set; }
        public byte? ChoiceOption3 { get; set; }
        public byte? SubLevelOption4 { get; set; }
        public byte? ChoiceOption4 { get; set; }
        public byte? SubLevelOption5 { get; set; }
        public byte? ChoiceOption5 { get; set; }
        public byte? SubLevelOption6 { get; set; }
        public byte? ChoiceOption6 { get; set; }
        public int? PreBakeOption { get; set; }
        public int? PostBakeOption { get; set; }
        public int? MaskOption { get; set; }
        public int? HardnessOption { get; set; }
        public int? SeriesOption { get; set; }
        public int? AlloyOption { get; set; }
        public int? Customer { get; set; }
        public int ProcessId { get; set; }
        public int ProcessRevId { get; set; }

        public virtual MaterialAlloy AlloyOptionNavigation { get; set; }
        public virtual Customer CustomerNavigation { get; set; }
        public virtual Hardness HardnessOptionNavigation { get; set; }
        public virtual Step MaskOptionNavigation { get; set; }
        public virtual Step PostBakeOptionNavigation { get; set; }
        public virtual Step PreBakeOptionNavigation { get; set; }
        public virtual ProcessRevision Process { get; set; }
        public virtual MaterialSeries SeriesOptionNavigation { get; set; }
        public virtual SpecificationRevision Spec { get; set; }
        public virtual SpecChoice SpecChoice { get; set; }
        public virtual SpecChoice SpecChoice1 { get; set; }
        public virtual SpecChoice SpecChoice2 { get; set; }
        public virtual SpecChoice SpecChoice3 { get; set; }
        public virtual SpecChoice SpecChoice4 { get; set; }
        public virtual SpecChoice SpecChoiceNavigation { get; set; }
        public virtual ICollection<OrderHead> OrderHead { get; set; }
        public virtual ICollection<PartSpecProcessAssign> PartSpecProcessAssign { get; set; }
    }
}
