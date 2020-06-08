using Armis.BusinessModels.OrderEntryModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.OrderEntryServices.Interfaces
{
    public interface IOrderHeadService
    {
        Task<IEnumerable<OrderHead>> GetAllOrderHeads(); //TODO: This should return a model, not an entity.  This was created like this initially for testing purposes.
    }
}
