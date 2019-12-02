using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Contact = new HashSet<Contact>();
            Driver = new HashSet<Driver>();
            Memo = new HashSet<Memo>();
            NotifyContact = new HashSet<NotifyContact>();
            OprLoadPrice = new HashSet<OprLoadPrice>();
            OprMaterialPrice = new HashSet<OprMaterialPrice>();
            OprThickPrice = new HashSet<OprThickPrice>();
            OrderHead = new HashSet<OrderHead>();
            Part = new HashSet<Part>();
            Process = new HashSet<Process>();
            SamplePlan = new HashSet<SamplePlan>();
            ShipAccountNavigation = new HashSet<ShipAccount>();
        }

        public int CustId { get; set; }
        public string SearchName { get; set; }
        public short? SalesPerson { get; set; }
        public string Status { get; set; }
        public string DefaultShipVia { get; set; }
        public bool? IsInspectAll { get; set; }
        public bool? IsPrePriceAll { get; set; }
        public string TaxExemptNum { get; set; }
        public decimal? PriceIncreasePerc { get; set; }
        public decimal? MinIncreasePerc { get; set; }
        public int? LeadTime { get; set; }
        public int? TaxJurisdId { get; set; }
        public bool? IsChargeHandling { get; set; }
        public string CreditStatus { get; set; }
        public DateTime? NoCredHoldUntil { get; set; }
        public string CertCd { get; set; }
        public bool? IsKioskValid { get; set; }
        public string Source { get; set; }
        public string TermsCd { get; set; }
        public bool? IsBillRework { get; set; }
        public bool? IsTmcustomer { get; set; }
        public bool? IsStopReminders { get; set; }
        public bool? IsBillPartialShipments { get; set; }
        public bool? IsSendPartialCerts { get; set; }
        public bool? IsBillPartialCerts { get; set; }
        public bool? IsIgnoreDupePos { get; set; }
        public short? DefaultShipToId { get; set; }
        public byte? FreeExpPerMonth { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string PhoneNum { get; set; }
        public string FaxNum { get; set; }
        public string DefaultShipViaCd { get; set; }
        public int? DefaultContactNum { get; set; }
        public byte? DefaultShipAccount { get; set; }
        public decimal? CreditLimit { get; set; }

        public virtual Certification CertCdNavigation { get; set; }
        public virtual Status CreditStatusNavigation { get; set; }
        public virtual Contact DefaultContactNumNavigation { get; set; }
        public virtual ShipVia DefaultShipViaCdNavigation { get; set; }
        public virtual ShipVia DefaultShipViaNavigation { get; set; }
        public virtual Employee SalesPersonNavigation { get; set; }
        public virtual ShipAccount ShipAccount { get; set; }
        public virtual ShipTo ShipTo { get; set; }
        public virtual Status StatusNavigation { get; set; }
        public virtual TaxJurisdiction TaxJurisd { get; set; }
        public virtual Terms TermsCdNavigation { get; set; }
        public virtual ICollection<Contact> Contact { get; set; }
        public virtual ICollection<Driver> Driver { get; set; }
        public virtual ICollection<Memo> Memo { get; set; }
        public virtual ICollection<NotifyContact> NotifyContact { get; set; }
        public virtual ICollection<OprLoadPrice> OprLoadPrice { get; set; }
        public virtual ICollection<OprMaterialPrice> OprMaterialPrice { get; set; }
        public virtual ICollection<OprThickPrice> OprThickPrice { get; set; }
        public virtual ICollection<OrderHead> OrderHead { get; set; }
        public virtual ICollection<Part> Part { get; set; }
        public virtual ICollection<Process> Process { get; set; }
        public virtual ICollection<SamplePlan> SamplePlan { get; set; }
        public virtual ICollection<ShipAccount> ShipAccountNavigation { get; set; }
    }
}
