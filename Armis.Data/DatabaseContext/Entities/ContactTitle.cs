using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class ContactTitle
    {
        public short ContactTitleId { get; set; }
        public string TitleName { get; set; }
        public bool Inactive { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
