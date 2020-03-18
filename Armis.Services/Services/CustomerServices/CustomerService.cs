using Armis.BusinessModels.Customer;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.ModelExtensions.CustomerExtensions;
using Armis.DataLogic.Services.CustomerServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        private ARMISContext context;

        public CustomerService(ARMISContext aContext)
        {
            context = aContext;
        }

        public async Task<IEnumerable<CustomerModel>> GetAllCustomers()
        {
            var entities = await context.Customer.ToListAsync();

            if(entities == null)
            {
                throw new NullReferenceException("No customers available.");
            }

            return entities.ToModels();
        }
    }
}
