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
using System.ComponentModel.DataAnnotations;

namespace ArmisWebsite
{
    public class VariableTemplateMaintenance : PageModel
    {
        //Data Access
        private IVariableDataAccess _variableDataAccess;

        public IVariableDataAccess VariableDataAccess
        {
            get 
            { 
                if(_variableDataAccess == null) { _variableDataAccess = new VariableDataAccess(); }
                return _variableDataAccess; 
            }
            set { _variableDataAccess = value; }
        }

        //BusinessModel Properties
        public IEnumerable<VariableTemplateModel> VariableTemplateModels { get; set; }
        public IEnumerable<VariableTypeModel> VariableTypes { get; set; }

        //View Properties
        public string LocalBannerMessage { get; set; }
        public bool IsLocalBannerSuccess { get; set; }
        public List<SelectListItem> VariableTypeSelectItems { get; set; }
        [BindProperty]
        [Required]
        public string NewVarTemplateType { get; set; }
        [BindProperty]
        [Required]
        [MaxLength(50)]
        public string NewVarTemplateName { get; set; }
        [BindProperty]
        [Required]
        [MaxLength(10)]
        public string NewVarTemplateCode{ get; set; }

        public VariableTemplateMaintenance(IConfiguration config)
        {
            VariableTypeSelectItems = new List<SelectListItem>();
        }

        public async Task OnGetAsync()
        {
            try 
            { 
                VariableTemplateModels = await VariableDataAccess.GetAllTemplates();
                VariableTypes = await VariableDataAccess.GetAllVarTypes();

                foreach(var type in VariableTypes) { VariableTypeSelectItems.Add(new SelectListItem { Text = type.Description, Value = type.Code }); }

            }
            catch(Exception ex) { } //TODO: Implement error page.
        }

        public async Task OnPostAsync()
        {
            var response = await VariableDataAccess.PostVariableTemplate(new VariableTemplateModel() { Type = NewVarTemplateType, Name = NewVarTemplateName, Code = NewVarTemplateCode});

            if (response.IsSuccessStatusCode)
            {
                IsLocalBannerSuccess = true;
                LocalBannerMessage += "Your template has been saved successfully.";
            }
        }

        //Front-end validation
        public bool VerifyUniqueCode()
        {
            foreach (var templateModel in VariableTemplateModels) 
            { 
                if(templateModel.Code == NewVarTemplateCode) 
                {
                    
                    return false; 
                } 
            }

            return true;
        }

    }
}

/*
 * This is a bunch of stuff not needed for this page but will be needed in the StepMaintenance page.
 * public List<SelectListItem> UOMSelectOptions { get; set; }
 * UOMSelectOptions = new List<SelectListItem>();
 * UOMCodeModels = await UOMCodeDataAccess.GetAllUOMCodes();

                foreach (var uomModel in UOMCodeModels) { UOMSelectOptions.Add( new SelectListItem() { Value = uomModel.Code, Text = uomModel.Description }); }
 */
