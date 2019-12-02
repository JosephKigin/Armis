using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Rack
    {
        public Rack()
        {
            ProcessLoad = new HashSet<ProcessLoad>();
        }

        public int RackId { get; set; }
        public string Description { get; set; }
        public string Dimensions { get; set; }
        public string MaterialCd { get; set; }
        public short? AreaId { get; set; }
        public int? ExtensionQty { get; set; }
        public string Photo { get; set; }
        public string Notes { get; set; }

        public virtual Area Area { get; set; }
        public virtual MaterialAlloy MaterialCdNavigation { get; set; }
        public virtual ICollection<ProcessLoad> ProcessLoad { get; set; }
    }
}
