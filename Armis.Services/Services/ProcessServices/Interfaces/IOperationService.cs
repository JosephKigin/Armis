using Armis.BusinessModels.ProcessModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.ProcessServices.Interfaces
{
    public interface IOperationService
    {
        Task<IEnumerable<OperationModel>> GetAllOperations();
    }
}
