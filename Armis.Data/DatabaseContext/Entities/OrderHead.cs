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
            PartHist = new HashSet<PartHist>();
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
        public string JobHoldComments { get; set; }
        public string QualStdCd { get; set; }
        public DateTime? LastCompleteRemSentDt { get; set; }
        public bool? IsMaskingNotify { get; set; }
        public string HardnessCd { get; set; }
        public string PackagingCd { get; set; }
        public int? SpecId { get; set; }
        public string ShipViaCd { get; set; }
        public string MaterialAlloyCd { get; set; }
        public int? ProcessId { get; set; }
        public int? ProcessRevId { get; set; }
        public bool? IsPriceApproval { get; set; }
        public bool? IsReturnAsIs { get; set; }
        public string Raicomments { get; set; }
        public bool? IsPrePrice { get; set; }
        public string CredAuthComments { get; set; }
        public short? CreditAuthByEmp { get; set; }
        public string VoidComments { get; set; }
        public bool? IsInspected { get; set; }
        public decimal? LotCharge { get; set; }
        public string OrderComments { get; set; }
        public decimal? SubTotal { get; set; }
        public string CertCd { get; set; }
        public string ShipChargeCd { get; set; }
        public string HandlingChargeCd { get; set; }
        public string MiscChargeCd { get; set; }
        public string Stname { get; set; }
        public string Staddress1 { get; set; }
        public string Staddress2 { get; set; }
        public string Staddress3 { get; set; }
        public string Stcity { get; set; }
        public string Ststate { get; set; }
        public string Stzip { get; set; }
        public string Stphone { get; set; }
        public string Stattn { get; set; }
        public string ExpediteStatus { get; set; }

        public virtual Certification CertCdNavigation { get; set; }
        public virtual Employee CreditAuthByEmpNavigation { get; set; }
        public virtual Customer Cust { get; set; }
        public virtual Status ExpediteStatusNavigation { get; set; }
        public virtual HandlingCharge HandlingChargeCdNavigation { get; set; }
        public virtual Hardness HardnessCdNavigation { get; set; }
        public virtual Employee JobHoldByEmpNavigation { get; set; }
        public virtual Employee JobHoldToEmpNavigation { get; set; }
        public virtual MaterialAlloy MaterialAlloyCdNavigation { get; set; }
        public virtual MiscCharge MiscChargeCdNavigation { get; set; }
        public virtual PackageCode PackagingCdNavigation { get; set; }
        public virtual ProcessRevision Process { get; set; }
        public virtual QualityStandard QualStdCdNavigation { get; set; }
        public virtual ShipCharge ShipChargeCdNavigation { get; set; }
        public virtual ShipVia ShipViaCdNavigation { get; set; }
        public virtual Specification Spec { get; set; }
        public virtual OrderExpedite OrderExpediteOrder { get; set; }
        public virtual ICollection<BakeResult> BakeResult { get; set; }
        public virtual ICollection<Memo> Memo { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<OrderExpedite> OrderExpediteReworkOrderNavigation { get; set; }
        public virtual ICollection<PartHist> PartHist { get; set; }
        public virtual ICollection<PlateResult> PlateResult { get; set; }
    }
}
