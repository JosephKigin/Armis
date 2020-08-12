using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.Customer;
using Armis.BusinessModels.QualityModels.InspectionModels;
using Armis.BusinessModels.ShippingModels;
using ArmisWebsite.DataAccess.Customer.Interfaces;
using ArmisWebsite.DataAccess.Quality.Inspection.Interfaces;
using ArmisWebsite.DataAccess.Shipping.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArmisWebsite.Pages.OrderEntry
{
    public class OrderEntryIndexModel : PageModel
    {
        //Data Access
        public IQualityStandardDataAccess QualityStandardDataAccess { get; set; }
        public IShipViaCodeDataAccess ShipViaCodeDataAccess { get; set; }
        public ICustomerDataAccess CustomerDataAccess { get; set; }

        //Data Models
        public List<QualityStandardModel> QualityStandards { get; set; }
        public List<ShipViaCodeModel> ShipViaCodes { get; set; }
        public List<CustomerModel> Customers { get; set; }

        //Bound Properties

        public OrderEntryIndexModel(IQualityStandardDataAccess aQualityStandardDataAccess,
                                    IShipViaCodeDataAccess aShipViaCodeDataAccess,
                                    ICustomerDataAccess aCustomerDataAccess)
        {
            QualityStandardDataAccess = aQualityStandardDataAccess;
            ShipViaCodeDataAccess = aShipViaCodeDataAccess;
            CustomerDataAccess = aCustomerDataAccess;
        }

        public async Task<ActionResult> OnGet()
        {
            try
            {
                await SetUpProperties();

                return Page();
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error", new { ExMessage = ex.Message });
            }
        }

        public async Task SetUpProperties()
        {
            QualityStandards = (await QualityStandardDataAccess.GetAllQualityStandards()).ToList();
            ShipViaCodes = (await ShipViaCodeDataAccess.GetAllShipVias()).ToList();
            Customers = (await CustomerDataAccess.GetAllCurrentAndProspectCustomers()).ToList();
        }
    }
}