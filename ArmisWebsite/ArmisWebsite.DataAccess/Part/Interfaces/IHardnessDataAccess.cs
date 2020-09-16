using Armis.BusinessModels.PartModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Part.Interfaces
{
    public interface IHardnessDataAccess
    {
        Task<IEnumerable<HardnessModel>> GetAllHardnesses();
        Task<bool> CheckIfNameIsUnique(string aHardnessName);
        Task<HardnessModel> CreateHardness(HardnessModel aHardnessModel);
    }
}
