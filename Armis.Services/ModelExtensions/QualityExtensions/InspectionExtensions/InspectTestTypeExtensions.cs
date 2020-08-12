using Armis.BusinessModels.QualityModels.InspectionModels;
using Armis.BusinessModels.QualityModels.Spec;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.QualityExtensions.SpecExtensions
{
    public static class InspectTestTypeExtensions
    {
        public static InspectTestTypeModel ToModel(this InspectTestType aTestTypeEntity)
        {
            return new InspectTestTypeModel()
            {
                InspectTestId = aTestTypeEntity.InspectTestId,
                TestCode = aTestTypeEntity.TestCode,
                Description = aTestTypeEntity.Description
            };
        }

        public static IEnumerable<InspectTestTypeModel> ToModels(this IEnumerable<InspectTestType> aTestTypeEntities)
        {
            var resultModels = new List<InspectTestTypeModel>();

            foreach (var entity in aTestTypeEntities)
            {
                resultModels.Add(entity.ToModel());
            }

            return resultModels;
        }

        public static InspectTestType ToEntity(this InspectTestTypeModel aTestTypeModel)
        {
            return new InspectTestType()
            {
                InspectTestId = aTestTypeModel.InspectTestId,
                Description = aTestTypeModel.Description,
                TestCode = aTestTypeModel.TestCode
            };
        }
    }
}
