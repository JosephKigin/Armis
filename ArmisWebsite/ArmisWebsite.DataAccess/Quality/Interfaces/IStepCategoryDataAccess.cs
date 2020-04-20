using Armis.BusinessModels.QualityModels.Process;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Quality.Interfaces
{
    public interface IStepCategoryDataAccess
    {
        Task<List<StepCategoryModel>> GetAllStepCategories();
    }
}
