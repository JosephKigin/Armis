using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.ARModels
{
    public class PriceCodeModel
    {
        public byte PriceCodeId { get; set; }
        public string LongCode { get; set; }
        public string ShortCode { get; set; }
        public string Description { get; set; }
    }
}
