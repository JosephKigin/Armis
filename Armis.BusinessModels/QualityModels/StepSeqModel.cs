using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.QualityModels
{
    public class StepSeqModel
    {
        public int StepId { get; set; }
        public StepModel Step { get; set; }
        public short Sequence { get; set; }
        public int ProcessId { get; set; }
        public int RevisionId { get; set; }
        public int OperationId { get; set; }
        public OperationModel Operation { get; set; }
    }
}
