using Armis.BusinessModels.QualityModels.InspectionModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Quality.Inspection.Interfaces
{
    public interface IQualityStandardDataAccess
    {
        Task<IEnumerable<QualityStandardModel>> GetAllQualityStandards();
    }
}
