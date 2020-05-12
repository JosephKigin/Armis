using Armis.BusinessModels.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Employee.Interfaces
{
    public interface IEmployeeDataAccess
    {
        Task<EmployeeModel> GetEmployeeById(int id);
    }
}
