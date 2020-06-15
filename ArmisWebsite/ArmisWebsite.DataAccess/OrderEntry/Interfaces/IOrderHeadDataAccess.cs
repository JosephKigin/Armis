using Armis.BusinessModels.OrderEntryModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.OrderEntry.Interfaces
{
    public interface IOrderHeadDataAccess
    {
        Task<OrderHeadModel> GetOrderHeadById(int anOrderId);
        Task<OrderHeadModel> PostOrderHead(OrderHeadModel anOrderHeadModel);
    }
}
