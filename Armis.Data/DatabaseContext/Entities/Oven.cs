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

        public short OvenId { get; set; }
        public string Code { get; set; }
        public string OvenName { get; set; }

        public virtual ICollection<BakeResult> BakeResult { get; set; }
    }
}
