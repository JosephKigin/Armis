using Armis.BusinessModels.QualityModels.Spec;
using ArmisWebsite.DataAccess.Quality.Specification.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Quality.Specification
{
    public class SpecProcessAssignDataAccess : ISpecProcessAssignDataAccess
    {
        private IConfiguration Config;

        public SpecProcessAssignDataAccess(IConfiguration aConfig)
        {
            Config = aConfig;
        }

        public async Task<IEnumerable<SpecProcessAssignModel>> GetAllSpecProcessAssigns()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<SpecProcessAssignModel>>(Config["APIAddress"] + "api/SpecProcessAssign/GetAllHydratedSpecProcessAssign");
        }
    }
}
