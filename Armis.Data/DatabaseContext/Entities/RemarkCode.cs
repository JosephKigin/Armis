using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class RemarkCode
    {
        public int RemarkId { get; set; }
        public string Description { get; set; }
        public string QuickKey { get; set; }
        public bool Inactive { get; set; }
        public bool Tmupdate { get; set; }
        public bool IsReworkType { get; set; }
    }
}
