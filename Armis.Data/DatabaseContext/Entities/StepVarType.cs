using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class StepVarType
    {
        public StepVarType()
        {
            StepVarTemplate = new HashSet<StepVarTemplate>();
        }

        public string StepVarTypeCd { get; set; }
        public string Description { get; set; }

        public virtual ICollection<StepVarTemplate> StepVarTemplate { get; set; }
    }
}
