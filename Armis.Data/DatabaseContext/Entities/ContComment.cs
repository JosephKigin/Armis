using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class ContComment
    {
        public int ContactId { get; set; }
        public string Comments { get; set; }
    }
}
