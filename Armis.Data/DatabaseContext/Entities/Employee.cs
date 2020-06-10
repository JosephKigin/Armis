using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            BakeResultStartedByEmpNavigation = new HashSet<BakeResult>();
            BakeResultStoppedByEmpNavigation = new HashSet<BakeResult>();
            Customer = new HashSet<Customer>();
            OrderExpediteApprovedByEmpNavigation = new HashSet<OrderExpedite>();
            OrderExpediteExpeditedByEmpNavigation = new HashSet<OrderExpedite>();
            OrderHeadCreditAuthByEmpNavigation = new HashSet<OrderHead>();
            OrderHeadJobHoldByEmpNavigation = new HashSet<OrderHead>();
            OrderHeadJobHoldToEmpNavigation = new HashSet<OrderHead>();
            Part = new HashSet<Part>();
            PlateResult = new HashSet<PlateResult>();
            ProcessRevision = new HashSet<ProcessRevision>();
            Session = new HashSet<Session>();
            SpecialHandlingHoldJobForEmpNavigation = new HashSet<SpecialHandling>();
            SpecialHandlingNotifyEmpNavigation = new HashSet<SpecialHandling>();
            SpecialHandlingReviewReqByEmpNavigation = new HashSet<SpecialHandling>();
            SpecialHandlingSpecialPrintByEmpNavigation = new HashSet<SpecialHandling>();
            SpecificationRevision = new HashSet<SpecificationRevision>();
        }

        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte? DefaultShift { get; set; }
        public bool Inactive { get; set; }
        public bool IsPriceTraining { get; set; }
        public bool IsShippingLogin { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNum { get; set; }
        public string ExtUserId { get; set; }
        public bool CanExpedite { get; set; }
        public short? AreaId { get; set; }

        public virtual Area Area { get; set; }
        public virtual ICollection<BakeResult> BakeResultStartedByEmpNavigation { get; set; }
        public virtual ICollection<BakeResult> BakeResultStoppedByEmpNavigation { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<OrderExpedite> OrderExpediteApprovedByEmpNavigation { get; set; }
        public virtual ICollection<OrderExpedite> OrderExpediteExpeditedByEmpNavigation { get; set; }
        public virtual ICollection<OrderHead> OrderHeadCreditAuthByEmpNavigation { get; set; }
        public virtual ICollection<OrderHead> OrderHeadJobHoldByEmpNavigation { get; set; }
        public virtual ICollection<OrderHead> OrderHeadJobHoldToEmpNavigation { get; set; }
        public virtual ICollection<Part> Part { get; set; }
        public virtual ICollection<PlateResult> PlateResult { get; set; }
        public virtual ICollection<ProcessRevision> ProcessRevision { get; set; }
        public virtual ICollection<Session> Session { get; set; }
        public virtual ICollection<SpecialHandling> SpecialHandlingHoldJobForEmpNavigation { get; set; }
        public virtual ICollection<SpecialHandling> SpecialHandlingNotifyEmpNavigation { get; set; }
        public virtual ICollection<SpecialHandling> SpecialHandlingReviewReqByEmpNavigation { get; set; }
        public virtual ICollection<SpecialHandling> SpecialHandlingSpecialPrintByEmpNavigation { get; set; }
        public virtual ICollection<SpecificationRevision> SpecificationRevision { get; set; }
    }
}
