using Armis.BusinessModels.QualityModels;
using Armis.BusinessModels.QualityModels.InspectionModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.QualityExtensions.InspectionExtensions
{
    public static class QualityStandardExtensions
    {
        public static QualityStandardModel ToModel(this QualityStandard aQualityStandardEntity)
        {
            return new QualityStandardModel()
            {
                QualStdId = aQualityStandardEntity.QualStdId,
                QualStdCode = aQualityStandardEntity.QualStdCode,
                Qsdescription = aQualityStandardEntity.Qsdescription
            };
        }

        public static IEnumerable<QualityStandardModel> ToModels(this IEnumerable<QualityStandard> aQualityStandardEntities)
        {
            var result = new List<QualityStandardModel>();

            foreach (var entity in aQualityStandardEntities)
            {
                result.Add(entity.ToModel());
            }

            return result;
        }
    }
}
