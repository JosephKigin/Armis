using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArmisWebsite.Pages.ProcessMaintenance
{
    public class SpecificationCreationModel : PageModel
    {
        //Data Access

        //Data Models 

        //Front-End Models
        [BindProperty]
        public string SpecTitle { get; set; }

        [BindProperty]
        public string SubLevelName1 { get; set; }
        [BindProperty]
        public List<string> ChoiceNames1 { get; set; }

        [BindProperty]
        public string SubLevelName2 { get; set; }
        [BindProperty]
        public List<string> ChoiceNames2 { get; set; }

        [BindProperty]
        public string SubLevelName3 { get; set; }
        [BindProperty]
        public List<string> ChoiceNames3 { get; set; }

        [BindProperty]
        public string SubLevelName4 { get; set; }
        [BindProperty]
        public List<string> ChoiceNames4 { get; set; }

        [BindProperty]
        public string SubLevelName5 { get; set; }
        [BindProperty]
        public List<string> ChoiceNames5 { get; set; }

        [BindProperty]
        public string SubLevelName6 { get; set; }
        [BindProperty]
        public List<string> ChoiceNames6 { get; set; }

        public void OnGet()
        {

        }

        public async Task<ActionResult> OnPost()
        {
            var test = ChoiceNames1;
            return Page();
        }
    }
}