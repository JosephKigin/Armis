using Armis.BusinessModels.ProcessModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Process.Interfaces
{
    public interface IStepDataAccess
    {
        Task<HttpResponseMessage> PostNewStep(StepModel aStepModel);
        Task<IEnumerable<StepModel>> GetAllHydratedSteps();
    }
}
