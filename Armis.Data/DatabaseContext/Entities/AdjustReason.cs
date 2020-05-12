using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class AdjustReason
    {
        public short AdjustReasonId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
