using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class TestHead
    {
        public TestHead()
        {
            SamplePlan = new HashSet<SamplePlan>();
        }

        public int TestId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SamplePlan> SamplePlan { get; set; }
    }
}
