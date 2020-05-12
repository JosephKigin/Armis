using Armis.BusinessModels.Customer;
using Armis.BusinessModels.PartModels;
using Armis.BusinessModels.QualityModels.Process;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.QualityModels.Spec
{

    public class SpecProcessAssignModel
    {
#nullable enable
        public int SpecId { get; set; }
        public short SpecRevId { get; set; }
        public int SpecAssignId { get; set; }
        public byte? SubLevelOption1 { get; set; }
        public byte? ChoiceOptionId1 { get; set; }
        public byte? SubLevelOption2 { get; set; }
        public byte? ChoiceOptionId2 { get; set; }
        public byte? SubLevelOption3 { get; set; }
        public byte? ChoiceOptionId3 { get; set; }
        public byte? SubLevelOption4 { get; set; }
        public byte? ChoiceOptionId4 { get; set; }
        public byte? SubLevelOption5 { get; set; }
        public byte? ChoiceOptionId5 { get; set; }
        public byte? SubLevelOption6 { get; set; }
        public byte? ChoiceOptionId6 { get; set; }
        public int? PreBakeOptionId { get; set; }
        public int? PostBakeOptionId { get; set; }
        public int? MaskOptionId { get; set; }
        public int? HardnessOptionId { get; set; }
        public int? SeriesOptionId { get; set; }
        public int? AlloyOptionId { get; set; }
        public int? CustomerId { get; set; }
        public int ProcessId { get; set; }
        public int ProcessRevId { get; set; }
        public StepModel? PreBakeOption { get; set; }
        public StepModel? PostBakeOption { get; set; }
        public StepModel? MaskOption { get; set; }
        public HardnessModel? HardnessOption { get; set; }
        public MaterialSeriesModel? SeriesOption { get; set; }
        public MaterialAlloyModel? AlloyOption { get; set; }
        public CustomerModel? Customer { get; set; }
        public ProcessRevisionModel? ProcessRevision { get; set; }
        public SpecRevModel? SpecificationRevision { get; set; }
        public SpecSubLevelChoiceModel? Choice1 { get; set; }
        public SpecSubLevelChoiceModel? Choice2 { get; set; }
        public SpecSubLevelChoiceModel? Choice3 { get; set; }
        public SpecSubLevelChoiceModel? Choice4 { get; set; }
        public SpecSubLevelChoiceModel? Choice5 { get; set; }
        public SpecSubLevelChoiceModel? Choice6 { get; set; }
    }
}
