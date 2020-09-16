using Armis.BusinessModels.ShippingModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Shipping.Interfaces
{
    public interface IOrderReceivedDataAccess
    {
        Task<short> GetNextReceivedNumberForOrderId(int anOrderId);
        Task<OrderReceivedModel> CreateOrderReceived(OrderReceivedModel anOrderReceivedModel);
    }
}
