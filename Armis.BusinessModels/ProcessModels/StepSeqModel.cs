using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.ProcessModels
{
    public class StepSeqModel
    {
        public int StepId { get; set; }
        public short Sequence { get; set; }
        public int ProcessId { get; set; }
        public int RevisionId { get; set; }
        public int MyProperty { get; set; }
        public int OperationId { get; set; }
    }
}
