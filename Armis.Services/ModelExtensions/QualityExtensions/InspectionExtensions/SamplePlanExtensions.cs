using Armis.BusinessModels.QualityModels.Spec;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.QualityExtensions.SpecExtensions
{
    public static class SamplePlanExtensions
    {
        public static SamplePlanModel ToModel(this SamplePlanHead aSamplePlanEntity)
        {
            return new SamplePlanModel()
            {
                SamplePlanId = aSamplePlanEntity.SamplePlanId,
                PlanName = aSamplePlanEntity.PlanName,
                Description = aSamplePlanEntity.Description
            };
        }

        public static IEnumerable<SamplePlanModel> ToModels(this IEnumerable<SamplePlanHead> aSamplePlanEntities)
        {
            var resultModels = new List<SamplePlanModel>();

            foreach (var entity in aSamplePlanEntities)
            {
                resultModels.Add(entity.ToModel());
            }

            return resultModels;
        }

        public static SamplePlanModel ToHydratedModel(this SamplePlanHead aSamplePlanEntity)
        {
            return new SamplePlanModel()
            {
                SamplePlanId = aSamplePlanEntity.SamplePlanId,
                PlanName = aSamplePlanEntity.PlanName,
                Description = aSamplePlanEntity.Description,

                SamplePlanLevelModels = aSamplePlanEntity.SamplePlanLevel.ToHydratedModels()
            };
        }

        public static IEnumerable<SamplePlanModel> ToHydratedModels(this IEnumerable<SamplePlanHead> aSamplePlanEntities)
        {
            var resultModels = new List<SamplePlanModel>();

            foreach (var entity in aSamplePlanEntities)
            {
                resultModels.Add(entity.ToHydratedModel());
            }

            return resultModels;
        }
    }
}
