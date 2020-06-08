using Armis.BusinessModels.OrderEntryModels;
using Armis.Data.DatabaseContext;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.Services.OrderEntryServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.OrderEntryServices
{
    public class OrderHeadService : IOrderHeadService
    {
        private ARMISContext Context;

        public OrderHeadService(ARMISContext aContext)
        {
            Context = aContext;
        }

        public async Task<IEnumerable<OrderHead>> GetAllOrderHeads() //TODO: This should return a model, not an entity.  This was created like this initially for testing purposes.
        {
            Context.OrderDetail.Load();
            var orderHeadEntities = await Context.OrderHead.ToListAsync();

            return orderHeadEntities;
        }
    }
}
