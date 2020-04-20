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
                EmployeeNumber = aSpecRev.CreatedByEmp,
                DateModified = aSpecRev.DateModified,
                TimeModified = aSpecRev.TimeModified
            };
        }

        public static SpecRevModel ToHydratedModel(this SpecificationRevision aSpecRev)
        {
            var resultModel = aSpecRev.ToModel();

            var subLevelList = new List<SpecSubLevelModel>();
            foreach (var subLevel in aSpecRev.SpecSubLevel)
            {
                subLevelList.Add(subLevel.ToHydratedModel());
            }
            resultModel.SubLevels = subLevelList;

            return resultModel;
        }

        public static IEnumerable<SpecRevModel> ToHydratedModels(this IEnumerable<SpecificationRevision> aSpecRevList)
        {
            var resultModelList = new List<SpecRevModel>();

            foreach (var specRev in aSpecRevList)
            {
                resultModelList.Add(specRev.ToHydratedModel());
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
                SamplePlan = null, //TODO: Figure out w/ sample plan
                CreatedByEmp = aSpecRevModel.EmployeeNumber,
                DateModified = aSpecRevModel.DateModified.Date,
                TimeModified = aSpecRevModel.DateModified.TimeOfDay
            };
        }
    }
}
