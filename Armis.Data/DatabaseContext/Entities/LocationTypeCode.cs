using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class LocationTypeCode
    {
        public LocationTypeCode()
        {
            ShopLocation = new HashSet<ShopLocation>();
        }

        public byte LocationTypeId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ShopLocation> ShopLocation { get; set; }
    }
}
