using Armis.BusinessModels.QualityModels.Process;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.QualityModels.PassBackModels
{
    public class PassBackProcessRevStepSeqModel
    {
        public int ProcessId { get; set; }
        public int ProcessRevisionId { get; set; }
        public List<StepSeqModel> StepSeqList { get; set; }
    }
}
