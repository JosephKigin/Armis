using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.PartModels;
using ArmisWebsite.DataAccess.Part.Interfaces;
using ArmisWebsite.FrontEndModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArmisWebsite.Pages.Part
{
    public class HardnessEntryModel : PageModel
    {
        //Data Access
        public IHardnessDataAccess HardnessDataAccess { get; set; }

        //Models
        public List<HardnessModel> AllHardnesses { get; set; }


        //Front-End Models
        [BindProperty]
        [StringLength(8), Required, Display(Name = "Short Name")]
        public string ShortName { get; set; }

        [BindProperty]
        [StringLength(50), Required]
        public string Description { get; set; }

        [BindProperty]
        [Range(0.000001, 9999999999999.999999)]
        public decimal? Min { get; set; }

        [BindProperty]
        [Range(0.000001, 9999999999999.999999)]
        public decimal? Max { get; set; }

        public PopUpMessageModel Message { get; set; }

        public HardnessEntryModel(IHardnessDataAccess aHardnessDataAccess)
        {
            HardnessDataAccess = aHardnessDataAccess;
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

        public async Task<ActionResult> OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var hardnessToCreate = new HardnessModel()
                    {
                        ShortName = ShortName,
                        Description = Description,
                        HardnessMin = Min,
                        HardnessMax = Max
                    };

                    await HardnessDataAccess.CreateHardness(hardnessToCreate);
                    Message = new PopUpMessageModel()
                    {
                        Text = "Hardness created successfully",
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
            catch (Exception ex)
            {
                Message = new PopUpMessageModel()
                {
                    Text = "Error: Hardness was not saved",
                    IsMessageGood = false
                };

                await SetUpProperties();

                return Page();
            }
        }

        public async Task SetUpProperties()
        {
            var tempAllHardnesses = await HardnessDataAccess.GetAllHardnesses();
            AllHardnesses = (tempAllHardnesses != null && tempAllHardnesses.Any()) ? tempAllHardnesses.ToList() : new List<HardnessModel>();
        }
    }
}