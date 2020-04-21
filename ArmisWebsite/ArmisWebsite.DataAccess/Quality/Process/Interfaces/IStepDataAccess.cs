using Armis.BusinessModels.QualityModels.Process;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Quality.Interfaces
{
    public interface IStepDataAccess
    {
        Task<StepModel> PostNewStep(StepModel aStepModel);
        Task<IEnumerable<StepModel>> GetAllSteps();
        Task<IEnumerable<StepModel>> GetAllStepsByCategory(string aCategoryCode);
        Task<IEnumerable<StepCategoryModel>> GetAllStepCategoryies();
        Task<StepCategoryModel> GetStepCategoryByCode(string aStepCategoryCode);
        Task<StepModel> GetStepById(int aStepId);
        Task<List<StepModel>> GetStepByName(string aStepName);
    }
}
