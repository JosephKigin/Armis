using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class ProcessStepSeq
    {
        public int ProcessId { get; set; }
        public int ProcessRevId { get; set; }
        public short StepSeq { get; set; }
        public int StepId { get; set; }
        public int OperationId { get; set; }
        public short OperationSeq { get; set; }

        public virtual Operation Operation { get; set; }
        public virtual ProcessRevision Process { get; set; }
        public virtual Step Step { get; set; }
    }
}
