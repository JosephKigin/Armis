using Armis.BusinessModels.OrderEntryModels;
using Armis.Data.DatabaseContext;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.ModelExtensions.OrderEntryExtensions;
using Armis.DataLogic.Services.OrderEntryServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        //Get
        public async Task<IEnumerable<OrderHeadModel>> GetAllOrderHeads() //TODO: This should return a model, not an entity.  This was created like this initially for testing purposes.
        {
            Context.OrderDetail.Load();
            var orderHeadEntities = await Context.OrderHead.ToListAsync();

            return orderHeadEntities.ToModels();
        }

        public async Task<IEnumerable<OrderHeadModel>> GetAllHydratedOrderHeads() //This is a crazy long call... Probably shouldn't use it.
        {
            var orderHeadEntities = await Context.OrderHead.Include(i => i.CertCharge)
                                                           .Include(i => i.CreditAuthByEmpNavigation)
                                                           .Include(i => i.Cust)
                                                           .Include(i => i.IsInspectedNavigation)
                                                           .Include(i => i.IsMaskingNotifyNavigation)
                                                           .Include(i => i.IsPrePriceNavigation)
                                                           .Include(i => i.IsPriceApprovalNavigation)
                                                           .Include(i => i.JobHoldByEmpNavigation)
                                                           .Include(i => i.JobHoldToEmpNavigation)
                                                           .Include(i => i.Package)
                                                           .Include(i => i.PriceStatus)
                                                           .Include(i => i.QualStd)
                                                           .Include(i => i.ShipVia)
                                                           .Include(i => i.Spec)
                                                           .Include(i => i.OrderComment)
                                                           .Include(i => i.OrderExpediteOrder)
                                                           .Include(i => i.OrderShipToOverride)
                                                           .Include(i => i.OrderDetail).ToListAsync();

            return orderHeadEntities.ToHydratedModels();
        }

        public async Task<OrderHeadModel> GetHydratedOrderHeadById(int anOrderId) //ToDo: This call can take up to ~700ms at first, then ~80ms.  Maybe consider stripping some of the includes out?
        {
            var orderHeadEntity = await Context.OrderHead.Where(i => i.OrderId == anOrderId)
                                                           .Include(i => i.CertCharge)
                                                           .Include(i => i.CreditAuthByEmpNavigation)
                                                           .Include(i => i.Cust)
                                                           .Include(i => i.IsInspectedNavigation)
                                                           .Include(i => i.IsMaskingNotifyNavigation)
                                                           .Include(i => i.IsPrePriceNavigation)
                                                           .Include(i => i.IsPriceApprovalNavigation)
                                                           .Include(i => i.JobHoldByEmpNavigation)
                                                           .Include(i => i.JobHoldToEmpNavigation)
                                                           .Include(i => i.Package)
                                                           .Include(i => i.PriceStatus)
                                                           .Include(i => i.QualStd)
                                                           .Include(i => i.ShipVia)
                                                           .Include(i => i.OrderComment)
                                                           .Include(i => i.OrderExpediteOrder)
                                                           .Include(i => i.OrderShipToOverride)
                                                           .Include(i => i.OrderDetail).ThenInclude(i => i.OrderLocation)
                                                           .FirstOrDefaultAsync();

            if (orderHeadEntity == null) { return null; } //throw new Exception("No Order was found"); }
            
            orderHeadEntity.Spec = await Context.SpecProcessAssign.Where(i => i.SpecId == orderHeadEntity.SpecId && i.SpecRevId == orderHeadEntity.SpecRevId && i.SpecAssignId == orderHeadEntity.SpecAssignId)
                                                                  .Include(i => i.Process)
                                                                  .Include(i => i.Spec).FirstOrDefaultAsync();



            return orderHeadEntity.ToHydratedModel();
        }


        //Post
        public async Task<OrderHeadModel> PostOrderHead(OrderHeadModel anOrderHeadModel)
        {
            var theOrderHeadId = await Context.OrderHead.MaxAsync(i => i.OrderId) + 1;
            anOrderHeadModel.OrderId = theOrderHeadId;

            foreach (var orderDetail in anOrderHeadModel.OrderDetails) //Assigns the order id to all the orderDetails
            {
                orderDetail.OrderId = theOrderHeadId;
            }

            Context.Add(anOrderHeadModel.ToEntity());

            Context.AddRange(anOrderHeadModel.OrderDetails.ToEntities());

            await Context.SaveChangesAsync();

            return anOrderHeadModel;
        }
    }
}
