using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.ProcessModels
{
    public class VariableModel
    {
        public UOMCodeModel UnitOfMeasure { get; set; }
        public decimal? Min { get; set; }
        public decimal? Max { get; set; }
        public VariableTemplateModel Template { get; set; }

    }
}
