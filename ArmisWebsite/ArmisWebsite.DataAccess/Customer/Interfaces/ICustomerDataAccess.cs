using Armis.BusinessModels.Customer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Customer.Interfaces
{
    public interface ICustomerDataAccess
    {
        Task<IEnumerable<CustomerModel>> GetAllCustomers();
    }
}
