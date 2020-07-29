using Armis.BusinessModels.QualityModels.InspectionModels;
using ArmisWebsite.DataAccess.Quality.Inspection.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Quality.Inspection
{
    public class QualityStandardDataAccess : IQualityStandardDataAccess
    {
        private readonly IConfiguration Config;

        public QualityStandardDataAccess(IConfiguration aConfig)
        {
            Config = aConfig;
        }

        public async Task<IEnumerable<QualityStandardModel>> GetAllQualityStandards()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<QualityStandardModel>>(Config["APIAddress"] + "api/QualityStandard/GetAllQualityStandards/");
        }
    }
}
