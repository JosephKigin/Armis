using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.QualityModels.Process
{
    public class StepCategoryModel
    {
        public short Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } //TODO: Check up on this later, may or may not be needed.
    }
}
