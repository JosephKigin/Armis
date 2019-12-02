using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.Core.Models.Process.RevModels
{
    public class StepVariableModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string UnitOfMeasure { get; set; }
        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }
    }
}
