using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.PartModels;
using ArmisWebsite.DataAccess.Part.Interfaces;
using ArmisWebsite.DataAccess.Quality.Interfaces;
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


        //Front-End
        [BindProperty]
        [Required, StringLength(50)]
        public string Description { get; set; }
        
        [BindProperty]
        [Required]
        public int SeriesId { get; set; }


        public MaterialAlloyEntryModel(IMaterialAlloyDataAccess aMaterialAlloyDataAccess, IMaterialSeriesDataAccess aMaterialSeriesDataAccess)
        {
            MaterialAlloyDataAccess = aMaterialAlloyDataAccess;
            MaterialSeriesDataAccess = aMaterialSeriesDataAccess;
        }

        public void OnGet()
        {

        }

        public async Task SerUpProperties()
        {
            AllMaterialSeries = (await MaterialSeriesDataAccess.GetAllMaterialSeries()).ToList();
        }
    }
}