using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class LoadType
    {
        public LoadType()
        {
            Department = new HashSet<Department>();
            OprLoadPrice = new HashSet<OprLoadPrice>();
            PlateResult = new HashSet<PlateResult>();
            ProcessLoad = new HashSet<ProcessLoad>();
        }

        public string LoadTypeCd { get; set; }
        public string LoadTypeName { get; set; }

        public virtual ICollection<Department> Department { get; set; }
        public virtual ICollection<OprLoadPrice> OprLoadPrice { get; set; }
        public virtual ICollection<PlateResult> PlateResult { get; set; }
        public virtual ICollection<ProcessLoad> ProcessLoad { get; set; }
    }
}
