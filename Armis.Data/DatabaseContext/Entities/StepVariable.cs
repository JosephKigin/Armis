using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class StepVariable
    {
        public StepVariable()
        {
            ProcessVarOverride = new HashSet<ProcessVarOverride>();
            StepVarList = new HashSet<StepVarList>();
        }

        public int StepVariableId { get; set; }
        public string VariableCode { get; set; }
        public string StepVarName { get; set; }
        public string Uomcd { get; set; }
        public decimal DefaultMin { get; set; }
        public decimal DefaultMax { get; set; }

        public virtual Uomcode UomcdNavigation { get; set; }
        public virtual ICollection<ProcessVarOverride> ProcessVarOverride { get; set; }
        public virtual ICollection<StepVarList> StepVarList { get; set; }
    }
}
