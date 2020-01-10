using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.ProcessModels
{
    public class StepCategoryModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } //TODO: Check up on this late, may or may not be needed.
    }
}
