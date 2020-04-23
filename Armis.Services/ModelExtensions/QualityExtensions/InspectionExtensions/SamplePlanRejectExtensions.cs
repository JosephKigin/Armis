using Armis.BusinessModels.QualityModels.Spec;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.QualityExtensions.SpecExtensions
{
    public static class SamplePlanRejectExtensions
    {
        public static SamplePlanRejectModel ToModel(this SamplePlanReject aRejectEntity)
        {
            return new SamplePlanRejectModel()
            {
                SamplePlanId = aRejectEntity.SamplePlanId,
                SamplePlanLevelId = aRejectEntity.SamplePlanLevelId,
                InspectTestTypeId = aRejectEntity.InspectTestId,
                SampleQty = aRejectEntity.SampleQty,
                RejectAllowQty = aRejectEntity.RejectAllowQty
            };
        }
        public static IEnumerable<SamplePlanRejectModel> ToModels(this IEnumerable<SamplePlanReject> aRejectEntities)
        {
            var resultModels = new List<SamplePlanRejectModel>();

            foreach (var entity in aRejectEntities)
            {
                resultModels.Add(entity.ToModel());
            }

            return resultModels;
        }

        public static SamplePlanRejectModel ToHydratedModel(this SamplePlanReject aRejectEntity)
        {
            return new SamplePlanRejectModel()
            {
                SamplePlanId = aRejectEntity.SamplePlanId,
                SamplePlanLevelId = aRejectEntity.SamplePlanLevelId,
                InspectTestTypeId = aRejectEntity.InspectTestId,
                SampleQty = aRejectEntity.SampleQty,
                RejectAllowQty = aRejectEntity.RejectAllowQty,

                InspectioneTestType = aRejectEntity.InspectTest.ToModel()
            };
        }

        public static IEnumerable<SamplePlanRejectModel> ToHydratedModels(this IEnumerable<SamplePlanReject> aRejectEntities)
        {
            var resultModels = new List<SamplePlanRejectModel>();

            foreach (var entity in aRejectEntities)
            {
                resultModels.Add(entity.ToHydratedModel());
            }

            return resultModels;
        }
    }
}
