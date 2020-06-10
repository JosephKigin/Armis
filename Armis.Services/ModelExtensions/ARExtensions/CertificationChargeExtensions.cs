using Armis.BusinessModels.ARModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ARExtensions
{
    public static class CertificationChargeExtensions
    {
        public static CertificationChargeModel ToModel(this CertificationCharge aCertChargeEntity)
        {
            return new CertificationChargeModel()
            {
                CertChargeId = aCertChargeEntity.CertChargeId,
                DefaultChargeAmt = aCertChargeEntity.DefaultChargeAmt,
                NadcapChargeAmt = aCertChargeEntity.NadcapChargeAmt
            };
        }

        public static IEnumerable<CertificationChargeModel> ToModels(this IEnumerable<CertificationCharge> aCertChargeEntities)
        {
            var result = new List<CertificationChargeModel>();

            foreach (var entity in aCertChargeEntities)
            {
                result.Add(entity.ToModel());
            }

            return result;
        }
    }
}
