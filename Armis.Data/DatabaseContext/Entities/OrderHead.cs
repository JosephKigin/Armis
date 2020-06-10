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
            OrderAddlCharge = new HashSet<OrderAddlCharge>();
            OrderCommentStatic = new HashSet<OrderCommentStatic>();
            OrderDetail = new HashSet<OrderDetail>();
            OrderDetailComment = new HashSet<OrderDetailComment>();
            OrderExpediteReworkOrderNavigation = new HashSet<OrderExpedite>();
            OrderReceived = new HashSet<OrderReceived>();
            PartTran = new HashSet<PartTran>();
            PlateResult = new HashSet<PlateResult>();
        }

        public int OrderId { get; set; }
        public int? CustId { get; set; }
        public string Ponum { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public TimeSpan? ShipTime { get; set; }
        public DateTime? ReqDate { get; set; }
        public DateTime? DoneDate { get; set; }
        public TimeSpan? DoneTime { get; set; }
        public DateTime? TargetDate { get; set; }
        public byte PriceStatusId { get; set; }
        public bool IsPriceHold { get; set; }
        public bool IsBadJob { get; set; }
        public bool IsJobHold { get; set; }
        public int? JobHoldToEmp { get; set; }
        public int? JobHoldByEmp { get; set; }
        public short? QualStdId { get; set; }
        public short? CertChargeId { get; set; }
        public DateTime? LastCompleteRemSentDt { get; set; }
        public bool SuppressCompNotify { get; set; }
        public byte IsMaskingNotify { get; set; }
        public short? PackageId { get; set; }
        public int SpecId { get; set; }
        public short SpecRevId { get; set; }
        public int SpecAssignId { get; set; }
        public short? ShipViaId { get; set; }
        public byte IsPriceApproval { get; set; }
        public bool IsReturnAsIs { get; set; }
        public byte IsPrePrice { get; set; }
        public int? CreditAuthByEmp { get; set; }
        public byte IsInspected { get; set; }
        public decimal SubTotal { get; set; }
        public string ExpediteStatus { get; set; }

        public virtual CertificationCharge CertCharge { get; set; }
        public virtual Employee CreditAuthByEmpNavigation { get; set; }
        public virtual Customer Cust { get; set; }
        public virtual TernaryCode IsInspectedNavigation { get; set; }
        public virtual TernaryCode IsMaskingNotifyNavigation { get; set; }
        public virtual TernaryCode IsPrePriceNavigation { get; set; }
        public virtual TernaryCode IsPriceApprovalNavigation { get; set; }
        public virtual Employee JobHoldByEmpNavigation { get; set; }
        public virtual Employee JobHoldToEmpNavigation { get; set; }
        public virtual PackageCode Package { get; set; }
        public virtual PriceStatusCode PriceStatus { get; set; }
        public virtual QualityStandard QualStd { get; set; }
        public virtual ShipViaCode ShipVia { get; set; }
        public virtual SpecProcessAssign Spec { get; set; }
        public virtual OrderComment OrderComment { get; set; }
        public virtual OrderExpedite OrderExpediteOrder { get; set; }
        public virtual OrderShipToOverride OrderShipToOverride { get; set; }
        public virtual ICollection<BakeResult> BakeResult { get; set; }
        public virtual ICollection<Memo> Memo { get; set; }
        public virtual ICollection<OrderAddlCharge> OrderAddlCharge { get; set; }
        public virtual ICollection<OrderCommentStatic> OrderCommentStatic { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<OrderDetailComment> OrderDetailComment { get; set; }
        public virtual ICollection<OrderExpedite> OrderExpediteReworkOrderNavigation { get; set; }
        public virtual ICollection<OrderReceived> OrderReceived { get; set; }
        public virtual ICollection<PartTran> PartTran { get; set; }
        public virtual ICollection<PlateResult> PlateResult { get; set; }
    }
}
