using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class TestType
    {
        public TestType()
        {
            SamplePlanHead = new HashSet<SamplePlanHead>();
        }

        public string TestCd { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SamplePlanHead> SamplePlanHead { get; set; }
    }
}
