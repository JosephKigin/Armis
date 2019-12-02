using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Oven
    {
        public Oven()
        {
            BakeResult = new HashSet<BakeResult>();
        }

        public string OvenCd { get; set; }
        public string OvenName { get; set; }

        public virtual ICollection<BakeResult> BakeResult { get; set; }
    }
}
