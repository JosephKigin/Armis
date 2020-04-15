using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.QualityModels.Spec
{
    public class SpecProcessAssignModel
    {
        public int SpecId { get; set; }
        public short SpecRevId { get; set; }
        public short SpecAssignId { get; set; }
        public byte? SubLevelOption1 { get; set; }
        public byte? ChoiceOption1 { get; set; }
        public byte? SubLevelOption2 { get; set; }
        public byte? ChoiceOption2 { get; set; }
        public byte? SubLevelOption3 { get; set; }
        public byte? ChoiceOption3 { get; set; }
        public byte? SubLevelOption4 { get; set; }
        public byte? ChoiceOption4 { get; set; }
        public byte? SubLevelOption5 { get; set; }
        public byte? ChoiceOption5 { get; set; }
        public byte? SubLevelOption6 { get; set; }
        public byte? ChoiceOption6 { get; set; }
        public int? PreBakeOption { get; set; }
        public int? PostBakeOption { get; set; }
        public int? MaskOption { get; set; }
        public int? HardnessOption { get; set; }
        public int? SeriesOption { get; set; }
        public int? AlloyOption { get; set; }
        public int? Customer { get; set; }
        public int ProcessId { get; set; }
        public int ProcessRevId { get; set; }

    }
}
