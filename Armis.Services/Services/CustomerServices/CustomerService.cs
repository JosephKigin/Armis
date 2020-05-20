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
            var entities = await context.Customer.Include(i => i.Status).ToListAsync();

            if(entities == null)
            {
                throw new NullReferenceException("No customers returned");
            }

            return entities.ToModels();
        }

        public async Task<IEnumerable<CustomerModel>> GetAllCurrentAndProspectCustomers()
        {
            var entities = await context.Customer.Where(i => i.StatusId == 1 || i.StatusId == 3).ToListAsync();

            if(entities == null || !entities.Any())
            {
                throw new NullReferenceException("No customers returned");
            }

            return entities.ToModels();
        }
    }
}
