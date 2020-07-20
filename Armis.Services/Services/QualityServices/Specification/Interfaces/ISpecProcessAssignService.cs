using Armis.BusinessModels.QualityModels.Spec;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.QualityServices.Interfaces
{
    public interface ISpecProcessAssignService
    {
        Task<SpecProcessAssignModel> PostSpecProcessAssign(SpecProcessAssignModel aSpecProcessASsignModel);
        Task<IEnumerable<SpecProcessAssignModel>> GetAllHydratedSpecProcessAssign();
        Task<IEnumerable<SpecProcessAssignModel>> GetAllActiveHydratedSpecProcessAssign();
        Task<IEnumerable<SpecProcessAssignModel>> GetAllActiveHydratedSpecProcessAssignForSpec(int aSpecId);
        Task<SpecProcessAssignModel> RemoveReviewNeeded(int aSpecId, short aSpecRevId, int anAssignId);
        Task<SpecProcessAssignModel> CopyAfterReview(SpecProcessAssignModel aSpecProcessAssignModel);
        Task<SpecProcessAssignModel> GetSpecProcessAssign(int aSpecId, short aSpecRevId, short aSpecAssignId);
        Task<bool> CheckIfReviewIsNeededForSpecId(int aSpecId);
        Task<bool> VerifyUniqueChoices(int specId, short internalSpecRev, int? customer, IEnumerable<SpecProcessAssignOptionModel> anOptionModels);
        Task<IEnumerable<SpecProcessAssignModel>> GetAllHydratedReviewNeeded();
        Task<bool> CheckSpaIsViable(int aSpecId, IEnumerable<SpecProcessAssignOptionModel> anOptionModels);
    }
}
