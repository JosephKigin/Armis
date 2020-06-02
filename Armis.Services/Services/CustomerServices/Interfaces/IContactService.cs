using Armis.BusinessModels.CustomerModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.CustomerServices.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<ContactModel>> GetAllHydratedContacts();
        Task<IEnumerable<ContactModel>> GetAllHydratedContactsByCustomer(int customerId);
    }
}
