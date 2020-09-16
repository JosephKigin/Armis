using Armis.BusinessModels.ShopFloorModels.Department;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.ShopFloor.Department.Interfaces
{
    public interface IDepartmentDataAccess
    {
        Task<IEnumerable<DepartmentModel>> GetAllDepartments();
    }
}
