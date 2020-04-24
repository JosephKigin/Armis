using Armis.BusinessModels.QualityModels.Spec;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.QualityExtensions.SpecExtensions
{
    public static class SamplePlanLevelExtensions
    {
        public static SamplePlanLevelModel ToModel(this SamplePlanLevel aSamplePlanLevelEntity)
        {
            return new SamplePlanLevelModel()
            {
                SamplePlanId = aSamplePlanLevelEntity.SamplePlanId,
                SamplePlanLevelId = aSamplePlanLevelEntity.SamplePlanLevelId,
                FromQty = aSamplePlanLevelEntity.FromQty,
                ToQty = aSamplePlanLevelEntity.ToQty
            };
        }

        public static IEnumerable<SamplePlanLevelModel> ToModels(this IEnumerable<SamplePlanLevel> aLevelEntities)
        {
            var resultModels = new List<SamplePlanLevelModel>();

            foreach (var entity in aLevelEntities)
            {
                resultModels.Add(entity.ToModel());
            }

            return resultModels;
        }

        public static SamplePlanLevelModel ToHydratedModel(this SamplePlanLevel aSamplePlanLevelEntity)
        {
            return new SamplePlanLevelModel()
            {
                SamplePlanId = aSamplePlanLevelEntity.SamplePlanId,
                SamplePlanLevelId = aSamplePlanLevelEntity.SamplePlanLevelId,
                FromQty = aSamplePlanLevelEntity.FromQty,
                ToQty = aSamplePlanLevelEntity.ToQty,

                SamplePlanRejectModels = aSamplePlanLevelEntity.SamplePlanReject.ToModels()
            };
        }

        public static IEnumerable<SamplePlanLevelModel> ToHydratedModels(this IEnumerable<SamplePlanLevel> aLevelEntities)
        {
            var resultModels = new List<SamplePlanLevelModel>();

            foreach (var entity in aLevelEntities)
            {
                resultModels.Add(entity.ToHydratedModel());
            }

            return resultModels;
        }

        public static SamplePlanLevel ToEntity(this SamplePlanLevelModel aSamplePlanLevelModel)
        {
            return new SamplePlanLevel()
            {
                SamplePlanId = aSamplePlanLevelModel.SamplePlanId,
                SamplePlanLevelId = aSamplePlanLevelModel.SamplePlanLevelId,
                FromQty = aSamplePlanLevelModel.FromQty,
                ToQty = aSamplePlanLevelModel.ToQty
            };
        }

        public static SamplePlanLevel ToHydratedEntity(this SamplePlanLevelModel aSamplePlanLevelModel)
        {
            return new SamplePlanLevel()
            {
                SamplePlanId = aSamplePlanLevelModel.SamplePlanId,
                SamplePlanLevelId = aSamplePlanLevelModel.SamplePlanLevelId,
                FromQty = aSamplePlanLevelModel.FromQty,
                ToQty = aSamplePlanLevelModel.ToQty,

                //SamplePlanReject = aSamplePlanLevelModel.SamplePlanRejectModels.ToEntities()
            };
        }
    }
}
