using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.CustomerModels
{
    public class CustomerStatusModel
    {
        public byte StatusId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
