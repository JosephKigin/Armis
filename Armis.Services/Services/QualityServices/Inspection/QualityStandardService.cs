using Armis.BusinessModels.QualityModels.InspectionModels;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.ModelExtensions.QualityExtensions.InspectionExtensions;
using Armis.DataLogic.Services.QualityServices.Inspection.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.QualityServices.Inspection
{
    public class QualityStandardService : IQualityStandardService
    {
        private ARMISContext Context;

        public QualityStandardService(ARMISContext aContext)
        {
            Context = aContext;
        }

        public async Task<IEnumerable<QualityStandardModel>> GetAllQualityStandards()
        {
            var entities = await Context.QualityStandard.ToListAsync();

            if(entities == null || !entities.Any()) { throw new Exception("No Quality Standards returned"); }

            return entities.ToModels();
        }
    }
}