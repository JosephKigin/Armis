using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class CommentCode
    {
        public int CommentId { get; set; }
        public string CommentDesc { get; set; }
        public decimal? PriceIncPerc { get; set; }
    }
}
