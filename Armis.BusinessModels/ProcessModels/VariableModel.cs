using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.ProcessModels
{
    public class VariableModel
    {
        public string UnitOfMeasure { get; set; }
        public float Min { get; set; }
        public float Max { get; set; }
        public int TemplateId { get; set; }

    }
}
