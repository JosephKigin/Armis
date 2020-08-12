using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ArmisWebsite.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        public string RequestId { get; set; }
        public string ApiRoute { get; set; }
        public string ApiStatus { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> _logger;

        [BindProperty(SupportsGet = true)]
        public string ExMessage { get; set; }

        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(string stack)
        {
            RequestId = HttpContext.TraceIdentifier;//Activity.Current?.Id ?? HttpContext.TraceIdentifier; <----- This was originally here. Activity is used with application insights locally or in azure.
        }
    }
}