using Armis.BusinessModels.PartModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.PartServices.Interfaces
{
    public interface IMaterialAlloyService
    {
        Task<IEnumerable<MaterialAlloyModel>> GetAllMaterialAlloys();
    }
}
