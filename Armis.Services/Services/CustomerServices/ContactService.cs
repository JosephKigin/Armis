using Armis.BusinessModels.CustomerModels;
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
    public class ContactService : IContactService
    {
        private ARMISContext Context;

        public ContactService(ARMISContext aContext)
        {
            Context = aContext;
        }

        public async Task<IEnumerable<ContactModel>> GetAllHydratedContacts()
        {
            var entities = await Context.Contact.Include(i => i.Title).ToListAsync();

            if(entities == null || !entities.Any()) { throw new Exception("No Contacts returned"); }

            return entities.ToHydratedModels();
        }

        public async Task<IEnumerable<ContactModel>> GetAllHydratedContactsByCustomer(int customerId)
        {
            var entities = await Context.Contact.Where(i => i.CustId == customerId).IncludeOptimized(i => i.Title).ToListAsync();

            if (entities == null || !entities.Any()) { throw new Exception("No Contacts found for that customer"); }

            return entities.ToHydratedModels();
        }
    }
}
