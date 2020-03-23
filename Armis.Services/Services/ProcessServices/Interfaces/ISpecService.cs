using Armis.BusinessModels.ProcessModels.Spec;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.ProcessServices.Interfaces
{
    public interface ISpecService
    {
        Task<IEnumerable<SpecModel>> GetAllHydratedSpecs();
        Task<IEnumerable<SpecSubLevelModel>> GetSpecSubLevels(int aSpecId, short aSpecRevId);
        Task<int> CreateNewSpec(SpecModel aSpecModel);
    }
}
