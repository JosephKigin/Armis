using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class StepVarOption
    {
        public int VarTempId { get; set; }
        public string VarOption { get; set; }

        public virtual StepVarTemplate VarTemp { get; set; }
    }
}
