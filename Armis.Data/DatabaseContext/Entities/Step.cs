using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Step
    {
        public Step()
        {
            ProcessVarOverride = new HashSet<ProcessVarOverride>();
            StepVarList = new HashSet<StepVarList>();
            SubOpStepList = new HashSet<SubOpStepList>();
        }

        public int StepId { get; set; }
        public string StepCategoryCd { get; set; }
        public string Status { get; set; }
        public string StepName { get; set; }
        public bool? SignOffIsRequired { get; set; }
        public string Instructions { get; set; }

        public virtual Status StatusNavigation { get; set; }
        public virtual StepCategory StepCategoryCdNavigation { get; set; }
        public virtual ICollection<ProcessVarOverride> ProcessVarOverride { get; set; }
        public virtual ICollection<StepVarList> StepVarList { get; set; }
        public virtual ICollection<SubOpStepList> SubOpStepList { get; set; }
    }
}
