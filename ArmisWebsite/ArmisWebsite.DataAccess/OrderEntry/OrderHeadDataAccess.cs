using Armis.BusinessModels.OrderEntryModels;
using Armis.BusinessModels.PartModels;
using ArmisWebsite.DataAccess.OrderEntry.Interfaces;
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

        public OrderHeadDataAccess(IConfiguration aConfig)
        {
            Config = aConfig;
        }

        public async Task<OrderHeadModel> GetOrderHeadById(int anOrderId)
        {
            var result = await DataAccessGeneric.HttpGetRequest<OrderHeadModel>(Config["APIAddress"] + "api/OrderHead/GetHydratedOrderHead/" + anOrderId);
            return result;
        }

        //public Task<OrderHeadModel> GetHydratedOrderHeadById(int anOrderId)
        //{
        //    return await DataAccessGeneric.HttpGetRequest<OrderHeadModel>(Config["APIAddress"] + "api/OrderHead/")
        //}

        public async Task<OrderHeadModel> PostOrderHead(OrderHeadModel anOrderHeadModel)
        {
            return await DataAccessGeneric.HttpPostRequest<OrderHeadModel>(Config["APIAddress"] + "api/processes/postprocess", anOrderHeadModel);
        }
    }
}
