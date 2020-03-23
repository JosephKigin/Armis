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
        public async Task<IActionResult> OnGet()
        {
            return Page();
        }
    }
}
