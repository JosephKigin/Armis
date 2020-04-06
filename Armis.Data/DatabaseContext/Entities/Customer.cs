using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Contact = new HashSet<Contact>();
            CustContNotify = new HashSet<CustContNotify>();
            Driver = new HashSet<Driver>();
            Memo = new HashSet<Memo>();
            OprLoadPrice = new HashSet<OprLoadPrice>();
            OprMaterialPrice = new HashSet<OprMaterialPrice>();
            OprThickPrice = new HashSet<OprThickPrice>();
            OrderHead = new HashSet<OrderHead>();
            SamplePlanHead = new HashSet<SamplePlanHead>();
            ShipAccountNavigation = new HashSet<ShipAccount>();
            ShipToNavigation = new HashSet<ShipTo>();
            SpecProcessAssign = new HashSet<SpecProcessAssign>();
        }

        public int CustId { get; set; }
        public string SearchName { get; set; }
        public string Name { get; set; }
        public byte? PriorityId { get; set; }
        public short? SalesPerson { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsInspectAll { get; set; }
        public bool? IsPrePriceAll { get; set; }
        public string TaxExemptNum { get; set; }
        public decimal? PriceIncreasePerc { get; set; }
        public decimal? MinIncreasePerc { get; set; }
        public int? LeadTime { get; set; }
        public int? TaxJurisdId { get; set; }
        public bool? IsChargeHandling { get; set; }
        public string CreditStatus { get; set; }
        public DateTime? LeaveOffCredHoldUntil { get; set; }
        public byte? CertId { get; set; }
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
        public string DefaultShipVia { get; set; }
        public int? DefaultContactNum { get; set; }
        public byte? DefaultShipAccount { get; set; }
        public decimal? CreditLimit { get; set; }

        public virtual Certification Cert { get; set; }
        public virtual CreditStatus CreditStatusNavigation { get; set; }
        public virtual Contact DefaultContactNumNavigation { get; set; }
        public virtual ShipVia DefaultShipViaNavigation { get; set; }
        public virtual Priority Priority { get; set; }
        public virtual Employee SalesPersonNavigation { get; set; }
        public virtual ShipAccount ShipAccount { get; set; }
        public virtual ShipTo ShipTo { get; set; }
        public virtual Status StatusNavigation { get; set; }
        public virtual TaxJurisdiction TaxJurisd { get; set; }
        public virtual Terms Terms { get; set; }
        public virtual CustBillTo CustBillTo { get; set; }
        public virtual CustComment CustComment { get; set; }
        public virtual CustForm CustForm { get; set; }
        public virtual ICollection<Contact> Contact { get; set; }
        public virtual ICollection<CustContNotify> CustContNotify { get; set; }
        public virtual ICollection<Driver> Driver { get; set; }
        public virtual ICollection<Memo> Memo { get; set; }
        public virtual ICollection<OprLoadPrice> OprLoadPrice { get; set; }
        public virtual ICollection<OprMaterialPrice> OprMaterialPrice { get; set; }
        public virtual ICollection<OprThickPrice> OprThickPrice { get; set; }
        public virtual ICollection<OrderHead> OrderHead { get; set; }
        public virtual ICollection<SamplePlanHead> SamplePlanHead { get; set; }
        public virtual ICollection<ShipAccount> ShipAccountNavigation { get; set; }
        public virtual ICollection<ShipTo> ShipToNavigation { get; set; }
        public virtual ICollection<SpecProcessAssign> SpecProcessAssign { get; set; }
    }
}
