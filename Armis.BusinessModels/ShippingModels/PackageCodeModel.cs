using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.ShippingModels
{
    public class PackageCodeModel
    {
        public short PackageId { get; set; }
        public string PackageCd { get; set; }
        public string Description { get; set; }
        public decimal AddOnPercent { get; set; }
    }
}
