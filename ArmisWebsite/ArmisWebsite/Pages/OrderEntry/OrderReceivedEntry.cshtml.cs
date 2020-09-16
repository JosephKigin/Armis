using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.OrderEntryModels;
using Armis.BusinessModels.ShippingModels;
using ArmisWebsite.DataAccess.OrderEntry.Interfaces;
using ArmisWebsite.DataAccess.Shipping;
using ArmisWebsite.DataAccess.Shipping.Interfaces;
using ArmisWebsite.FrontEndModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArmisWebsite.Pages.OrderEntry
{
    public class OrderReceivedEntryModel : PageModel
    {
        //Data Access
        public IOrderHeadDataAccess OrderHeadDataAccess { get; set; }
        public IContainerTypeDataAccess ContainerTypeDataAccess { get; set; }
        public IOrderReceivedDataAccess OrderReceivedDataAccess { get; set; }

        //Models
        public OrderHeadModel OrderHead { get; set; }
        public List<ContainerModel> Containers { get; set; }
        public PopUpMessageModel Message { get; set; }


        //Front End
        [BindProperty(SupportsGet = true)]
        public int? OrderNumber { get; set; }
        [BindProperty]
        public OrderReceivedModel OrderReceived { get; set; }

        public OrderReceivedEntryModel(IOrderHeadDataAccess anOrderHeadDataAccess, IContainerTypeDataAccess aContainerTypeDataAccess, IOrderReceivedDataAccess anOrderReceivedDataAccess)
        {
            OrderHeadDataAccess = anOrderHeadDataAccess;
            ContainerTypeDataAccess = aContainerTypeDataAccess;
            OrderReceivedDataAccess = anOrderReceivedDataAccess;
        }

        public async Task<ActionResult> OnGet()
        {
            if (OrderNumber != null)
            {
                var orderId = OrderNumber ?? 0;
                await SetUpProperties(orderId);

                return Page();
            }
            else
            {
                return Page();
            }
        }

        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                OrderReceived.OrderId = (int)OrderNumber;
                OrderReceived.ReceivedTimeString = (new DateTime(OrderReceived.ReceivedTime.Ticks)).ToString("hh:mm");

                await OrderReceivedDataAccess.CreateOrderReceived(OrderReceived);

                Message = new PopUpMessageModel()
                {
                    IsMessageGood = true,
                    Text = "Order received created successfully"
                };
            }

            var orderId = OrderNumber ?? 0;
            await SetUpProperties(orderId);

            return Page();
        }

        public async Task SetUpProperties(int anOrderId)
        {
            OrderHead = await OrderHeadDataAccess.GetOrderHeadById(anOrderId);
            Containers = (await ContainerTypeDataAccess.GetAllContainerTypes()).ToList();
            OrderReceived = new OrderReceivedModel()
            {
                ReceivedNum = await OrderReceivedDataAccess.GetNextReceivedNumberForOrderId(anOrderId)
            };
        }
    }
}
