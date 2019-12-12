using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class SubOpStepSeq
    {
        public int SubOpId { get; set; }
        public int SubOpRevId { get; set; }
        public short StepSeq { get; set; }
        public int StepId { get; set; }

        public virtual Step Step { get; set; }
        public virtual SubOpRevision SubOp { get; set; }
    }
}
