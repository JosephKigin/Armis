using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.QualityModels.Spec
{
    public class SpecProcessAssignOptionModel
    {
        public int SpecId { get; set; }
        public short SpecRevId { get; set; }
        public int SpecAssignId { get; set; }
        public byte SubLevelSeqId { get; set; }
        public byte ChoiceSeqId { get; set; }

        public SpecSubLevelChoiceModel SpecChoice { get; set; }
    }
}
