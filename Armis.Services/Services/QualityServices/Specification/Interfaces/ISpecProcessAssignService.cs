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
        Task<SpecProcessAssignModel> RemoveReviewNeeded(int aSpecId, short aSpecRevId, int anAssignId);
        Task<SpecProcessAssignModel> GetSpecProcessAssign(int aSpecId, short aSpecRevId, short aSpecAssignId);
        Task<bool> VerifyUniqueChoices(int specId, short internalSpecRev, int? choice1, int? choice2, int? choice3, int? choice4, int? choice5, int? choice6, int? preBake, int? postBake, int? mask, int? hardness, int? series, int? alloy, int? customer);
        Task<IEnumerable<SpecProcessAssignModel>> GetAllHydratedReviewNeeded();
    }
}
