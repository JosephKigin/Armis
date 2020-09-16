using Armis.BusinessModels.ShippingModels;
using ArmisWebsite.DataAccess.Shipping.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Shipping
{
    public class OrderReceivedDataAccess : IOrderReceivedDataAccess
    {
        private IConfiguration Config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderReceivedDataAccess(IConfiguration aConfig, IHttpContextAccessor aHttpContextAccessor)
        {
            Config = aConfig;
            _httpContextAccessor = aHttpContextAccessor;
        }

        public async Task<short> GetNextReceivedNumberForOrderId(int anOrderId)
        {
            return await DataAccessGeneric.HttpGetRequest<short>(Config["APIAddress"] + "api/OrderReceived/GetNextReceivedNumberForOrderId/" + anOrderId, _httpContextAccessor.HttpContext);
        }

        public async Task<OrderReceivedModel> CreateOrderReceived(OrderReceivedModel anOrderReceivedModel)
        {
            return await DataAccessGeneric.HttpPostRequest<OrderReceivedModel>(Config["APIAddress"] + "api/OrderReceived/CreateOrderReceived", anOrderReceivedModel, _httpContextAccessor.HttpContext);
        }
    }
}
