using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.ProcessModels.PassBackModels
{
    public class PassBackProcessRevStepSeqModel
    {
        public int ProcessId { get; set; }
        public int ProcessRevisionId { get; set; }
        public List<StepSeqModel> StepSeqList { get; set; }
    }
}
