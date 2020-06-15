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
        Task<IEnumerable<SpecProcessAssignModel>> GetAllActiveSpecProcessAssigns();
        Task<IEnumerable<SpecProcessAssignModel>> GetAllReviewNeededSpecProcessAssign();
        Task<SpecProcessAssignModel> PostSpecProcessAssign(SpecProcessAssignModel aSpecProcessAssign);
        Task<bool> VerifyUniqueChoices(int specId, short internalSpecId, int? choice1, int? choice2, int? choice3, int? choice4, int? choice5, int? choice6, int? preBake, int? postBake, int? mask, int? hardness, int? series, int? alloy, int? customer);
    }
}
