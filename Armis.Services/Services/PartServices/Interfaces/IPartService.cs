using Armis.BusinessModels.PartModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.PartServices.Interfaces
{
    public interface IPartService
    {
        Task<IEnumerable<PartModel>> GetAllParts();
        Task<IEnumerable<PartModel>> GetPartsForCustId(int aCustId);
        Task<PartModel> CreatePart(PartModel aPart);
        Task<PartModel> CreatePartWithCustomerPart(PartModel aPartModel, int aCustomerId);
    }
}
