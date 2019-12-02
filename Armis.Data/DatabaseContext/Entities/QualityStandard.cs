using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class QualityStandard
    {
        public QualityStandard()
        {
            Certification = new HashSet<Certification>();
            OrderHead = new HashSet<OrderHead>();
        }

        public string QualStdCd { get; set; }
        public string Qsdescription { get; set; }

        public virtual ICollection<Certification> Certification { get; set; }
        public virtual ICollection<OrderHead> OrderHead { get; set; }
    }
}
