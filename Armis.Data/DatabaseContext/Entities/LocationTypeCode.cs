using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class LocationTypeCode
    {
        public LocationTypeCode()
        {
            Location = new HashSet<Location>();
        }

        public string LocTypeCd { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Location> Location { get; set; }
    }
}
