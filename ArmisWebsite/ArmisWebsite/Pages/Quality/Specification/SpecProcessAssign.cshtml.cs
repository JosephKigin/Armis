using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArmisWebsite.Pages.ProcessMaintenance
{
    public class SpecProcessAssignModel : PageModel
    {
        //Data Access


        //Models


        //Front-End
        [BindProperty]
        public int SpecRev { get; set; }

        public SpecProcessAssignModel()
        {

        }

        public void OnGet()
        {

        }

        public async Task SetUpProperties()
        {

        }
    }
}