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
        Task<bool> VerifyUniqueChoices(int specId, short internalSpecRev, int? choice1, int? choice2, int? choice3, int? choice4, int? choice5, int? choice6, int? preBake, int? postBake, int? mask, int? hardness, int? series, int? alloy, int? customer);
        Task<IEnumerable<SpecProcessAssignModel>> GetAllHydratedReviewNeeded();
        Task<bool> CheckSpaIsViable(int aSpecId, byte? aChoice1, byte? aChoice2, byte? aChoice3, byte? aChoice4, byte? aChoice5, byte? aChoice6);
    }
}
