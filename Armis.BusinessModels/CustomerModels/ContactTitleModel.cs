using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.CustomerModels
{
    public class ContactTitleModel
    {
        public short ContactTitleId { get; set; }
        public string TitleName { get; set; }
        public bool Inactive { get; set; }
    }
}
