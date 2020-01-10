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
        Task<int> PostNewStep(StepModel aStepModel);
        Task<IEnumerable<StepModel>> GetAllHydratedSteps();
        Task<StepModel> GetStepById(int aStepId);
        Task<int> AddVariablesToStep(StepModel aStepModel);
    }
}
