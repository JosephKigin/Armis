using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArmisWebsite
{
    public class SuccessModel : PageModel
    {
        [BindProperty]
        public string Message { get; set; }

        public void OnGet(string aMessage)
        {
            Message = aMessage;
        }
    }
}