using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Specification
    {
        public Specification()
        {
            Certification = new HashSet<Certification>();
            DeptSpecs = new HashSet<DeptSpecs>();
            OrderHead = new HashSet<OrderHead>();
        }

        public int SpecId { get; set; }
        public string Description { get; set; }
        public string CurrentRev { get; set; }
        public string SamplePlan { get; set; }
        public bool? IsPartSpecificPlan { get; set; }
        public string NadCapSamplePlan { get; set; }
        public string Alias { get; set; }

        public virtual ICollection<Certification> Certification { get; set; }
        public virtual ICollection<DeptSpecs> DeptSpecs { get; set; }
        public virtual ICollection<OrderHead> OrderHead { get; set; }
    }
}
