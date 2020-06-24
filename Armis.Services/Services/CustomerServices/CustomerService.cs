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
using Z.EntityFramework.Plus;

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

        public async Task<IEnumerable<CustomerModel>> GetAllHydratedCustomers()
        {
            var entities = await context.Customer.IncludeOptimized(i => i.CertCharge)
                                                 .IncludeOptimized(i => i.CredStatus)
                                                 .Include(i => i.DefaultContactNumNavigation).ThenInclude(i => i.Title)
                                                 .IncludeOptimized(i => i.DefaultShipVia)
                                                 .IncludeOptimized(i => i.SalesPersonNavigation)
                                                 .IncludeOptimized(i => i.ShipTo)
                                                 .IncludeOptimized(i => i.Status)
                                                 .ToListAsync();

            if(entities == null || !entities.Any()) { throw new Exception("No customers were returned"); }

            return entities.ToHydratedModels();
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
