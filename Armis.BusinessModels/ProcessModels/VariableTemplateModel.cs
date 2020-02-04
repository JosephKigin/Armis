using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.ProcessModels
{
    public class VariableTemplateModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public VariableTypeModel Type { get; set; }
    }
}