using Armis.BusinessModels.ProcessModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.ProcessServices.Interfaces
{
    public interface IStepService
    {
        Task<IEnumerable<StepModel>> GetAllHydrated();
        Task<StepModel> GetHydratedStepById(int aStepId);
        Task<IEnumerable<StepModel>> GetAllByCategory(string aCategory);
        Task<int> CreateStep(StepModel aStepModel);
        Task<int> UpdateStep(int aStepId, StepModel aStepModel);
        Task<int> DeactivateStep(int aStepId);
        Task<int> AddVariablesToStep(StepModel aStepModel);
        Task<List<StepModel>> GetHydratedByName(string aStepName);
    }
}
