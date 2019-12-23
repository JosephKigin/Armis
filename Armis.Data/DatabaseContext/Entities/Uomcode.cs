using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class UOMcode
    {
        public UOMcode()
        {
            StepVariable = new HashSet<StepVariable>();
        }

        public string Uomcd { get; set; }
        public string Uomdesc { get; set; }

        public virtual ICollection<StepVariable> StepVariable { get; set; }
    }
}
