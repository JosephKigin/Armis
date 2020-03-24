using Armis.BusinessModels.ProcessModels.Spec;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Process.Interfaces
{
    public interface ISpecDataAccess
    {
        Task<IEnumerable<SpecModel>> GetAllHydratedSpecs();
        Task<int> CreateNewSpec(SpecModel aSpecModel);
        Task<SpecModel> GetHydratedCurrentRevOfSpec(int aSpecId);
    }
}
