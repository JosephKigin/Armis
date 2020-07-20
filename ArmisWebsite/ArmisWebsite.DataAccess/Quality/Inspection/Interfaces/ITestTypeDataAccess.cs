using Armis.BusinessModels.QualityModels.InspectionModels;
using Armis.BusinessModels.QualityModels.Spec;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Quality.Inspection.Interfaces
{
    public interface ITestTypeDataAccess
    {
        Task<IEnumerable<InspectTestTypeModel>> GetAllTestTypes();
    }
}
