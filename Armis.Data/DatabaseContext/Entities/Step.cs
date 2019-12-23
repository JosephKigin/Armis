using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Step
    {
        public Step()
        {
            ProcessVarOverride = new HashSet<ProcessVarOverride>();
            StepVarSeq = new HashSet<StepVarSeq>();
            SubOpStepSeq = new HashSet<SubOpStepSeq>();
        }

        public int StepId { get; set; }
        public string StepCategoryCd { get; set; }
        public bool Inactive { get; set; }
        public string StepName { get; set; }
        public bool? SignOffIsRequired { get; set; }
        public string Instructions { get; set; }

        public virtual StepCategory StepCategoryCdNavigation { get; set; }
        public virtual ICollection<ProcessVarOverride> ProcessVarOverride { get; set; }
        public virtual ICollection<StepVarSeq> StepVarSeq { get; set; }
        public virtual ICollection<SubOpStepSeq> SubOpStepSeq { get; set; }
    }
}
