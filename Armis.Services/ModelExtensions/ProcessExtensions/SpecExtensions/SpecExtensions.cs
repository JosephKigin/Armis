using Armis.BusinessModels.ProcessModels.Spec;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ProcessExtensions.SpecExtensions
{
    public static class SpecExtensions
    {
        public static SpecModel ToModel(this Specification aSpec)
        {
            return new SpecModel()
            {
                Id = aSpec.SpecId,
                InternalRev = aSpec.SpecRevId,
                Description = aSpec.Description,
                Code = aSpec.SpecCode,
                ExternalRev = aSpec.ExternalRev
            };
        }

        public static SpecModel ToHydratedModel(this Specification aSpec)
        {
            var resultModel = aSpec.ToModel();

            var subLevelList = new List<SpecSubLevelModel>();
            foreach (var subLevel in aSpec.SpecSubLevel)
            {
                subLevelList.Add(subLevel.ToHydratedModel());
            }
            resultModel.SubLevels = subLevelList;

            return resultModel;
        }

        public static IEnumerable<SpecModel> ToHydratedModels(this IEnumerable<Specification> aSpecList)
        {
            var resultModelList = new List<SpecModel>();

            foreach (var spec in aSpecList)
            {
                resultModelList.Add(spec.ToHydratedModel());
            }

            return resultModelList;
        }

        public static Specification ToEntity(this SpecModel aSpecModel, int aSpecId, short aSpecRevId)
        {
            return new Specification()
            {
                SpecId = aSpecId,
                SpecRevId = aSpecRevId,
                SpecCode = aSpecModel.Code,
                Description = aSpecModel.Description,
                ExternalRev = aSpecModel.ExternalRev,
                SamplePlan = null, //TODO: Figure out w/ sample plan
                NadCapSamplePlan = null //TODO: See Above
            };
        }
    }
}
