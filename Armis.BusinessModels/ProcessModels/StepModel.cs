using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.ProcessModels
{
    public class StepModel
    {
        public int StepId { get; set; }
        public string StepCategoryCd { get; set; }
        public bool Inactive { get; set; }
        public string StepName { get; set; }
        public bool SignOffIsRequired { get; set; }
        public string Instructions { get; set; }
        public int Sequence { get; set; } 
        public OperationModel Operation { get; set; } //This will have a value only if the step is applied to a process.
        public IEnumerable<StepVariableModel> Variables { get; set; }
    }
}