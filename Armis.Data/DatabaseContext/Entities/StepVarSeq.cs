using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class StepVarSeq
    {
        public int StepId { get; set; }
        public short VariableSeq { get; set; }
        public int StepVariableId { get; set; }

        public virtual Step Step { get; set; }
        public virtual StepVariable StepVariable { get; set; }
    }
}
