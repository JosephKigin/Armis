using Armis.BusinessModels.ProcessModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.ProcessServices.Interfaces
{
    public interface ISubOperationService
    {
        //TODO: Add reads after getting more information from Patti.  See Process pseudocode in teams.

        Task<SubopRevisionModel> CreateRevForExistingSubop(SubopRevisionModel aSubopRevModel);
        Task<SubopModel> CreateSubop(SubopModel aSubopModel);

        Task<SubopModel> DeactivateSubop(int aSubopId);
        Task<SubopRevisionModel> DeactivateSubopRev(int aSubopId, int aSubopRevId);

        Task<SubopRevisionModel> LockSubopRev(SubopRevisionModel aSubopRevModel);
    }
}
