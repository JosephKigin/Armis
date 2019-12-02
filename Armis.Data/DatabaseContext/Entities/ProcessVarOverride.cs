using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class ProcessVarOverride
    {
        public int ProcessId { get; set; }
        public int ProcessRevId { get; set; }
        public int SubOpId { get; set; }
        public int SubOpRevId { get; set; }
        public int StepId { get; set; }
        public int StepVariableId { get; set; }
        public decimal OverrideMin { get; set; }
        public decimal OverrideMax { get; set; }

        public virtual ProcessRevision Process { get; set; }
        public virtual Step Step { get; set; }
        public virtual StepVariable StepVariable { get; set; }
        public virtual SubOpRevision SubOp { get; set; }
    }
}
