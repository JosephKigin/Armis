using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Stamp
    {
        public short StampId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
