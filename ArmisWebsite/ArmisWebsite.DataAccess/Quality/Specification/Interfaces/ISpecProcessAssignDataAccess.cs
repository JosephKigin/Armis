using Armis.BusinessModels.QualityModels.Spec;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Quality.Specification.Interfaces
{
    public interface ISpecProcessAssignDataAccess
    {
        Task<IEnumerable<SpecProcessAssignModel>> GetAllHydratedSpecProcessAssigns();
        Task<IEnumerable<SpecProcessAssignModel>> GetAllActiveHydratedSpecProcessAssigns();
        Task<IEnumerable<SpecProcessAssignModel>> GetAllActiveHydratedSpecProcessAssignForSpec(int aSpecId);
        Task<IEnumerable<SpecProcessAssignModel>> GetAllHydratedReviewNeededSpecProcessAssign();
        Task<SpecProcessAssignModel> PostSpecProcessAssign(SpecProcessAssignModel aSpecProcessAssign);
        Task<SpecProcessAssignModel> RemoveReviedNeeded(SpecProcessAssignModel aSpecProcessAssignModel);
        Task<SpecProcessAssignModel> CopyAfterReview(SpecProcessAssignModel aSpecProcessAssignModel);
        Task<bool> CheckIfReviewIsNeededForSpecId(int aSpecId);
        Task<bool> VerifyUniqueChoices(int specId, short internalSpecId, int? customer, IEnumerable<SpecProcessAssignOptionModel> anOptionModels);
        Task<bool> CheckSpaIsViable(int aSpecId, IEnumerable<SpecProcessAssignOptionModel> anOptionModels);
    }
}
