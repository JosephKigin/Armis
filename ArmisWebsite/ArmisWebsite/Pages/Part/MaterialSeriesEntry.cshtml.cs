using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.PartModels;
using ArmisWebsite.DataAccess.Quality.Interfaces;
using ArmisWebsite.FrontEndModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArmisWebsite.Pages.Part
{
    public class MaterialSeriesEntryModel : PageModel
    {
        //Data Access
        public IMaterialSeriesDataAccess MaterialSeriesDataAcces { get; set; }

        //Models
        public List<MaterialSeriesModel> AllMaterialSeries { get; set; }

        //Front-End Models
        [BindProperty]
        [Required, StringLength(8)]
        [Display(Name = "Short Name")]
        public string ShortName { get; set; }

        [BindProperty]
        [Required, StringLength(50)]
        public string Description { get; set; }

        [BindProperty]
        [Required, StringLength(20)]
        public string Type { get; set; }

        public PopUpMessageModel Message { get; set; }


        public MaterialSeriesEntryModel(IMaterialSeriesDataAccess aMaterialSeriesDataAccess)
        {
            MaterialSeriesDataAcces = aMaterialSeriesDataAccess;
        }

        public async Task<ActionResult> OnGet()
        {
            await SetUpProperties();

            return Page();
        }

        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var materialSeriesToAdd = new MaterialSeriesModel()
                {
                    ShortName = ShortName,
                    Description = Description,
                    Type = Type
                };

                await MaterialSeriesDataAcces.CreateMaterialSeries(materialSeriesToAdd);

                Message = new PopUpMessageModel()
                {
                    Text = "Material Series created successfully",
                    IsMessageGood = true
                };

                await SetUpProperties();

                return Page();
            }
            else
            {
                await SetUpProperties();

                return Page();
            }
        }

        public async Task SetUpProperties()
        {
            var tempMaterialList = await MaterialSeriesDataAcces.GetAllMaterialSeries();

            if (tempMaterialList != null)
            { AllMaterialSeries = tempMaterialList.ToList(); }
            else
            { AllMaterialSeries = new List<MaterialSeriesModel>(); }
        }
    }
}