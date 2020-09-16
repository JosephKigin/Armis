using Armis.BusinessModels.ShippingModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.ShippingService.Interfaces
{
    public interface IOrderReceivedService
    {
        Task<short> GetNextReceivedNumberForOrderId(int anOrderId);
        Task<OrderReceivedModel> CreateOrderReceived(OrderReceivedModel anOrderReceivedModel);
        Task<IEnumerable<OrderReceivedModel>> GetOrderReceivedsForOrderId(int anOrderId);
    }
}
