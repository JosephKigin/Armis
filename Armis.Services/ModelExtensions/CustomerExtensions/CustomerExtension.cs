using Armis.BusinessModels.Customer;
using Armis.BusinessModels.QualityModels;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.ModelExtensions.ARExtensions;
using Armis.DataLogic.ModelExtensions.EmployeeExtensions;
using Armis.DataLogic.ModelExtensions.ShippingExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.CustomerExtensions
{
    public static class CustomerExtension
    {
        public static CustomerModel ToModel(this Customer aCustomer)
        {
            return new CustomerModel()
            {
                Name = aCustomer.Name,
                SearchName = aCustomer.SearchName,
                CustId = aCustomer.CustId,
                CreatedDate = aCustomer.CreatedDate,
                PriorityId = aCustomer.PriorityId,
                SalesPersonId = aCustomer.SalesPerson,
                IsInspectAll = aCustomer.IsInspectAll,
                IsPrePriceAll = aCustomer.IsPrePriceAll,
                TaxExemptNum = aCustomer.TaxExemptNum,
                PriceIncreasePerc = aCustomer.PriceIncreasePerc,
                MinIncreasePerc = aCustomer.MinIncreasePerc,
                LeadTime = aCustomer.LeadTime,
                TaxJurisdId = aCustomer.TaxJurisdId,
                IsChargeHandling = aCustomer.IsChargeHandling,
                CredStatusId = aCustomer.CredStatusId,
                LeaveOffCredHoldUntil = aCustomer.LeaveOffCredHoldUntil,
                DefaultCertCharge = aCustomer.DefaultCertCharge,
                IsKioskValid = aCustomer.IsKioskValid,
                Source = aCustomer.Source,
                TermsId = aCustomer.TermsId,
                IsBilledRework = aCustomer.IsBilledRework,
                IsTmcustomer = aCustomer.IsTmcustomer,
                SendReminderComp = aCustomer.SendReminderComp,
                IsBillPartialShipments = aCustomer.IsBillPartialShipments,
                IsSendPartialCerts = aCustomer.IsSendPartialCerts,
                IsBillPartialCerts = aCustomer.IsBillPartialCerts,
                IsIgnoreDupePos = aCustomer.IsIgnoreDupePos,
                DefaultShipToId = aCustomer.DefaultShipToId,
                FreeExpPerMonth = aCustomer.FreeExpPerMonth,
                DefaultShipViaId = aCustomer.DefaultShipViaId,
                DefaultContactNum = aCustomer.DefaultContactNum,
                DefaultShipAccount = aCustomer.DefaultShipAccount,
                CreditLimit = aCustomer.CreditLimit,
                Inactive = aCustomer.Inactive,
                IsProspect = aCustomer.IsProspect
            };

        }

        public static IEnumerable<CustomerModel> ToModels(this IEnumerable<Customer> aCustomers)
        {
            var result = new List<CustomerModel>();

            foreach (var customer in aCustomers)
            {
                result.Add(customer.ToModel());
            }

            return result;
        }

        public static CustomerModel ToHydratedModel(this Customer aCustomer)
        {
            var result = aCustomer.ToModel();

            result.CertCharge = (aCustomer.DefaultCertChargeNavigation != null) ? aCustomer.DefaultCertChargeNavigation.ToModel() : null;
            result.CreditStatus = (aCustomer.CredStatus != null) ? aCustomer.CredStatus.ToModel() : null;
            result.DefaultContact = (aCustomer.DefaultContactNumNavigation != null) ? aCustomer.DefaultContactNumNavigation.ToModel() : null;
            result.DefaultShipVia = (aCustomer.DefaultShipVia != null) ? aCustomer.DefaultShipVia.ToModel() : null;
            result.SalesPerson = (aCustomer.SalesPersonNavigation != null) ? aCustomer.SalesPersonNavigation.ToModel() : null;
            result.DefaultShipTo = (aCustomer.ShipTo != null) ? aCustomer.ShipTo.ToModel() : null;
            result.BillTo = (aCustomer.CustBillTo != null) ? aCustomer.CustBillTo.ToModel() : null;

            return result;
        }

        public static IEnumerable<CustomerModel> ToHydratedModels(this IEnumerable<Customer> aCustomerEntities)
        {
            var result = new List<CustomerModel>();

            foreach (var entity in aCustomerEntities)
            {
                result.Add(entity.ToHydratedModel());
            }

            return result;
        }

    }
}
