using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.ProcessModels.Spec
{
    public class SpecRevModel
    {
        public int SpecId { get; set; }
        public int InternalRev { get; set; }
        public string Description { get; set; }
        public string ExternalRev { get; set; }
        public short EmployeeNumber { get; set; } //TODO: this could be an entire employee model but for now I am just keeping it as a number because all the employee information isn't needed when the spec rev is pulled.
        public DateTime DateModified { get; set; }
        public TimeSpan TimeModified { get; set; }
        public IEnumerable<SpecSubLevelModel> SubLevels { get; set; }
    }
}
