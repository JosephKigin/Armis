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
using Z.EntityFramework.Plus;

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
        public async Task<IEnumerable<OrderHeadModel>> GetAllOrderHeads()
        {
            Context.OrderDetail.Load();
            var orderHeadEntities = await Context.OrderHead.ToListAsync();

            return orderHeadEntities.ToModels();
        }

        public async Task<IEnumerable<OrderHeadModel>> GetAllHydratedOrderHeads()
        {
            var orderHeadEntities = await Context.OrderHead.IncludeOptimized(i => i.CertCharge)
                                                           .IncludeOptimized(i => i.CreditAuthByEmpNavigation)
                                                           .IncludeOptimized(i => i.Cust)
                                                           .IncludeOptimized(i => i.IsInspectedNavigation)
                                                           .IncludeOptimized(i => i.IsMaskingNotifyNavigation)
                                                           .IncludeOptimized(i => i.IsPrePriceNavigation)
                                                           .IncludeOptimized(i => i.IsPriceApprovalNavigation)
                                                           .IncludeOptimized(i => i.JobHoldByEmpNavigation)
                                                           .IncludeOptimized(i => i.JobHoldToEmpNavigation)
                                                           .IncludeOptimized(i => i.Package)
                                                           .IncludeOptimized(i => i.PriceStatus)
                                                           .IncludeOptimized(i => i.QualStd)
                                                           .IncludeOptimized(i => i.ShipVia)
                                                           .IncludeOptimized(i => i.Spec)
                                                           .IncludeOptimized(i => i.OrderComment)
                                                           .IncludeOptimized(i => i.OrderExpediteOrder)
                                                           .IncludeOptimized(i => i.OrderShipToOverride)
                                                           .IncludeOptimized(i => i.OrderDetail).ToListAsync();

            return orderHeadEntities.ToHydratedModels();
        }

        public async Task<OrderHeadModel> GetHydratedOrderHeadById(int anOrderId)
        {
            await Context.TernaryCode.LoadAsync();
            var orderHeadEntity = await Context.OrderHead.Where(i => i.OrderId == anOrderId)
                                                           .IncludeOptimized(i => i.CertCharge)
                                                           .IncludeOptimized(i => i.CreditAuthByEmpNavigation)
                                                           .IncludeOptimized(i => i.Cust)
                                                           .IncludeOptimized(i => i.IsInspectedNavigation)
                                                           .IncludeOptimized(i => i.IsMaskingNotifyNavigation)
                                                           .IncludeOptimized(i => i.IsPrePriceNavigation)
                                                           .IncludeOptimized(i => i.IsPriceApprovalNavigation)
                                                           .IncludeOptimized(i => i.JobHoldByEmpNavigation)
                                                           .IncludeOptimized(i => i.JobHoldToEmpNavigation)
                                                           .IncludeOptimized(i => i.Package)
                                                           .IncludeOptimized(i => i.PriceStatus)
                                                           .IncludeOptimized(i => i.QualStd)
                                                           .IncludeOptimized(i => i.ShipVia)
                                                           .IncludeOptimized(i => i.OrderComment)
                                                           .IncludeOptimized(i => i.OrderExpediteOrder)
                                                           .IncludeOptimized(i => i.OrderShipToOverride)
                                                           .FirstOrDefaultAsync();

            if (orderHeadEntity == null) { return null; } //throw new Exception("No Order was found"); }

            orderHeadEntity.OrderDetail = await Context.OrderDetail.Where(i => i.OrderId == orderHeadEntity.OrderId).Include(i => i.OrderLocation).Include(i => i.Part).Include(i => i.PriceCode).ToListAsync();

            orderHeadEntity.OrderReceived = await Context.OrderReceived.Where(i => i.OrderId == orderHeadEntity.OrderId).Include(i => i.ReceivedContainer).ToListAsync();

            orderHeadEntity.Spec = await Context.SpecProcessAssign.Where(i => i.SpecId == orderHeadEntity.SpecId && i.SpecRevId == orderHeadEntity.SpecRevId && i.SpecAssignId == orderHeadEntity.SpecAssignId)
                                                                  .Include(i => i.Process).ThenInclude(i => i.Process)
                                                                  .Include(i => i.Spec).ThenInclude(i=>i.SpecSubLevel).FirstOrDefaultAsync();

            orderHeadEntity.Spec.SpecProcessAssignOption = await Context.SpecProcessAssignOption.Where(i => i.SpecId == orderHeadEntity.Spec.SpecId && i.SpecRevId == orderHeadEntity.SpecRevId && i.SpecAssignId == orderHeadEntity.Spec.SpecAssignId)
                                                                                                .IncludeOptimized(i => i.SpecChoice).ToListAsync();

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
