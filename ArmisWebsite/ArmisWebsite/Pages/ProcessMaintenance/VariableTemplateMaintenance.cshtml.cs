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
        private readonly IConfiguration Config;

        //Data Access
        private IVariableDataAccess _variableDataAccess;

        public IVariableDataAccess VariableDataAccess
        {
            get
            {
                if (_variableDataAccess == null) { _variableDataAccess = new VariableDataAccess(Config); }
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
        public string Type { get; set; }

        [BindProperty]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [BindProperty]
        [Required]
        [MaxLength(10)]
        public string Code { get; set; }

        public VariableTemplateMaintenance(IConfiguration aConfig)
        {
            Config = aConfig;
            VariableTypeSelectItems = new List<SelectListItem>();
            VariableTemplateModels = new List<VariableTemplateModel>();
        }

        public async Task OnGetAsync()
        {
            await SetUpPage();
        }

        public async Task OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var theType = VariableTypes.SingleOrDefault(i => i.Description == Type);

                var response = await VariableDataAccess.PostVariableTemplate(new VariableTemplateModel() { Type = theType, Name = Name, Code = Code });

                if (response.IsSuccessStatusCode)
                { SetLocalBanner("Your template has been saved successfully.", true); }
                else
                { SetLocalBanner("Your template save failed.\r\n" + response.Content.ReadAsStringAsync().GetAwaiter().GetResult(), false); }
            }

            await SetUpPage();

        }

        public async Task<IActionResult> SetUpPage()
        {
            try
            {
                VariableTemplateModels = await VariableDataAccess.GetAllTemplates();
                VariableTypes = await VariableDataAccess.GetAllVarTypes();
                VariableTypeSelectItems.Add(new SelectListItem { Text = "", Value = "" });
                foreach (var type in VariableTypes) { VariableTypeSelectItems.Add(new SelectListItem { Text = type.Description, Value = type.Code }); }
                
            }
            catch (Exception ex)
            {
                SetLocalBanner("Could not load data from database.  Please contact IT. \r\n" + "EXCEPTION: " + ex.Message, false);
            } //TODO: Implement error page.
            return new PageResult();
        }

        public void SetLocalBanner(string aMessage, bool aState)
        {
            LocalBannerMessage = aMessage;
            IsLocalBannerSuccess = aState;
        }

        //Front-end validation
        public bool VerifyUniqueCode()
        {
            foreach (var templateModel in VariableTemplateModels)
            {
                if (templateModel.Code == Code)
                {

                    return false;
                }
            }

            return true;
        }

    }
}
