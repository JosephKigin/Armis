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
    public class VariableMaintenanceModel : PageModel
    {
        private readonly IConfiguration config;

        public IVariableDataAccess VariableDataAccess { get; set; }
        public IEnumerable<VariableTemplateModel> VariableTemplateModels { get; set; }

        //View properties
        [BindProperty]
        public string VarUOM { get; set; }
        [BindProperty]
        public float VarMin { get; set; }
        [BindProperty]
        public float VarMax { get; set; }
        [BindProperty]
        public string VarTemplate { get; set; }

        public VariableMaintenanceModel(IConfiguration config)
        {
            this.config = config;
            VariableDataAccess = new VariableDataAccess();
        }
        public void OnGet()
        {

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

        public void GetVariableTemplates()
        {
            var theTemplateList = VariableDataAccess.GetAllTemplates();
        }
    }
}