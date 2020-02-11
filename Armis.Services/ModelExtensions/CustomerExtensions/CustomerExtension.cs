using Armis.BusinessModels.Customer;
using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext.Entities;
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
                Id = aCustomer.CustId,
                Status = aCustomer.Status,
                CreatedDate = aCustomer.CreatedDate
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

    }
}
