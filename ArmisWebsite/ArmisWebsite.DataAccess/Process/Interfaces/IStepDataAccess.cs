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
        Task<StepModel> PostNewStep(StepModel aStepModel);
        Task<IEnumerable<StepModel>> GetAllSteps();
        Task<IEnumerable<StepCategoryModel>> GetAllStepCategoryies();
        Task<StepCategoryModel> GetStepCategoryByCode(string aStepCategoryCode);
        Task<StepModel> GetStepById(int aStepId);
        Task<List<StepModel>> GetStepByName(string aStepName);
    }
}
