using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class StepVarOption
    {
        public string VarTempCd { get; set; }
        public string VarOption { get; set; }

        public virtual StepVarTemplate VarTempCdNavigation { get; set; }
    }
}
