using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class ProcessLoad
    {
        public int ProcessLoadId { get; set; }
        public byte LoadTypeId { get; set; }
        public short? DepartmentId { get; set; }
        public decimal? PiecePrice { get; set; }
        public decimal? MinLotCharge { get; set; }
        public int? PartsPerLoad { get; set; }
        public string Comments { get; set; }
        public int? Rack { get; set; }

        public virtual Department Department { get; set; }
        public virtual LoadTypeCode LoadType { get; set; }
        public virtual Rack RackNavigation { get; set; }
    }
}
