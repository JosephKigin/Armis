using Armis.BusinessModels.ProcessModels.Spec;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.ProcessServices.Interfaces
{
    public interface ISpecService
    {
        Task<int> CreateNewSpec(SpecModel aSpecModel);
        Task<IEnumerable<SpecModel>> GetAllHydratedSpecs();
        Task<IEnumerable<SpecSubLevelModel>> GetSpecSubLevels(int aSpecId, short aSpecRevId);
        Task<IEnumerable<SpecModel>> GetAllHydratedSpecsWithOnlyCurrentRev();
        Task<SpecModel> GetCurrentRevForSpec(int aSpecId);
        Task<int> RevUpSpec(SpecModel aSpecModel);

    }
}
