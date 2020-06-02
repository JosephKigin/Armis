using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.OrderEntryModels
{
    public class CommentCodeModel
    {
        public int CommentId { get; set; }
        public string CommentCode { get; set; }
        public string CommentDesc { get; set; }
        public decimal? PriceIncPerc { get; set; }
    }
}