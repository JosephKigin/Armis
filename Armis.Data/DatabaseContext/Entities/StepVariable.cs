using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class StepVariable
    {
        public StepVariable()
        {
            ProcessVarOverride = new HashSet<ProcessVarOverride>();
            StepVarSeq = new HashSet<StepVarSeq>();
        }

        public int StepVariableId { get; set; }
        public int? VarTemplateId { get; set; }
        public string Uomcd { get; set; }
        public decimal? DefaultMin { get; set; }
        public decimal? DefaultMax { get; set; }

        public virtual Uomcode UomcdNavigation { get; set; }
        public virtual StepVarTemplate VarTemplate { get; set; }
        public virtual ICollection<ProcessVarOverride> ProcessVarOverride { get; set; }
        public virtual ICollection<StepVarSeq> StepVarSeq { get; set; }
    }
}
