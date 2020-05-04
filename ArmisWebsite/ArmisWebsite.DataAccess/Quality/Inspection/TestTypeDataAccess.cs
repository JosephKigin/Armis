using Armis.BusinessModels.QualityModels.Spec;
using ArmisWebsite.DataAccess.Quality.Inspection.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Quality.Inspection
{
    public class TestTypeDataAccess : ITestTypeDataAccess
    {
        private readonly IConfiguration Config;

        public TestTypeDataAccess(IConfiguration aConfig)
        {
            Config = aConfig;
        }

        public async Task<IEnumerable<InspectTestTypeModel>> GetAllTestTypes()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<InspectTestTypeModel>>(Config["APIAddress"] + "api/InspectTestType/GetAllTestTypes");
        }
    }
}
