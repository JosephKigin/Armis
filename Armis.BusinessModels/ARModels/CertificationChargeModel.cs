using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.ARModels
{
    public class CertificationChargeModel
    {
        public short CertChargeId { get; set; }
        public decimal? DefaultChargeAmt { get; set; }
        public decimal? NadcapChargeAmt { get; set; }
    }
}
