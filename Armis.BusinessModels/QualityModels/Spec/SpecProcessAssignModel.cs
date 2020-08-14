using Armis.BusinessModels.Customer;
using Armis.BusinessModels.PartModels;
using Armis.BusinessModels.QualityModels.Process;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.QualityModels.Spec
{

    public class SpecProcessAssignModel
    {
        public int SpecId { get; set; }
        public short SpecRevId { get; set; }
        public int SpecAssignId { get; set; }
        public int? CustomerId { get; set; }
        public int ProcessId { get; set; }
        public int ProcessRevId { get; set; }
        public bool Inactive { get; set; }
        public bool IsReviewNeeded { get; set; }
        public bool? IsViable { get; set; } //This will only be used at the review page to check if the spec was revved up.  If it was, then the SPA is not viable.

        public CustomerModel Customer { get; set; }
        public ProcessRevisionModel ProcessRevision { get; set; }
        public SpecRevModel SpecificationRevision { get; set; }
        public List<SpecProcessAssignOptionModel> SpecProcessAssignOptionModels { get; set; }
    }
}
