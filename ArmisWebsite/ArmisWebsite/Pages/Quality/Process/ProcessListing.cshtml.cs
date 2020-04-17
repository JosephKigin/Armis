using Armis.BusinessModels.QualityModels.Process;
using ArmisWebsite.DataAccess.Quality.Interfaces;
using ArmisWebsite.Utility;
using ArmisWebsite.Utility.Interfaces;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace ArmisWebsite
{
    public class ProcessListingModel : PageModel
    {
        public readonly string _apiAddress; //This is needed whenever javascrit is responsible for loading data from the API.
        public readonly IConfiguration Config;

        //Utility
        public IPdfGenerator PdfGenerator { get; set; }

        //Data Access
        public IProcessDataAccess ProcessDataAccess { get; set; }

        //Models
        public List<ProcessModel> Processes { get; set; }

        //Front-End
        public string PopUpMessage { get; set; }

        [BindProperty(SupportsGet = true)]
        public int ProcessIdSelection { get; set; }

        [BindProperty]
        public string PdfPath { get; set; } //This will be sent to the front-end to let javascript see the path so it can handle opening it in a new tab.


        public ProcessListingModel(IProcessDataAccess aProcessDataAccess, IConfiguration aConfig, IPdfGenerator aPdfGenerator)
        {
            ProcessDataAccess = aProcessDataAccess;
            Config = aConfig;
            _apiAddress = aConfig["APIAddress"];
            PdfGenerator = aPdfGenerator;
        }

        public async Task<IActionResult> OnGet()
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

        public async Task<IActionResult> OnPostPrint()
        {
            var theProcess = await ProcessDataAccess.GetHydratedProcess(ProcessIdSelection);
            var theCurrentRev = theProcess.Revisions.FirstOrDefault(i => i.RevStatusCd == "LOCKED");

            if (theCurrentRev == null)
            {
                PopUpMessage = "Cannot create router for a process that does not have a LOCKED revision.";
                await SetUpProperties();
                return Page();
            }

            PdfPath = PdfGenerator.GenerateRouterPdf(theProcess, theCurrentRev);

            FileStream fileStream = new FileStream(PdfPath, FileMode.Open, FileAccess.Read);
            FileStreamResult fsResult = new FileStreamResult(fileStream, MediaTypeNames.Application.Pdf);

            return fsResult;
        }

        public async Task SetUpProperties()
        {
            var theProcesses = await ProcessDataAccess.GetAllHydratedProcesses();

            Processes = theProcesses.ToList();

            foreach (var process in Processes)
            {
                process.Revisions.OrderBy(i => i.ProcessRevId);
            }
        }


    }
}