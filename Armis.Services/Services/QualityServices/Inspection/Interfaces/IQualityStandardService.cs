using Armis.BusinessModels.QualityModels.InspectionModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.QualityServices.Inspection.Interfaces
{
    public interface IQualityStandardService
    {
        Task<IEnumerable<QualityStandardModel>> GetAllQualityStandards();
    }
}
