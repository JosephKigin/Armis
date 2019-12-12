using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.ProcessModels
{
    public class SubOpRevisionModel
    {
        public int SubOpId { get; set; }
        public int SubOpRevId { get; set; }
        public short CreatedByEmp { get; set; }
        public DateTime DateCreated { get; set; }
        public TimeSpan TimeCreated { get; set; }
        public string Comments { get; set; }
        public string RevStatusCd { get; set; }
        public int Sequence { get; set; }
        public IEnumerable<StepModel> Steps { get; set; }
    }
}
