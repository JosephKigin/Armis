using Armis.BusinessModels.QualityModels.Process;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.QualityModels.Spec
{
    public class SpecSubLevelChoiceModel
    {
        public string Description { get; set; }
        public byte SubLevelSeqId { get; set; }
        public byte ChoiceSeqId { get; set; }
        public int? ReferenceStepId { get; set; }
        public byte? DependentSubLevelId { get; set; }
        public byte? OnlyValidForChoiceId { get; set; }

        public StepModel ReferenceStep { get; set; }
    }
}
