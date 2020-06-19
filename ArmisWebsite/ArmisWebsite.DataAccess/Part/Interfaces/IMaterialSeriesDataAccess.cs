using Armis.BusinessModels.PartModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Quality.Interfaces
{
    public interface IMaterialSeriesDataAccess
    {
        Task<IEnumerable<MaterialSeriesModel>> GetAllMaterialSeries();
        Task<MaterialSeriesModel> CreateMaterialSeries(MaterialSeriesModel aMaterialSeriesModel);
    }
}
