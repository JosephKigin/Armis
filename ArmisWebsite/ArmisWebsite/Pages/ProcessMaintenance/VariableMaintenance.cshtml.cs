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

        private IUOMCodeDataAccess _uomCodeDataAccess;

        public IUOMCodeDataAccess UOMCodeDataAccess
        {
            get 
            {
                if(_uomCodeDataAccess == null) { _uomCodeDataAccess = new UOMCodeDataAccess(); }
                return _uomCodeDataAccess; 
            }
            set { _uomCodeDataAccess = value; }
        }


        //Model Properties
        public IEnumerable<VariableTemplateModel> VariableTemplateModels { get; set; }
        public IEnumerable<UOMCodeModel> UOMCodeModels { get; set; }

        //View Properties
        public List<SelectListItem> UOMSelectOptions { get; set; }
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
            UOMSelectOptions = new List<SelectListItem>();
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
            try 
            { 
                VariableTemplateModels = await VariableDataAccess.GetAllTemplates();
                UOMCodeModels = await UOMCodeDataAccess.GetAllUOMCodes();

                foreach (var uomModel in UOMCodeModels)
                {
                    var tempSelectListItem = new SelectListItem()
                    {
                        Value = uomModel.Code,
                        Text = uomModel.Description
                    };
                    UOMSelectOptions.Add(tempSelectListItem);

                }
            }
            catch(Exception ex) { } //TODO: Implement error page.
        }

        
    }
}