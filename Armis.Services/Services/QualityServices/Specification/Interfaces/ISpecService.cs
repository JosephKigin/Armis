using Armis.BusinessModels.QualityModels.Spec;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.QualityServices.Interfaces
{
    public interface ISpecService
    {
        Task<int> CreateNewSpec(SpecModel aSpecModel);
        Task<IEnumerable<SpecModel>> GetAllSpecsWithCurrentRev();
        Task<IEnumerable<SpecModel>> GetAllHydratedSpecs();
        Task<IEnumerable<SpecModel>> GetAllHydratedSpecsWithSamplePlans();
        Task<IEnumerable<SpecSubLevelModel>> GetSpecSubLevels(int aSpecId, short aSpecRevId);
        Task<IEnumerable<SpecModel>> GetAllHydratedSpecsWithOnlyCurrentRev();
        Task<SpecModel> GetHydratedCurrentRevForSpec(int aSpecId);
        Task<int> RevUpSpec(SpecRevModel aSpecModel);

    }
}
