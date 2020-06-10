using Armis.BusinessModels.ARModels;
using Armis.BusinessModels.CustomerModels;
using Armis.BusinessModels.EmployeeModels;
using Armis.BusinessModels.ShippingModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.Customer
{
    public class CustomerModel
    {
        //TODO: This class was first created for a process creation screen and will need to be expanded upon later.
        public int CustId { get; set; }
        public string SearchName { get; set; }
        public string Name { get; set; }
        public byte? PriorityId { get; set; }
        public int? SalesPersonId { get; set; }
        public byte StatusId { get; set; } 
        public DateTime? CreatedDate { get; set; }
        public bool? IsInspectAll { get; set; }
        public bool? IsPrePriceAll { get; set; }
        public string TaxExemptNum { get; set; }
        public decimal? PriceIncreasePerc { get; set; }
        public decimal? MinIncreasePerc { get; set; }
        public int? LeadTime { get; set; }
        public int? TaxJurisdId { get; set; }
        public bool? IsChargeHandling { get; set; }
        public byte CredStatusId { get; set; }
        public DateTime? LeaveOffCredHoldUntil { get; set; }
        public short? CertChargeId { get; set; }
        public bool? IsKioskValid { get; set; }
        public string Source { get; set; }
        public byte? TermsId { get; set; }
        public bool? IsBillRework { get; set; }
        public bool? IsTmcustomer { get; set; }
        public bool? SendReminderComp { get; set; }
        public bool? IsBillPartialShipments { get; set; }
        public bool? IsSendPartialCerts { get; set; }
        public bool? IsBillPartialCerts { get; set; }
        public bool? IsIgnoreDupePos { get; set; }
        public short? DefaultShipToId { get; set; }
        public byte? FreeExpPerMonth { get; set; }
        public short? DefaultShipViaId { get; set; }
        public int? DefaultContactNum { get; set; }
        public short? DefaultShipAccount { get; set; }
        public decimal? CreditLimit { get; set; }

        //TODO: The properties that are commented out need models created for the type
        public CertificationChargeModel CertCharge { get; set; }
        public CreditStatusModel CreditStatus { get; set; }
        public ContactModel DefaultContact { get; set; }
        public ShipViaCodeModel DefaultShipVia { get; set; }
        //public PriorityModel Priority { get; set; }
        public EmployeeModel SalesPerson { get; set; }
        //public ShipAccountModel ShipAccount { get; set; }
        public ShipToModel DefaultShipTo { get; set; }
        public CustomerStatusModel CustomerStatus { get; set; }
        //public TaxJurisdictionModel TaxJurisd { get; set; }
        //public TermsModel Terms { get; set; }
        //public CustCommentModel CustComment { get; set; }
        //public CustFormModel CustFor { get; set; }
    }
}
