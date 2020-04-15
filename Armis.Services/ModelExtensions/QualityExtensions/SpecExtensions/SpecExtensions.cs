using Armis.BusinessModels.QualityModels.Spec;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.QualityExtensions.SpecExtensions
{
    public static class SpecExtensions
    {
        public static SpecModel ToModel(this Specification aSpec)
        {
            return new SpecModel
            {
                Id = aSpec.SpecId,
                Code = aSpec.SpecCode
            };
        }

        public static IEnumerable<SpecModel> ToModels(this IEnumerable<Specification> aSpecs)
        {
            var resultSpecModels = new List<SpecModel>();
            
            foreach (var spec in aSpecs)
            {
                resultSpecModels.Add(spec.ToModel());
            }

            return resultSpecModels;
        }

        public static SpecModel ToHydratedModel(this Specification aSpec)
        {
            return new SpecModel
            {
                Id = aSpec.SpecId,
                Code = aSpec.SpecCode,
                SpecRevModels = aSpec.SpecificationRevision.ToHydratedModels()
            };
        }

        public static IEnumerable<SpecModel> ToHydratedModels(this IEnumerable<Specification> aSpecs)
        {
            var resultSpecModels = new List<SpecModel>();

            foreach (var spec in aSpecs)
            {
                resultSpecModels.Add(spec.ToHydratedModel());
            }
            return resultSpecModels;
        }

        public static Specification ToEntity(this SpecModel aSpecModel, int aSpecId) //A spec Id needs to be passed in because it won't be known until the service level of the API.
        {
            return new Specification
            {
                SpecId = aSpecId,
                SpecCode = aSpecModel.Code
            };
        }
    }
}
