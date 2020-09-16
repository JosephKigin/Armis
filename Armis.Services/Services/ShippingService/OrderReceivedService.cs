using Armis.BusinessModels.ShippingModels;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.ModelExtensions.ShippingExtensions;
using Armis.DataLogic.Services.ShippingService.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.ShippingService
{
    public class OrderReceivedService : IOrderReceivedService
    {
        private ARMISContext Context;

        public OrderReceivedService(ARMISContext aContext)
        {
            Context = aContext;
        }

        public async Task<OrderReceivedModel> CreateOrderReceived(OrderReceivedModel anOrderReceivedModel)
        {
            var entity = anOrderReceivedModel.ToEntity();
            var previousReceiveds = await Context.OrderReceived.Where(i => i.OrderId == anOrderReceivedModel.OrderId).ToListAsync();
            if (previousReceiveds == null || !previousReceiveds.Any())
            {
                entity.ReceivedNum = 1;
            }
            else
            {
                entity.ReceivedNum = (short)(previousReceiveds.Max(i => i.ReceivedNum) + 1);
            }

            Context.OrderReceived.Add(entity);
            await Context.SaveChangesAsync();

            return entity.ToModel();
        }

        public async Task<short> GetNextReceivedNumberForOrderId(int anOrderId)
        {
            var currentOrderReceivedEntities = await Context.OrderReceived.Where(i => i.OrderId == anOrderId).ToListAsync();
            if (currentOrderReceivedEntities == null || !currentOrderReceivedEntities.Any()) { return 1; } //Return 1 becuase the order number sent in does not have any order received entities yet.
            var result = (short)(currentOrderReceivedEntities.Max(i => i.ReceivedNum) + 1);

            return result;
        }

        public async Task<IEnumerable<OrderReceivedModel>> GetOrderReceivedsForOrderId(int anOrderId)
        {
            var entities = await Context.OrderReceived.Where(i => i.OrderId == anOrderId).ToListAsync();

            if (entities == null || !entities.Any()) { return null; }

            return entities.ToModels();
        }
    }
}
