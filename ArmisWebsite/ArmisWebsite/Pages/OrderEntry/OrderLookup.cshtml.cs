using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.OrderEntryModels;
using ArmisWebsite.DataAccess.OrderEntry.Interfaces;
using ArmisWebsite.FrontEndModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArmisWebsite.Pages.OrderEntry
{
    public class OrderLookupModel : PageModel
    {
        //DataAccess
        public IOrderHeadDataAccess OrderHeadDataAccess { get; set; }

        //Models
        public OrderHeadModel OrderHead { get; set; }

        //Front-End
        [BindProperty(SupportsGet = true)]
        public int OrderNumber { get; set; }
        public PopUpMessageModel Message { get; set; }

        public OrderLookupModel(IOrderHeadDataAccess anOrderHeadDataAccess)
        {
            OrderHeadDataAccess = anOrderHeadDataAccess;
        }

        public async Task<ActionResult> OnGet()
        {
            return Page();
        }

        public async Task<ActionResult> OnGetOrderNumber()
        {
            await SetUpProperties(OrderNumber);

            return Page();
        }

        public async Task SetUpProperties(int? anOrderNumber)
        {
            if (anOrderNumber != null && anOrderNumber != 0)
            {
                int tempOrderHead = anOrderNumber ?? 0; //Just turns the int? to an int
                OrderHead = await OrderHeadDataAccess.GetOrderHeadById(tempOrderHead);
                if (OrderHead == null)
                {
                    Message = new PopUpMessageModel();
                    Message.Text = "No Order found";
                    Message.IsMessageGood = false;
                }
            }
        }
    }
}