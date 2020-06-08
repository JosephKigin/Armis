using Armis.BusinessModels.ARModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ARExtensions
{
    public static class CertificationExtensions
    {
        public static CertificationChargeModel ToModel(this CertificationCharge aCertCharge)
        {
            return new CertificationChargeModel()
            {
                CertChargeId = aCertCharge.CertChargeId,
                DefaultChargeAmt = aCertCharge.DefaultChargeAmt,
                NadcapChargeAmt = aCertCharge.NadcapChargeAmt
            };
        } 
    }
}
