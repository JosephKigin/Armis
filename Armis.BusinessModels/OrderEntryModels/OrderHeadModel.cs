using Armis.BusinessModels.ARModels;
using Armis.BusinessModels.Customer;
using Armis.BusinessModels.EmployeeModels;
using Armis.BusinessModels.QualityModels.InspectionModels;
using Armis.BusinessModels.QualityModels.Spec;
using Armis.BusinessModels.ShippingModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.OrderEntryModels
{
    public class OrderHeadModel
    {
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
        //public byte IsMaskingNotify { get; set; }
        public short? PackageId { get; set; }
        public int SpecId { get; set; }
        public short SpecRevId { get; set; }
        public int SpecAssignId { get; set; }
        public short? ShipViaId { get; set; }
        //public byte IsPriceApproval { get; set; }
        public bool IsReturnAsIs { get; set; }
        //public byte IsPrePrice { get; set; }
        public int? CreditAuthByEmp { get; set; }
        //public byte IsInspected { get; set; }
        public decimal SubTotal { get; set; }
        public string ExpediteStatus { get; set; }

        public CertificationChargeModel CertCharge { get; set; }
        public EmployeeModel CreditAuthByEmployee { get; set; }
        public CustomerModel Customer { get; set; }
        public AdditionalChargeModel HandlingCharge { get; set; }
        //ToDo: Should these be two properties where one is the data on the order head table and the other is the entry from the TernaryCode table?
        public TernaryCodeModel IsInspected { get; set; } 
        public TernaryCodeModel IsMaskingNotify { get; set; }
        public TernaryCodeModel IsPrePrice { get; set; }
        public TernaryCodeModel IsPriceApproval { get; set; }
        //End To Do
        public EmployeeModel JobHoldByEmployee { get; set; }
        public EmployeeModel JobHoldToEmployee { get; set; }
        public AdditionalChargeModel MiscCharge { get; set; }
        public PackageCodeModel Package { get; set; }
        public PriceStatusCodeModel PriceStatus { get; set; }
        public QualityStandardModel QualityStandard { get; set; }
        public AdditionalChargeModel ShipCharge { get; set; }
        public ShipViaCodeModel ShipVia { get; set; }
        public SpecProcessAssignModel Spec { get; set; }
        public OrderCommentModel OrderComment { get; set; }
        public OrderExpediteModel OrderExpedite { get; set; }
        public OrderShipToOverrideModel OrderShipToOverride { get; set; }

        public IEnumerable<OrderDetailModel> OrderDetails { get; set; } //Each part, or "line", on the order
    }
}
