using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.ARModels
{
    public class AdditionalChargeModel
    {
        public short ChargeId { get; set; }
        public string Code { get; set; }
        public short ChargeTypeId { get; set; }
        public decimal Amount { get; set; }

        public AdditionalChargeTypeModel ChargeType { get; set; }
    }
}
