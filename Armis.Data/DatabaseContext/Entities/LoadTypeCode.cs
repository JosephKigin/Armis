using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class LoadTypeCode
    {
        public LoadTypeCode()
        {
            Department = new HashSet<Department>();
            OprLoadPrice = new HashSet<OprLoadPrice>();
            PlateResult = new HashSet<PlateResult>();
            ProcessLoad = new HashSet<ProcessLoad>();
        }

        public byte LoadTypeId { get; set; }
        public string Code { get; set; }
        public string LoadTypeName { get; set; }

        public virtual ICollection<Department> Department { get; set; }
        public virtual ICollection<OprLoadPrice> OprLoadPrice { get; set; }
        public virtual ICollection<PlateResult> PlateResult { get; set; }
        public virtual ICollection<ProcessLoad> ProcessLoad { get; set; }
    }
}
