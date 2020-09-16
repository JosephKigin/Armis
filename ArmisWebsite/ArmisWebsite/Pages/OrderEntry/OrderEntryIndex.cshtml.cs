using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.ARModels;
using Armis.BusinessModels.Customer;
using Armis.BusinessModels.PartModels;
using Armis.BusinessModels.QualityModels.InspectionModels;
using Armis.BusinessModels.ShippingModels;
using Armis.BusinessModels.ShopFloorModels.Department;
using ArmisWebsite.DataAccess.AR.Interfaces;
using ArmisWebsite.DataAccess.Customer.Interfaces;
using ArmisWebsite.DataAccess.Part.Interfaces;
using ArmisWebsite.DataAccess.Quality.Inspection.Interfaces;
using ArmisWebsite.DataAccess.Quality.Interfaces;
using ArmisWebsite.DataAccess.Shipping.Interfaces;
using ArmisWebsite.DataAccess.ShopFloor.Department.Interfaces;
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
        public IShipViaCodeDataAccess ShipViaCodeDataAccess { get; set; }
        public ICustomerDataAccess CustomerDataAccess { get; set; }
        public IUoMDataAccess UoMDataAccess { get; set; }
        public IPackageCodeDataAccess PackageCodeDataAccess { get; set; }
        public IContainerTypeDataAccess ContainerTypeDataAccess { get; set; }
        public ICertificationChargeDataAccess CertificationChargeDataAccess { get; set; }
        public IMaterialAlloyDataAccess AlloyDataAccess { get; set; }
        public IMaterialSeriesDataAccess SeriesDataAccess { get; set; }
        public IDepartmentDataAccess DepartmentDataAccess { get; set; }

        //Data Models
        public List<ShipViaCodeModel> ShipViaCodes { get; set; }
        public List<CustomerModel> Customers { get; set; }
        public List<UnitOfMeasureModel> UoMs { get; set; }
        public List<PackageCodeModel> PackageCodes { get; set; }
        public List<ContainerModel> Containers { get; set; }
        public List<CertificationChargeModel> CertificationCharges { get; set; }
        public List<MaterialAlloyModel> Alloys { get; set; }
        public List<MaterialSeriesModel> Series { get; set; }
        public List<DepartmentModel> Departments { get; set; }

        //Bound Properties


        public OrderEntryIndexModel(IShipViaCodeDataAccess aShipViaCodeDataAccess,
                                    ICustomerDataAccess aCustomerDataAccess,
                                    IUoMDataAccess aUoMDataAccess,
                                    IPackageCodeDataAccess aPackagingCodeDataAccess,
                                    IContainerTypeDataAccess aContainerTypeDataAccess,
                                    ICertificationChargeDataAccess aCertChargeDataAccess,
                                    IMaterialAlloyDataAccess aMaterialAlloyDataAccess,
                                    IMaterialSeriesDataAccess aMaterialSeriesDataAccess,
                                    IDepartmentDataAccess aDepartmentDataAccess,
                                    IConfiguration aConfig)
        {
            ShipViaCodeDataAccess = aShipViaCodeDataAccess;
            CustomerDataAccess = aCustomerDataAccess;
            UoMDataAccess = aUoMDataAccess;
            PackageCodeDataAccess = aPackagingCodeDataAccess;
            ContainerTypeDataAccess = aContainerTypeDataAccess;
            CertificationChargeDataAccess = aCertChargeDataAccess;
            AlloyDataAccess = aMaterialAlloyDataAccess;
            SeriesDataAccess = aMaterialSeriesDataAccess;
            DepartmentDataAccess = aDepartmentDataAccess;
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
            ShipViaCodes = (await ShipViaCodeDataAccess.GetAllShipVias()).ToList();
            Customers = (await CustomerDataAccess.GetAllCurrentAndProspectCustomers()).ToList();
            UoMs = (await UoMDataAccess.GetAllUoMs()).ToList();
            PackageCodes = (await PackageCodeDataAccess.GetAllPackageCodes()).ToList();
            Containers = (await ContainerTypeDataAccess.GetAllContainerTypes()).ToList();
            CertificationCharges = (await CertificationChargeDataAccess.GetAllCertCharges()).ToList();
            Alloys = (await AlloyDataAccess.GetAllMaterialAlloys()).ToList();
            Series = (await SeriesDataAccess.GetAllMaterialSeries()).ToList();
            Departments = (await DepartmentDataAccess.GetAllDepartments()).ToList();
        }
    }
}