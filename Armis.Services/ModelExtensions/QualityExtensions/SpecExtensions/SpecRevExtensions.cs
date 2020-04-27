using Armis.BusinessModels.QualityModels.Spec;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.QualityExtensions.SpecExtensions
{
    public static class SpecRevExtensions
    {
        public static SpecRevModel ToModel(this SpecificationRevision aSpecRev)
        {
            return new SpecRevModel()
            {
                SpecId = aSpecRev.SpecId,
                InternalRev = aSpecRev.SpecRevId,
                Description = aSpecRev.Description,
                ExternalRev = aSpecRev.ExternalRev,
                SamplePlanId = aSpecRev.SamplePlan,
                EmployeeNumber = aSpecRev.CreatedByEmp,
                DateModified = aSpecRev.DateModified,
                TimeModified = aSpecRev.TimeModified
            };
        }

        public static SpecRevModel ToHydratedModel(this SpecificationRevision aSpecRevEntity)
        {
            var resultModel = new SpecRevModel()
            {
                SpecId = aSpecRevEntity.SpecId,
                InternalRev = aSpecRevEntity.SpecRevId,
                Description = aSpecRevEntity.Description,
                ExternalRev = aSpecRevEntity.ExternalRev,
                SamplePlanId = aSpecRevEntity.SamplePlan,
                EmployeeNumber = aSpecRevEntity.CreatedByEmp,
                DateModified = aSpecRevEntity.DateModified,
                TimeModified = aSpecRevEntity.TimeModified,

                SubLevels = aSpecRevEntity.SpecSubLevel.ToHydratedModels()
            };

            resultModel.SamplePlan = (aSpecRevEntity.SamplePlanNavigation != null)? aSpecRevEntity.SamplePlanNavigation.ToHydratedModel() : null;

            return resultModel;
        }

        public static IEnumerable<SpecRevModel> ToHydratedModels(this IEnumerable<SpecificationRevision> aSpecRevEntities)
        {
            var resultModelList = new List<SpecRevModel>();

            foreach (var entity in aSpecRevEntities)
            {
                resultModelList.Add(entity.ToHydratedModel());
            }

            return resultModelList;
        }

        public static SpecificationRevision ToEntity(this SpecRevModel aSpecRevModel, int aSpecId, short aSpecRevId)
        {
            return new SpecificationRevision()
            {
                SpecId = aSpecId,
                SpecRevId = aSpecRevId,
                Description = aSpecRevModel.Description,
                ExternalRev = aSpecRevModel.ExternalRev,
                SamplePlan = aSpecRevModel.SamplePlanId,
                CreatedByEmp = aSpecRevModel.EmployeeNumber,
                DateModified = DateTime.Now.Date,
                TimeModified = DateTime.Now.TimeOfDay
            };
        }
    }
}
