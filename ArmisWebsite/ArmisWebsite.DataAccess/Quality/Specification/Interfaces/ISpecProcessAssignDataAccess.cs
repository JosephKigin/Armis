using Armis.BusinessModels.QualityModels.Spec;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Quality.Specification.Interfaces
{
    public interface ISpecProcessAssignDataAccess
    {
        Task<IEnumerable<SpecProcessAssignModel>> GetAllSpecProcessAssigns();
        Task<SpecProcessAssignModel> PostSpecProcessAssign(SpecProcessAssignModel aSpecProcessAssign);
    }
}
