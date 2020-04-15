using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.Customer;
using Armis.BusinessModels.QualityModels;
using ArmisWebsite.DataAccess.Customer.Interfaces;
using ArmisWebsite.DataAccess.Quality.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArmisWebsite
{
    public class ProcessMaintenanceModel : PageModel
    {
        //Data Access
        public IProcessDataAccess ProcessDataAccess { get; set; }

        //Front-End
        [BindProperty]
        public string Message { get; set; }
        public bool IsMessageGood { get; set; }

        [BindProperty]
        [Required, StringLength(50), Display(Name = "Process Name")]
        public string ProcessName { get; set; }


        public ProcessMaintenanceModel(IProcessDataAccess aProcessDataAccess)
        {
            ProcessDataAccess = aProcessDataAccess;
        }

        //A string message can be passed in and will display on the top of the screen as a success or danger message depending on the property IsMessageGood.
        public async Task<IActionResult> OnGet(string aMessage = "")
        {
            Message = aMessage;

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var processToAdd = new ProcessModel()
                {
                    Name = ProcessName
                };
                var result = await ProcessDataAccess.PostNewProcess(processToAdd);

                IsMessageGood = true;
                Message = "Process saved successfully!";
                return Page();
            }
            else
            {
                return Page(); //The page will load with the validation errors if this is hit.
            }
        }
    }
}