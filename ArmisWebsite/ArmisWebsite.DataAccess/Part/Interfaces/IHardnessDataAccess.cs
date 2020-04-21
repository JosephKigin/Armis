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
    }
}
