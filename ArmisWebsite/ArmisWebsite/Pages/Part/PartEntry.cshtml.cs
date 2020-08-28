using Armis.BusinessModels.PartModels;
using Armis.BusinessModels.ShopFloorModels.Department;
using Armis.Data.DatabaseContext.Entities;
using ArmisWebsite.DataAccess.Part.Interfaces;
using ArmisWebsite.DataAccess.Quality.Interfaces;
using ArmisWebsite.DataAccess.ShopFloor;
using ArmisWebsite.DataAccess.ShopFloor.Department.Interfaces;
using ArmisWebsite.FrontEndModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArmisWebsite.Pages.Part
{
    public class PartEntryModel : PageModel
    {
        public PopUpMessageModel Message { get; set; }
        //Data Access
        public IPartDataAccess PartDataAccess { get; set; }
        public IUoMDataAccess UoMDataAccess { get; set; }
        public IDepartmentDataAccess DepartmentDataAccess { get; set; }
        public IMaterialAlloyDataAccess MaterialAlloyDataAccess { get; set; }
        public IMaterialSeriesDataAccess MaterialSeriesDataAccess { get; set; }

        //Models
        public List<PartModel> PartModels { get; set; }
        public List<UnitOfMeasureModel> UoMModels { get; set; }
        public List<DepartmentModel> DepartmentModels { get; set; }
        public List<MaterialAlloyModel> AlloyModels { get; set; }
        public List<MaterialSeriesModel> SeriesModels { get; set; }

        //Front-End
        [BindProperty]
        [Required, MaxLength(30) ]
        public string PartName { get; set; }
        [BindProperty]
        [Required, MaxLength(10)]
        public string ExternalRev { get; set; }
        [BindProperty]
        [MaxLength(50)]
        public string Description { get; set; }
        [BindProperty]
        [MaxLength(20)]
        public string Dimensions { get; set; }
        [BindProperty]
        public int? RackId { get; set; } //ToDo: Get this hooked up with rack into when it is available
        [BindProperty]
        [Range(0.000001, 9999999999999999999.999999)]
        public decimal? SurfaceArea { get; set; }
        [BindProperty]
        public int? SurfaceAreaUoM { get; set; }
        [BindProperty]
        [Range(0.000001, 9999999999999999999.999999)]
        public decimal? PieceWeight { get; set; }
        [BindProperty]
        public short? StandardDept { get; set; }
        [BindProperty]
        [MaxLength(20)]
        public string Bake { get; set; } //ToDo: What is this?
        [BindProperty]
        [Range(0.000001, 9999999999999999999.999999)]
        public decimal? BasePrice { get; set; }
        [BindProperty]
        [Range(0.0001, 999999999.9999)]
        public decimal? MinLotCharge { get; set; }
        [BindProperty]
        public int? PartsPerLoad { get; set; }
        [BindProperty]
        [Range(0.0001, 999999999.9999)]
        public decimal? MasksPcsPerHour { get; set; }
        [BindProperty]
        public bool NotifyWhenMasking { get; set; }
        [BindProperty]
        public int? MaterialAlloyId { get; set; }
        [BindProperty]
        public int? MaterialSeriesId { get; set; }
        [BindProperty]
        public int EmployeeId { get; set; }

        public PartEntryModel(IPartDataAccess aPartDataAccess, 
                              IUoMDataAccess aUoMDataAccess, 
                              IDepartmentDataAccess aDepartmentDataAccess, 
                              IMaterialAlloyDataAccess aMaterialAlloyDataAccess, 
                              IMaterialSeriesDataAccess aMaterialSeriesDataAccess)
        {
            PartDataAccess = aPartDataAccess;
            UoMDataAccess = aUoMDataAccess;
            DepartmentDataAccess = aDepartmentDataAccess;
            MaterialAlloyDataAccess = aMaterialAlloyDataAccess;
            MaterialSeriesDataAccess = aMaterialSeriesDataAccess;
        }

        public async Task<ActionResult> OnGet()
        {
            await SetUpProperties();

            return Page();
        }

        public async Task<ActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                Message = new PopUpMessageModel()
                {
                    IsMessageGood = false,
                    Text = "Could not create part" 
                };
                await SetUpProperties();
                return Page();
            }

            var partToSave = new PartModel()
            {
                PartName = PartName,
                ExternalRev = ExternalRev,
                Description = Description,
                Dimensions = Dimensions,
                RackId = RackId,
                SurfaceArea = SurfaceArea,
                SurfaceAreaUoMId = SurfaceAreaUoM,
                PieceWeight = PieceWeight,
                StandardDeptId = StandardDept,
                Bake = Bake,
                BasePrice = BasePrice,
                MinLotCharge = MinLotCharge,
                PartsPerLoad = PartsPerLoad,
                MaskPcsPerHour = MasksPcsPerHour,
                NotifyWhenMasking = NotifyWhenMasking,
                MaterialAlloyId = MaterialAlloyId,
                MaterialSeriesId = MaterialSeriesId,
                CreatedByEmpId = 941
            };

            var resultingPart = await PartDataAccess.CreatePart(partToSave);

            Message = new PopUpMessageModel()
            {
                IsMessageGood = true,
                Text = "Part saved successfully. Part ID: " + resultingPart.PartId
            };

            await SetUpProperties();

            return Page();
        }

        private async Task SetUpProperties()
        {
            PartModels = (await PartDataAccess.GetAllParts()).ToList();
            UoMModels = (await UoMDataAccess.GetAllUoMs()).ToList();
            DepartmentModels = (await DepartmentDataAccess.GetAllDepartments()).ToList();
            AlloyModels = (await MaterialAlloyDataAccess.GetAllMaterialAlloys()).ToList();
            SeriesModels = (await MaterialSeriesDataAccess.GetAllMaterialSeries()).ToList();
        }
    }
}
