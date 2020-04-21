using Armis.BusinessModels.QualityModels.Process;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.QualityServices.Interfaces
{
    public interface IOperationService
    {
        Task<IEnumerable<OperationModel>> GetAllOperations();
        Task<OperationModel> AddOperation(OperationModel anOperation);
        Task<OperationModel> UpdateOperation(OperationModel anOperationModel);
        Task<IEnumerable<OperationGroupModel>> GetAllOperationGroups();
    }
}
