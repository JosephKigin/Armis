using Armis.BusinessModels.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.QualityServices.Interfaces
{
    public interface IEmployeeService
    {
        Task<bool> CheckIfEmployeeNumberExists(short anEmpNum);
        Task<EmployeeModel> GetEmployeeById(short anEmpNum);
    }
}
