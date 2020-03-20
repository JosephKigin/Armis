using Armis.BusinessModels.ProcessModels.Spec;
using ArmisWebsite.DataAccess.Process.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Process
{
    public class SpecDataAccess : ISpecDataAccess
    {
        private readonly IConfiguration Config;

        public SpecDataAccess(IConfiguration aConfig)
        {
            Config = aConfig;
        }

        public async Task<IEnumerable<SpecModel>> GetAllHydratedSpecs()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<SpecModel>>(Config["APIAddress"] + "api/spec/GetAllHydratedSpecs");
        }
    }
}
