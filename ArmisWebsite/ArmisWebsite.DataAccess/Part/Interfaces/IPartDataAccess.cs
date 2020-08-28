using Armis.BusinessModels.PartModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Part.Interfaces
{
    public interface IPartDataAccess
    {
        Task<IEnumerable<PartModel>> GetAllParts();
        Task<IEnumerable<PartModel>> GetAllPartsWithRack();
        Task<IEnumerable<PartModel>> GetPartForCustId(int aCustId);
        Task<PartModel> CreatePart(PartModel aPart);
    }
}
