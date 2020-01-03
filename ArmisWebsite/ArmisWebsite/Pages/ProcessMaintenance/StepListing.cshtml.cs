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
    public class StepListingModel : PageModel
    {
        private readonly IConfiguration Config;
        private IStepDataAccess _stepDataAccess;

        public IStepDataAccess StepDataAccess
        {
            get 
            {
                if(_stepDataAccess == null) { _stepDataAccess = new StepDataAccess(Config); }
                return _stepDataAccess; 
            }
            set { _stepDataAccess = value; }
        }

        public List<StepModel> Steps { get; set; }

        public StepListingModel(IConfiguration aConfig)
        {
            Config = aConfig;
        }

        public async Task OnGet()
        {
            var theSteps = await StepDataAccess.GetAllHydratedSteps();
            Steps = theSteps.ToList();
        }
    }
}