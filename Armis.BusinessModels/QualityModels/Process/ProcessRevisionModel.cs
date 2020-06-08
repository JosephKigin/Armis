using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.QualityModels.Process
{
    public class ProcessRevisionModel
    {
        public int ProcessId { get; set; }
        public int ProcessRevId { get; set; }
        public int CreatedByEmp { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public byte RevStatusId { get; set; }
        public string Comments { get; set; }

        public IEnumerable<StepSeqModel> StepSeqs { get; set; }
    }
}
