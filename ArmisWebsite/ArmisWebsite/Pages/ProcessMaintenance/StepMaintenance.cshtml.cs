using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armis.BusinessModels.ProcessModels;
using ArmisWebsite.DataAccess.Process;
using ArmisWebsite.DataAccess.Process.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ArmisWebsite
{
    public class StepMaintenanceModel : PageModel
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

        //Business Model Properties
        private List<VariableTemplateModel> _variableTemplateModels;
        public List<VariableTemplateModel> VariableTemplateModels 
        {
            get
            {
                if(_variableTemplateModels == null) { _variableTemplateModels = new List<VariableTemplateModel>(); }
                return _variableTemplateModels;
            }
            set 
            {
                if (_variableTemplateModels == null) { _variableTemplateModels = new List<VariableTemplateModel>(); }
                _variableTemplateModels = value; 
            } 
        }

        private IEnumerable<VariableTemplateModel> _assignedVariableTemplateModels;
        public IEnumerable<VariableTemplateModel> AssignedVariableTemplateModels 
        {
            get
            {
                if(_assignedVariableTemplateModels == null) { _assignedVariableTemplateModels = new List<VariableTemplateModel>(); }
                return _assignedVariableTemplateModels;
            }
            set { _assignedVariableTemplateModels = value; }
        }

        public StepMaintenanceModel(IConfiguration aConfig)
        {
            Config = aConfig;
        }

        public async Task OnGetAsync()
        {
            await SetUpPage();
        }

        public async Task<IActionResult> OnPostMoveVarTemplateToAssignedAsync()
        {
            var willThisGetHit = "Who knows?";
            return Page();
        }

        public void OnPostNewStep()
        {

        }

        private async Task<IActionResult> SetUpPage()
        {
            try
            {
                var theTempModels = await VariableDataAccess.GetAllTemplates();
                VariableTemplateModels = theTempModels.ToList();
            }
            catch (Exception ex)
            {

            }
            return new PageResult();
        }
    }
}