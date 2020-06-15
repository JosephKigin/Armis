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
        Task<IEnumerable<OrderHeadModel>> GetAllOrderHeads();
        Task<IEnumerable<OrderHeadModel>> GetAllHydratedOrderHeads();
        Task<OrderHeadModel> GetHydratedOrderHeadById(int anOrderId);
        Task<OrderHeadModel> PostOrderHead(OrderHeadModel anOrderHeadModel);
    }
}
