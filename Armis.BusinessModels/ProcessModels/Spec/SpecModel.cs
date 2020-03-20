using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.ProcessModels.Spec
{
    public class SpecModel
    {
        public int Id { get; set; }
        public int InternalRev { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string ExternalRev { get; set; }
        public IEnumerable<SpecSubLevelModel> SubLevels { get; set; }
    }
}
