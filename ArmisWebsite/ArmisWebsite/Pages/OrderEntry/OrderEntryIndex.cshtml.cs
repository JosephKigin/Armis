using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.Customer;
using Armis.BusinessModels.PartModels;
using Armis.BusinessModels.QualityModels.InspectionModels;
using Armis.BusinessModels.ShippingModels;
using ArmisWebsite.DataAccess.Customer.Interfaces;
using ArmisWebsite.DataAccess.Part.Interfaces;
using ArmisWebsite.DataAccess.Quality.Inspection.Interfaces;
using ArmisWebsite.DataAccess.Shipping.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ArmisWebsite.Pages.OrderEntry
{
    public class OrderEntryIndexModel : PageModel
    {
        public readonly string _apiAddress;
        public readonly IConfiguration Config;

        //Data Access
        public IQualityStandardDataAccess QualityStandardDataAccess { get; set; }
        public IShipViaCodeDataAccess ShipViaCodeDataAccess { get; set; }
        public ICustomerDataAccess CustomerDataAccess { get; set; }
        public IUoMDataAccess UoMDataAccess { get; set; }
        public IPackageCodeDataAccess PackageCodeDataAccess { get; set; }
        public IContainerTypeDataAccess ContainerTypeDataAccess { get; set; }

        //Data Models
        public List<QualityStandardModel> QualityStandards { get; set; }
        public List<ShipViaCodeModel> ShipViaCodes { get; set; }
        public List<CustomerModel> Customers { get; set; }
        public List<UnitOfMeasureModel> UoMs { get; set; }
        public List<PackageCodeModel> PackageCodes { get; set; }
        public List<ContainerModel> Containers { get; set; }

        //Bound Properties

        public OrderEntryIndexModel(IQualityStandardDataAccess aQualityStandardDataAccess,
                                    IShipViaCodeDataAccess aShipViaCodeDataAccess,
                                    ICustomerDataAccess aCustomerDataAccess,
                                    IUoMDataAccess aUoMDataAccess,
                                    IPackageCodeDataAccess aPackagingCodeDataAccess,
                                    IContainerTypeDataAccess aContainerTypeDataAccess,
                                    IConfiguration aConfig)
        {
            QualityStandardDataAccess = aQualityStandardDataAccess;
            ShipViaCodeDataAccess = aShipViaCodeDataAccess;
            CustomerDataAccess = aCustomerDataAccess;
            UoMDataAccess = aUoMDataAccess;
            PackageCodeDataAccess = aPackagingCodeDataAccess;
            ContainerTypeDataAccess = aContainerTypeDataAccess;
            Config = aConfig;
            _apiAddress = aConfig["APIAddress"];
        }

        public async Task<ActionResult> OnGet()
        {
            await SetUpProperties();

            return Page();
        }

        private async Task SetUpProperties()
        {
            QualityStandards = (await QualityStandardDataAccess.GetAllQualityStandards()).ToList();
            ShipViaCodes = (await ShipViaCodeDataAccess.GetAllShipVias()).ToList();
            Customers = (await CustomerDataAccess.GetAllCurrentAndProspectCustomers()).ToList();
            UoMs = (await UoMDataAccess.GetAllUoMs()).ToList();
            PackageCodes = (await PackageCodeDataAccess.GetAllPackageCodes()).ToList();
            Containers = (await ContainerTypeDataAccess.GetAllContainerTypes()).ToList();
        }
    }
}