using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Step
    {
        public Step()
        {
            ProcessStepSeq = new HashSet<ProcessStepSeq>();
            SpecChoice = new HashSet<SpecChoice>();
        }

        public int StepId { get; set; }
        public short StepCategoryId { get; set; }
        public bool Inactive { get; set; }
        public string StepName { get; set; }
        public bool SignOffIsRequired { get; set; }
        public string Instructions { get; set; }

        public virtual StepCategory StepCategory { get; set; }
        public virtual ICollection<ProcessStepSeq> ProcessStepSeq { get; set; }
        public virtual ICollection<SpecChoice> SpecChoice { get; set; }
    }
}
