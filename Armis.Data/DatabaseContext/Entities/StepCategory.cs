using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class StepCategory
    {
        public StepCategory()
        {
            Step = new HashSet<Step>();
        }

        public short StepCategoryId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Step> Step { get; set; }
    }
}
