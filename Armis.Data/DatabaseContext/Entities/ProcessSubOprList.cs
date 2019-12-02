using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class ProcessSubOprList
    {
        public int ProcessId { get; set; }
        public int ProcessRevId { get; set; }
        public short SubOpSeq { get; set; }
        public int SubOpId { get; set; }
        public int SubOpRevId { get; set; }
        public short OperationSeq { get; set; }
        public int OperationId { get; set; }

        public virtual Operation Operation { get; set; }
        public virtual ProcessRevision Process { get; set; }
        public virtual SubOpRevision SubOp { get; set; }
    }
}
