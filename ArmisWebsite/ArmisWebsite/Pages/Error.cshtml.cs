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

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> _logger;

        [BindProperty(SupportsGet = true)]
        public string ExMessage { get; set; }

        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            RequestId = HttpContext.TraceIdentifier;//Activity.Current?.Id ?? HttpContext.TraceIdentifier; <----- This was originally here. Activity is used with application insights locally or in azure.

            //This is how to access the exception on the error page to display on page.  Probably won't ever want to do this, but just in case we do, I left it here.
            //public string ApiRoute { get; set; }
            //public string ApiStatus { get; set; }
            //var exceptionPathFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            //var ex = exceptionPathFeature?.Error;
            //if(ex.Data.Contains("API Route")) //If the error comes from an API error.  This exception would have been generated in BasicHttpMessageHandler
            //{
            //    ApiRoute = ex.Data["API Route"].ToString();
            //    ApiStatus = ex.Data["API Status"].ToString();
            //}
        }

        public void OnPost()
        {
            RequestId = HttpContext.TraceIdentifier;//Activity.Current?.Id ?? HttpContext.TraceIdentifier; <----- This was originally here. Activity is used with application insights locally or in azure.
        }
    }
}