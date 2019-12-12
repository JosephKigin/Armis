using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.Process
{
    public class ProcessModel
    {
        public int ProcessId { get; set; }
        public string Name { get; set; }
        public int? CustId { get; set; }

        public IEnumerable<ProcessRevisionModel> Revisions { get; set; }
    }
}
