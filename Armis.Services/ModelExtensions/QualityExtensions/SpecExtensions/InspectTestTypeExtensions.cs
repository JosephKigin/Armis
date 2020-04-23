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
    }
}
