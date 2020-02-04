using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Step
    {
        public Step()
        {
            ProcessStepSeq = new HashSet<ProcessStepSeq>();
            StepVarSeq = new HashSet<StepVarSeq>();
        }

        public int StepId { get; set; }
        public string StepCategoryCd { get; set; }
        public bool Inactive { get; set; }
        public string StepName { get; set; }
        public bool SignOffIsRequired { get; set; }
        public string Instructions { get; set; }

        public virtual StepCategory StepCategoryCdNavigation { get; set; }
        public virtual ICollection<ProcessStepSeq> ProcessStepSeq { get; set; }
        public virtual ICollection<StepVarSeq> StepVarSeq { get; set; }
    }
}
