using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class TernaryCode
    {
        public TernaryCode()
        {
            OrderHeadIsInspectedNavigation = new HashSet<OrderHead>();
            OrderHeadIsMaskingNotifyNavigation = new HashSet<OrderHead>();
            OrderHeadIsPrePriceNavigation = new HashSet<OrderHead>();
            OrderHeadIsPriceApprovalNavigation = new HashSet<OrderHead>();
        }

        public byte TernaryCodeId { get; set; }
        public string Code { get; set; }

        public virtual ICollection<OrderHead> OrderHeadIsInspectedNavigation { get; set; }
        public virtual ICollection<OrderHead> OrderHeadIsMaskingNotifyNavigation { get; set; }
        public virtual ICollection<OrderHead> OrderHeadIsPrePriceNavigation { get; set; }
        public virtual ICollection<OrderHead> OrderHeadIsPriceApprovalNavigation { get; set; }
    }
}
