using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.PartModels;
using ArmisWebsite.DataAccess.Part.Interfaces;
using ArmisWebsite.DataAccess.Quality.Interfaces;
using ArmisWebsite.FrontEndModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArmisWebsite.Pages.Part
{
    public class MaterialAlloyEntryModel : PageModel
    {
        //Data Access
        public IMaterialAlloyDataAccess MaterialAlloyDataAccess { get; set; }
        public IMaterialSeriesDataAccess MaterialSeriesDataAccess { get; set; }

        //Models
        public List<MaterialSeriesModel> AllMaterialSeries { get; set; }
        public List<MaterialAlloyModel> AllMaterialAlloys { get; set; }

        //Front-End
        [BindProperty]
        [Required, StringLength(50)]
        public string Description { get; set; }
        
        [BindProperty]
        [Required]
        public int SeriesId { get; set; }

        public PopUpMessageModel Message { get; set; }


        public MaterialAlloyEntryModel(IMaterialAlloyDataAccess aMaterialAlloyDataAccess, IMaterialSeriesDataAccess aMaterialSeriesDataAccess)
        {
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
            if (ModelState.IsValid)
            {
                try
                {
                    var alloyToAdd = new MaterialAlloyModel()
                    {
                        Description = Description,
                        SeriesId = SeriesId
                    };

                    var result = await MaterialAlloyDataAccess.CreateMaterialAlloy(alloyToAdd); //Not sure what to do with the result.  It will just be the alloy passed in but with an updated alloyId.
                    await SetUpProperties();

                    Message = new PopUpMessageModel()
                    {
                        Text = "Alloy saved successfully",
                        IsMessageGood = true
                    };

                    return Page();
                }
                catch (Exception ex)
                {
                    return RedirectToPage("/Error", new { ExMessage = "Failed to save material alloy" });
                }
            }
            else
            {
                await SetUpProperties();
                return Page();
            }
        }

        public async Task SetUpProperties()
        {
            AllMaterialSeries = (await MaterialSeriesDataAccess.GetAllMaterialSeries()).ToList();

            AllMaterialAlloys = (await MaterialAlloyDataAccess.GetAllMaterialAlloys()).ToList();
        }
    }
}