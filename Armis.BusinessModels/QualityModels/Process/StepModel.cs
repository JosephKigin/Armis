using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.QualityModels.Process
{
    public class StepModel
    {
        public int StepId { get; set; }
        public bool Inactive { get; set; }
        public string StepName { get; set; }
        public bool SignOffIsRequired { get; set; }
        public string Instructions { get; set; }
        public StepCategoryModel StepCategory { get; set; }
    }
}