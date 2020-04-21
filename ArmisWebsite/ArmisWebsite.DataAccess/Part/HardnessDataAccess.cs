using Armis.BusinessModels.PartModels;
using ArmisWebsite.DataAccess.Part.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Part
{
    public class HardnessDataAccess : IHardnessDataAccess
    {
        private IConfiguration Config;

        public HardnessDataAccess(IConfiguration aConfig)
        {
            Config = aConfig;
        }

        public async Task<IEnumerable<HardnessModel>> GetAllHardnesses()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<HardnessModel>>(Config["APIAddress"] + "api/Hardness/GetAllHardnesses");
        }
    }
}
