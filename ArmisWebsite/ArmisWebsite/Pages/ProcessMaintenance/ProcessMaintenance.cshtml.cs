using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.Customer;
using Armis.BusinessModels.ProcessModels;
using ArmisWebsite.DataAccess.Customer.Interfaces;
using ArmisWebsite.DataAccess.Process.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArmisWebsite
{
    public class ProcessMaintenanceModel : PageModel
    {
        //Data Access
        public IProcessDataAccess ProcessDataAccess { get; set; }
        public ICustomerDataAccess CustomerDataAccess { get; set; }

        //Model Properties
        public List<CustomerModel> CustomerList { get; set; }

        //Front-End
        [BindProperty]
        public string Message { get; set; }
        public bool IsMessageGood { get; set; }

        [BindProperty]
        [Required, StringLength(50), Display(Name = "Process Name")]
        public string ProcessName { get; set; }

        [BindProperty]
        public string ProcessCustomerSearchName { get; set; }

        [BindProperty]
        public string ProcessCustomerId { get; set; }

        [BindProperty]
        public string ProcessCustomerFullName { get; set; }


        public ProcessMaintenanceModel(IProcessDataAccess aProcessDataAccess, ICustomerDataAccess aCustomerDataAccess)
        {
            ProcessDataAccess = aProcessDataAccess;
            CustomerDataAccess = aCustomerDataAccess;
        }

        //A string message can be passed in and will display on the top of the screen as a success or danger message depending on the property IsMessageGood.
        public async Task<IActionResult> OnGet(string aMessage = "")
        {
            Message = aMessage;

            await SetUpProperties();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            await SetUpProperties();

            if (ModelState.IsValid)
            {
                //Small chunk of validation... ToDo: Maybe move this to a custom validation that can be applied to the SearchName property?
                var doesCustNameExist = CustomerList.FirstOrDefault(i => i.SearchName.ToLower() == ProcessCustomerSearchName.ToLower());

                if (doesCustNameExist == null)
                {
                    IsMessageGood = false;
                    Message = "There is no customer with that name.";
                    return Page();
                }
                //End of validation chunk

                var processToAdd = new ProcessModel()
                {
                    Name = ProcessName,
                    CustId = int.Parse(ProcessCustomerId) //This comes from a front-end input so it is string by nature but it will ALWAYS be a number.  The input is read-only
                };
                var result = await ProcessDataAccess.PostNewProcess(processToAdd);

                IsMessageGood = true;
                Message = "Process saved successfully!";
                return Page();
            }
            else
            {
                return Page();
            }
        }

        //Loads the model properties
        public async Task SetUpProperties()
        {
            try
            {
                var tempCustList = await CustomerDataAccess.GetAllCustomers();
                CustomerList = tempCustList.ToList();

            }
            catch (Exception ex)
            {

                RedirectToPage("/Error", new { ExMessage = "There was a problem loading the page. " + ex.Message });
            }

        }
    }
}