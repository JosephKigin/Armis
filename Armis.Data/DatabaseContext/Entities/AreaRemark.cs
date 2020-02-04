using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class AreaRemark
    {
        public short AreaId { get; set; }
        public int RemarkId { get; set; }

        public virtual Area Area { get; set; }
        public virtual RemarkCode Remark { get; set; }
    }
}
