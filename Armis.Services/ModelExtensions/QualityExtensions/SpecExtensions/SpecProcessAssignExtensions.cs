using Armis.BusinessModels.QualityModels.Spec;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.ModelExtensions.PartExtensions;
using Armis.DataLogic.ModelExtensions.QualityExtensions.ProcessExtensions;
using Armis.DataLogic.ModelExtensions.CustomerExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.QualityExtensions.SpecExtensions
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
                ChoiceOptionId1 = aSpecProcessAssignEntity.ChoiceOption1,
                SubLevelOption2 = aSpecProcessAssignEntity.SubLevelOption2,
                ChoiceOptionId2 = aSpecProcessAssignEntity.ChoiceOption2,
                SubLevelOption3 = aSpecProcessAssignEntity.SubLevelOption3,
                ChoiceOptionId3 = aSpecProcessAssignEntity.ChoiceOption3,
                SubLevelOption4 = aSpecProcessAssignEntity.SubLevelOption4,
                ChoiceOptionId4 = aSpecProcessAssignEntity.ChoiceOption4,
                SubLevelOption5 = aSpecProcessAssignEntity.SubLevelOption5,
                ChoiceOptionId5 = aSpecProcessAssignEntity.ChoiceOption5,
                SubLevelOption6 = aSpecProcessAssignEntity.SubLevelOption6,
                ChoiceOptionId6 = aSpecProcessAssignEntity.ChoiceOption6,
                PreBakeOptionId = aSpecProcessAssignEntity.PreBakeOption,
                PostBakeOptionId = aSpecProcessAssignEntity.PostBakeOption,
                MaskOptionId = aSpecProcessAssignEntity.MaskOption,
                HardnessOptionId = aSpecProcessAssignEntity.HardnessOption,
                SeriesOptionId = aSpecProcessAssignEntity.SeriesOption,
                AlloyOptionId = aSpecProcessAssignEntity.AlloyOption,
                CustomerId = aSpecProcessAssignEntity.Customer,
                ProcessId = aSpecProcessAssignEntity.ProcessId,
                ProcessRevId = aSpecProcessAssignEntity.ProcessRevId
            };
        }

        public static SpecProcessAssignModel ToHydratedModel(this SpecProcessAssign aSpecProcessAssignEntity)
        {
            return new SpecProcessAssignModel()
            {
                SpecId = aSpecProcessAssignEntity.SpecId,
                SpecRevId = aSpecProcessAssignEntity.SpecRevId,
                SpecAssignId = aSpecProcessAssignEntity.SpecAssignId,
                SubLevelOption1 = aSpecProcessAssignEntity.SubLevelOption1,
                ChoiceOptionId1 = aSpecProcessAssignEntity.ChoiceOption1,
                SubLevelOption2 = aSpecProcessAssignEntity.SubLevelOption2,
                ChoiceOptionId2 = aSpecProcessAssignEntity.ChoiceOption2,
                SubLevelOption3 = aSpecProcessAssignEntity.SubLevelOption3,
                ChoiceOptionId3 = aSpecProcessAssignEntity.ChoiceOption3,
                SubLevelOption4 = aSpecProcessAssignEntity.SubLevelOption4,
                ChoiceOptionId4 = aSpecProcessAssignEntity.ChoiceOption4,
                SubLevelOption5 = aSpecProcessAssignEntity.SubLevelOption5,
                ChoiceOptionId5 = aSpecProcessAssignEntity.ChoiceOption5,
                SubLevelOption6 = aSpecProcessAssignEntity.SubLevelOption6,
                ChoiceOptionId6 = aSpecProcessAssignEntity.ChoiceOption6,
                PreBakeOptionId = aSpecProcessAssignEntity.PreBakeOption,
                PostBakeOptionId = aSpecProcessAssignEntity.PostBakeOption,
                MaskOptionId = aSpecProcessAssignEntity.MaskOption,
                HardnessOptionId = aSpecProcessAssignEntity.HardnessOption,
                SeriesOptionId = aSpecProcessAssignEntity.SeriesOption,
                AlloyOptionId = aSpecProcessAssignEntity.AlloyOption,
                CustomerId = aSpecProcessAssignEntity.Customer,
                ProcessId = aSpecProcessAssignEntity.ProcessId,
                ProcessRevId = aSpecProcessAssignEntity.ProcessRevId,
                PreBakeOption = (aSpecProcessAssignEntity.PreBakeOptionNavigation != null) ? aSpecProcessAssignEntity.PreBakeOptionNavigation.ToModel() : null,
                PostBakeOption = (aSpecProcessAssignEntity.PostBakeOptionNavigation != null) ? aSpecProcessAssignEntity.PostBakeOptionNavigation.ToModel() : null,
                MaskOption = (aSpecProcessAssignEntity.MaskOptionNavigation != null) ? aSpecProcessAssignEntity.MaskOptionNavigation.ToModel() : null,
                HardnessOption = (aSpecProcessAssignEntity.HardnessOptionNavigation != null) ? aSpecProcessAssignEntity.HardnessOptionNavigation.ToModel() : null,
                SeriesOption = (aSpecProcessAssignEntity.SeriesOptionNavigation != null) ? aSpecProcessAssignEntity.SeriesOptionNavigation.ToModel() : null,
                AlloyOption = (aSpecProcessAssignEntity.AlloyOptionNavigation != null) ? aSpecProcessAssignEntity.AlloyOptionNavigation.ToModel() : null,
                Choice1 = (aSpecProcessAssignEntity.SpecChoice != null) ? aSpecProcessAssignEntity.SpecChoice.ToModel() : null,
                Choice2 = (aSpecProcessAssignEntity.SpecChoiceNavigation != null) ? aSpecProcessAssignEntity.SpecChoiceNavigation.ToModel() : null,
                Choice3 = (aSpecProcessAssignEntity.SpecChoice1 != null) ? aSpecProcessAssignEntity.SpecChoice1.ToModel() : null,
                Choice4 = (aSpecProcessAssignEntity.SpecChoice2 != null) ? aSpecProcessAssignEntity.SpecChoice2.ToModel() : null,
                Choice5 = (aSpecProcessAssignEntity.SpecChoice3 != null) ? aSpecProcessAssignEntity.SpecChoice3.ToModel() : null,
                Choice6 = (aSpecProcessAssignEntity.SpecChoice4 != null) ? aSpecProcessAssignEntity.SpecChoice4.ToModel() : null,
                ProcessRevision = aSpecProcessAssignEntity.Process.ToModel(),
                Customer = (aSpecProcessAssignEntity.CustomerNavigation != null)? aSpecProcessAssignEntity.CustomerNavigation.ToModel() : null
            };
        }

        public static IEnumerable<SpecProcessAssignModel> ToHydratedModels(this IEnumerable<SpecProcessAssign> aSpecProcessAssignEntities)
        {
            var theResultingModels = new List<SpecProcessAssignModel>();

            foreach (var entity in aSpecProcessAssignEntities)
            {
                theResultingModels.Add(entity.ToHydratedModel());
            }

            return theResultingModels;
        }

        public static SpecProcessAssign ToEntity(this SpecProcessAssignModel aSpecProcessAssignModel)
        {
            return new SpecProcessAssign()
            {
                SpecId = aSpecProcessAssignModel.SpecId,
                SpecRevId = aSpecProcessAssignModel.SpecRevId,
                SpecAssignId = aSpecProcessAssignModel.SpecAssignId,
                SubLevelOption1 = aSpecProcessAssignModel.SubLevelOption1,
                ChoiceOption1 = aSpecProcessAssignModel.ChoiceOptionId1,
                SubLevelOption2 = aSpecProcessAssignModel.SubLevelOption2,
                ChoiceOption2 = aSpecProcessAssignModel.ChoiceOptionId2,
                SubLevelOption3 = aSpecProcessAssignModel.SubLevelOption3,
                ChoiceOption3 = aSpecProcessAssignModel.ChoiceOptionId3,
                SubLevelOption4 = aSpecProcessAssignModel.SubLevelOption4,
                ChoiceOption4 = aSpecProcessAssignModel.ChoiceOptionId4,
                SubLevelOption5 = aSpecProcessAssignModel.SubLevelOption5,
                ChoiceOption5 = aSpecProcessAssignModel.ChoiceOptionId5,
                SubLevelOption6 = aSpecProcessAssignModel.SubLevelOption6,
                ChoiceOption6 = aSpecProcessAssignModel.ChoiceOptionId6,
                PreBakeOption = aSpecProcessAssignModel.PreBakeOptionId,
                PostBakeOption = aSpecProcessAssignModel.PostBakeOptionId,
                MaskOption = aSpecProcessAssignModel.MaskOptionId,
                HardnessOption = aSpecProcessAssignModel.HardnessOptionId,
                SeriesOption = aSpecProcessAssignModel.SeriesOptionId,
                AlloyOption = aSpecProcessAssignModel.AlloyOptionId,
                Customer = aSpecProcessAssignModel.CustomerId,
                ProcessId = aSpecProcessAssignModel.ProcessId,
                ProcessRevId = aSpecProcessAssignModel.ProcessRevId
            };
        }
    }
}
