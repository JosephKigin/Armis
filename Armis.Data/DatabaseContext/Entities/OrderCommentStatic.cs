using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class OrderCommentStatic
    {
        public int OrderId { get; set; }
        public short CommentSeq { get; set; }
        public short? DeptId { get; set; }
        public string StaticComments { get; set; }

        public virtual Department Dept { get; set; }
        public virtual OrderHead Order { get; set; }
    }
}
