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
            ShipAccountNavigation = new HashSet<ShipAccount>();
            ShipToNavigation = new HashSet<ShipTo>();
            SpecProcessAssign = new HashSet<SpecProcessAssign>();
        }

        public int CustId { get; set; }
        public string SearchName { get; set; }
        public string Name { get; set; }
        public byte? PriorityId { get; set; }
        public int? SalesPerson { get; set; }
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
        public short? DefaultShipViaId { get; set; }
        public int? DefaultContactNum { get; set; }
        public short? DefaultShipAccount { get; set; }
        public decimal? CreditLimit { get; set; }

        public virtual Certification Cert { get; set; }
        public virtual CreditStatus CredStatus { get; set; }
        public virtual Contact DefaultContactNumNavigation { get; set; }
        public virtual ShipViaCode DefaultShipVia { get; set; }
        public virtual Priority Priority { get; set; }
        public virtual Employee SalesPersonNavigation { get; set; }
        public virtual ShipAccount ShipAccount { get; set; }
        public virtual ShipTo ShipTo { get; set; }
        public virtual CustomerStatus Status { get; set; }
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
        public virtual ICollection<ShipAccount> ShipAccountNavigation { get; set; }
        public virtual ICollection<ShipTo> ShipToNavigation { get; set; }
        public virtual ICollection<SpecProcessAssign> SpecProcessAssign { get; set; }
    }
}
