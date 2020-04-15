using Armis.BusinessModels.QualityModels.Spec;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Quality.Interfaces
{
    public interface ISpecDataAccess
    {
        Task<IEnumerable<SpecModel>> GetAllHydratedSpecs();
        Task<int> CreateNewHydratedSpec(SpecModel aSpecModel);
        Task<SpecModel> GetHydratedCurrentRevOfSpec(int aSpecId);
        Task<IEnumerable<SpecModel>> GetAllHydratedSpecsWithOnlyCurrentRev();
        Task<int> RevUpSpec(SpecRevModel aSpecModel);
    }
}
