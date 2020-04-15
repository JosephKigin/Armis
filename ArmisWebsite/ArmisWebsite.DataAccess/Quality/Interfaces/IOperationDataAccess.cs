using Armis.BusinessModels.QualityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Quality.Interfaces
{
    public interface IOperationDataAccess
    {
        Task<IEnumerable<OperationModel>> GetAllOperations();
        Task<OperationModel> CreateOperation(OperationModel anOperation);
        Task<OperationModel> UpdateOperation(OperationModel anOperationModel);
        Task<IEnumerable<OperationGroupModel>> GetAllOperationGroups();
    }
}
