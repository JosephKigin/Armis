using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.ProcessModels
{
    public class SubOpModel
    {
        public int SubOpId { get; set; }
        public string Name { get; set; }

        public IEnumerable<SubOpRevisionModel> Revs { get; set; }
    }
}
