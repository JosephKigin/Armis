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
        [Display(Name = "Series")]
        public int SeriesId { get; set; }

        public PopUpMessageModel Message { get; set; }


        public MaterialAlloyEntryModel(IMaterialAlloyDataAccess aMaterialAlloyDataAccess, IMaterialSeriesDataAccess aMaterialSeriesDataAccess)
        {
            MaterialAlloyDataAccess = aMaterialAlloyDataAccess;
            MaterialSeriesDataAccess = aMaterialSeriesDataAccess;
        }

        public async Task<ActionResult> OnGet(string aMessage, bool? isMessageGood)
        {
            if (aMessage != null)
            {
                Message = new PopUpMessageModel()
                {
                    IsMessageGood = isMessageGood,
                    Text = aMessage
                };
            }

            await SetUpProperties();
            return Page();
        }

        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (!(await MaterialAlloyDataAccess.CheckIfDescriptionIsUnique(Description)))
                {
                    Message = new PopUpMessageModel()
                    {
                        IsMessageGood = false,
                        Text = "A material alloy already exists with that description."
                    };

                    await SetUpProperties();

                    return Page();
                }

                var alloyToAdd = new MaterialAlloyModel()
                {
                    Description = Description,
                    MaterialSeriesId = SeriesId
                };

                var result = await MaterialAlloyDataAccess.CreateMaterialAlloy(alloyToAdd); //Not sure what to do with the result.  It will just be the alloy passed in but with an updated alloyId.

                return RedirectToPage("MaterialAlloyEntry", new { aMessage = "Alloy saved successfully", isMessageGood = true });
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