using Armis.BusinessModels.ProcessModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Process.Interfaces
{
    public interface IOperationDataAccess
    {
        Task<IEnumerable<OperationModel>> GetAllOperations();
        Task<OperationModel> CreateOperation(OperationModel anOperation);
        Task<OperationModel> UpdateOperation(OperationModel anOperationModel);
        Task<IEnumerable<OperationGroupModel>> GetAllOperationGroups();
    }
}
