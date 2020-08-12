using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Hardness
    {
        public int HardnessId { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public decimal? HardnessMin { get; set; }
        public decimal? HardnessMax { get; set; }
    }
}
