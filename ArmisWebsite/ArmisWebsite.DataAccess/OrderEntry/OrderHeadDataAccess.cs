using Armis.BusinessModels.OrderEntryModels;
using Armis.BusinessModels.PartModels;
using ArmisWebsite.DataAccess.OrderEntry.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.OrderEntry
{
    public class OrderHeadDataAccess : IOrderHeadDataAccess
    {
        private IConfiguration Config;
        private IHttpContextAccessor _httpContextAccessor;

        public OrderHeadDataAccess(IConfiguration aConfig, IHttpContextAccessor aHttpContextAccessor)
        {
            Config = aConfig;
            _httpContextAccessor = aHttpContextAccessor;
        }

        public async Task<OrderHeadModel> GetOrderHeadById(int anOrderId)
        {
            var result = await DataAccessGeneric.HttpGetRequest<OrderHeadModel>(Config["APIAddress"] + "api/OrderHead/GetHydratedOrderHead/" + anOrderId, _httpContextAccessor.HttpContext);
            return result;
        }

        //public Task<OrderHeadModel> GetHydratedOrderHeadById(int anOrderId)
        //{
        //    return await DataAccessGeneric.HttpGetRequest<OrderHeadModel>(Config["APIAddress"] + "api/OrderHead/")
        //}

        public async Task<OrderHeadModel> PostOrderHead(OrderHeadModel anOrderHeadModel)
        {
            return await DataAccessGeneric.HttpPostRequest<OrderHeadModel>(Config["APIAddress"] + "api/processes/postprocess", anOrderHeadModel, _httpContextAccessor.HttpContext);
        }
    }
}
