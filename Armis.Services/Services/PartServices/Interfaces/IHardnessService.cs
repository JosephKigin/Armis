using Armis.BusinessModels.PartModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.PartServices.Interfaces
{
    public interface IHardnessService
    {
        Task<IEnumerable<HardnessModel>> GetAllHarnesses();
        Task<HardnessModel> GetHardness(int aHardnessId);
        Task<bool> CheckIsNameIsUnique(string aHardnessName);
        Task<HardnessModel> CreateHardness(HardnessModel aHardnessModel);
    }
}
