using Armis.BusinessModels.ProcessModels.Spec;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ProcessExtensions.SpecExtensions
{
    public static class SpecProcessAssignExtensions
    {
        public static SpecProcessAssignModel ToModel(this SpecProcessAssign aSpecProcessAssignEntity)
        {
            return new SpecProcessAssignModel()
            {
                SpecId = aSpecProcessAssignEntity.SpecId,
                SpecRevId = aSpecProcessAssignEntity.SpecRevId,
                SpecAssignId = aSpecProcessAssignEntity.SpecAssignId,
                SubLevelOption1 = aSpecProcessAssignEntity.SubLevelOption1,
                ChoiceOption1 = aSpecProcessAssignEntity.ChoiceOption1,
                SubLevelOption2 = aSpecProcessAssignEntity.SubLevelOption2,
                ChoiceOption2 = aSpecProcessAssignEntity.ChoiceOption2,
                SubLevelOption3 = aSpecProcessAssignEntity.SubLevelOption3,
                ChoiceOption3 = aSpecProcessAssignEntity.ChoiceOption3,
                SubLevelOption4 = aSpecProcessAssignEntity.SubLevelOption4,
                ChoiceOption4 = aSpecProcessAssignEntity.ChoiceOption4,
                SubLevelOption5 = aSpecProcessAssignEntity.SubLevelOption5,
                ChoiceOption5 = aSpecProcessAssignEntity.ChoiceOption5,
                SubLevelOption6 = aSpecProcessAssignEntity.SubLevelOption6,
                ChoiceOption6 = aSpecProcessAssignEntity.ChoiceOption6,
                PreBakeOption = aSpecProcessAssignEntity.PreBakeOption,
                PostBakeOption = aSpecProcessAssignEntity.PostBakeOption,
                MaskOption = aSpecProcessAssignEntity.MaskOption,
                HardnessOption = aSpecProcessAssignEntity.HardnessOption,
                SeriesOption = aSpecProcessAssignEntity.SeriesOption,
                AlloyOption = aSpecProcessAssignEntity.AlloyOption,
                Customer = aSpecProcessAssignEntity.Customer,
                ProcessId = aSpecProcessAssignEntity.ProcessId,
                ProcessRevId = aSpecProcessAssignEntity.ProcessRevId
            };
        }

        public static SpecProcessAssign ToEntity(this SpecProcessAssignModel aSpecProcessAssignModel)
        {
            return new SpecProcessAssign()
            {
                SpecId = aSpecProcessAssignModel.SpecId,
                SpecRevId = aSpecProcessAssignModel.SpecRevId,
                SpecAssignId = aSpecProcessAssignModel.SpecAssignId,
                SubLevelOption1 = aSpecProcessAssignModel.SubLevelOption1,
                ChoiceOption1 = aSpecProcessAssignModel.ChoiceOption1,
                SubLevelOption2 = aSpecProcessAssignModel.SubLevelOption2,
                ChoiceOption2 = aSpecProcessAssignModel.ChoiceOption2,
                SubLevelOption3 = aSpecProcessAssignModel.SubLevelOption3,
                ChoiceOption3 = aSpecProcessAssignModel.ChoiceOption3,
                SubLevelOption4 = aSpecProcessAssignModel.SubLevelOption4,
                ChoiceOption4 = aSpecProcessAssignModel.ChoiceOption4,
                SubLevelOption5 = aSpecProcessAssignModel.SubLevelOption5,
                ChoiceOption5 = aSpecProcessAssignModel.ChoiceOption5,
                SubLevelOption6 = aSpecProcessAssignModel.SubLevelOption6,
                ChoiceOption6 = aSpecProcessAssignModel.ChoiceOption6,
                PreBakeOption = aSpecProcessAssignModel.PreBakeOption,
                PostBakeOption = aSpecProcessAssignModel.PostBakeOption,
                MaskOption = aSpecProcessAssignModel.MaskOption,
                HardnessOption = aSpecProcessAssignModel.HardnessOption,
                SeriesOption = aSpecProcessAssignModel.SeriesOption,
                AlloyOption = aSpecProcessAssignModel.AlloyOption,
                Customer = aSpecProcessAssignModel.Customer,
                ProcessId = aSpecProcessAssignModel.ProcessId,
                ProcessRevId = aSpecProcessAssignModel.ProcessRevId
            };
        }
    }
}
