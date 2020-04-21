using Armis.BusinessModels.QualityModels.Process;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.QualityServices.Interfaces
{
    public interface IStepService
    {
        Task<IEnumerable<StepModel>> GetAll();
        Task<IEnumerable<StepCategoryModel>> GetAllStepCategories();
        Task<StepCategoryModel> GetStepCategoryByCode(string aStepCategoryCode);
        Task<StepModel> GetStepById(int aStepId);
        Task<IEnumerable<StepModel>> GetAllByCategory(string aCategory);
        Task<StepModel> CreateStep(StepModel aStepModel);
        Task<int> UpdateStep(int aStepId, StepModel aStepModel);
        Task<int> DeactivateStep(int aStepId);
        Task<List<StepModel>> GetStepByName(string aStepName);
    }
}
