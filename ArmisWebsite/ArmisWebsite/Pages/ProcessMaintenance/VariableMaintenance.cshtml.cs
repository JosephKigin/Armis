using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Armis.BusinessModels.ProcessModels;
using ArmisWebsite.DataAccess.Process;
using ArmisWebsite.DataAccess.Process.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArmisWebsite
{
    public class VariableMaintenance : PageModel
    {
        private readonly IConfiguration config;

        public IEnumerable<VariableTemplateModel> VariableTemplateModels { get; set; }

        //View properties
        
        public List<SelectListItem> VariableTemplateOptions { get; set; }
        [BindProperty]
        public string VarUOM { get; set; }
        [BindProperty]
        public float VarMin { get; set; }
        [BindProperty]
        public float VarMax { get; set; }
        [BindProperty]
        public string VarTemplate { get; set; }
        [BindProperty]
        public string TESTTHEDATAFLOW { get; set; }

        public VariableMaintenance(IConfiguration config)
        {
            this.config = config;
            VariableTemplateModels = new List<VariableTemplateModel>();
            VariableTemplateOptions = new List<SelectListItem>();
        }

        public void CreateVariable()
        {
            var theModel = new VariableModel()
            {
                UnitOfMeasure = VarUOM,
                Min = VarMin,
                Max = VarMax
                //TemplateId = TODO: This
            };
        }

        public async Task OnGetAsync()
        {
            await GetAllVariableTemplates();
        }

        public async Task<IActionResult> GetAllVariableTemplates()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:44316/api/stepvartemplates/GetAllStepVarTemplates");

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    VariableTemplateModels = JsonSerializer.Deserialize<List<VariableTemplateModel>>(responseString);
                    try
                    {
                        foreach (var model in VariableTemplateModels) { VariableTemplateOptions.Add(new SelectListItem { Value = model.Id.ToString(), Text = model.Name }); }
                        VariableTemplateOptions.Sort();
                    }
                    catch (Exception ex) { var whatNow = ex.Message; }
                    
                }

                return Page();
            }
        }
    }
}