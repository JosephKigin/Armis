using Armis.BusinessModels.PartModels;
using ArmisWebsite.DataAccess.Part.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Part
{
    public class MaterialAlloyDataAccess : IMaterialAlloyDataAccess
    {
        private readonly IConfiguration Config;

        public MaterialAlloyDataAccess(IConfiguration aConfig)
        {
            Config = aConfig;
        }

        public async Task<IEnumerable<MaterialAlloyModel>> GetAllMaterialAlloys()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<MaterialAlloyModel>>(Config["APIAddress"] + "api/MaterialAlloys/GetAllMaterialAlloys");
        }
    }
}
