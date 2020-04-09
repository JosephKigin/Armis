using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.PartModels
{
    public class HardnessModel
    {
        public int HardnessId { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public decimal? HardnessMin { get; set; }
        public decimal? HardnessMax { get; set; }
    }
}
