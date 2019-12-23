using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class StepVarTemplate
    {
        public StepVarTemplate()
        {
            StepVarOption = new HashSet<StepVarOption>();
            StepVariable = new HashSet<StepVariable>();
        }

        public string VarTempCd { get; set; }
        public string VarName { get; set; }
        public string StepVarTypeCd { get; set; }

        public virtual StepVarType StepVarTypeCdNavigation { get; set; }
        public virtual ICollection<StepVarOption> StepVarOption { get; set; }
        public virtual ICollection<StepVariable> StepVariable { get; set; }
    }
}
