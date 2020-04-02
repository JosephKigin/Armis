using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class OrderHead
    {
        public OrderHead()
        {
            BakeResult = new HashSet<BakeResult>();
            Memo = new HashSet<Memo>();
            OrderDetail = new HashSet<OrderDetail>();
            OrderExpediteReworkOrderNavigation = new HashSet<OrderExpedite>();
            PartTran = new HashSet<PartTran>();
            PlateResult = new HashSet<PlateResult>();
        }

        public int OrderId { get; set; }
        public int? CustId { get; set; }
        public string Ponum { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? RecvDate { get; set; }
        public TimeSpan? RecvTime { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? PromiseDate { get; set; }
        public TimeSpan? PromiseTime { get; set; }
        public DateTime? ShipDate { get; set; }
        public TimeSpan? ShipTime { get; set; }
        public DateTime? ReqDate { get; set; }
        public DateTime? DoneDate { get; set; }
        public TimeSpan? DoneTime { get; set; }
        public DateTime? TargetDate { get; set; }
        public string PriceStatus { get; set; }
        public bool? IsPriceHold { get; set; }
        public bool? IsBadJob { get; set; }
        public bool? IsJobHold { get; set; }
        public short? JobHoldToEmp { get; set; }
        public short? JobHoldByEmp { get; set; }
        public string QualStdCd { get; set; }
        public DateTime? LastCompleteRemSentDt { get; set; }
        public bool? IsMaskingNotify { get; set; }
        public string PackagingCd { get; set; }
        public int? SpecId { get; set; }
        public short? SpecRevId { get; set; }
        public short? SpecAssignId { get; set; }
        public string ShipViaCd { get; set; }
        public bool? IsPriceApproval { get; set; }
        public bool? IsReturnAsIs { get; set; }
        public bool? IsPrePrice { get; set; }
        public short? CreditAuthByEmp { get; set; }
        public bool? IsInspected { get; set; }
        public decimal? LotCharge { get; set; }
        public decimal? SubTotal { get; set; }
        public byte? CertId { get; set; }
        public string ShipChargeCd { get; set; }
        public string HandlingChargeCd { get; set; }
        public string MiscChargeCd { get; set; }
        public string ExpediteStatus { get; set; }

        public virtual Certification Cert { get; set; }
        public virtual Employee CreditAuthByEmpNavigation { get; set; }
        public virtual Customer Cust { get; set; }
        public virtual Status ExpediteStatusNavigation { get; set; }
        public virtual HandlingCharge HandlingChargeCdNavigation { get; set; }
        public virtual Employee JobHoldByEmpNavigation { get; set; }
        public virtual Employee JobHoldToEmpNavigation { get; set; }
        public virtual MiscCharge MiscChargeCdNavigation { get; set; }
        public virtual PackageCode PackagingCdNavigation { get; set; }
        public virtual QualityStandard QualStdCdNavigation { get; set; }
        public virtual ShipCharge ShipChargeCdNavigation { get; set; }
        public virtual ShipVia ShipViaCdNavigation { get; set; }
        public virtual SpecProcessAssign Spec { get; set; }
        public virtual OrderExpedite OrderExpediteOrder { get; set; }
        public virtual ICollection<BakeResult> BakeResult { get; set; }
        public virtual ICollection<Memo> Memo { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<OrderExpedite> OrderExpediteReworkOrderNavigation { get; set; }
        public virtual ICollection<PartTran> PartTran { get; set; }
        public virtual ICollection<PlateResult> PlateResult { get; set; }
    }
}
