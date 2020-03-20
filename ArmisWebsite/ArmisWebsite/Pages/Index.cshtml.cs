using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArmisWebsite.DataAccess.Process.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ArmisWebsite.Pages
{
    public class IndexModel : PageModel
    {
        public IIndexDataAccess IndexDataAccess { get; set; }
        public bool CanConnectToApi { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IIndexDataAccess anIndexDataAccess)
        {
            IndexDataAccess = anIndexDataAccess;
        }

        public async Task<IActionResult> OnGet()
        {
            CanConnectToApi = await IndexDataAccess.CheckApiConntection();

            return Page();
        }
    }
}
