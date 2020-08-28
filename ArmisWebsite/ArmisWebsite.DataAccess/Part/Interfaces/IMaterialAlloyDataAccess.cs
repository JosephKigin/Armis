using Armis.BusinessModels.PartModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Part.Interfaces
{
    public interface IMaterialAlloyDataAccess
    {
        Task<IEnumerable<MaterialAlloyModel>> GetAllMaterialAlloys();
        Task<MaterialAlloyModel> CreateMaterialAlloy(MaterialAlloyModel aMaterialAlloyModel);
        Task<bool> CheckIfDescriptionIsUnique(string anAlloyDescription);
    }
}
