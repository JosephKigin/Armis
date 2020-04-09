using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.ProcessModels.Spec
{
    public class SpecModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public IEnumerable<SpecRevModel> SpecRevModels { get; set; }
    }
}
