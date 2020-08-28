using Armis.BusinessModels.ShopFloorModels.Department;
using ArmisWebsite.DataAccess.ShopFloor.Department.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.ShopFloor.Department
{
    public class DepartmentDataAccess : IDepartmentDataAccess
    {
        private IConfiguration Config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DepartmentDataAccess(IConfiguration aConfig, IHttpContextAccessor aHttpContextAccessor)
        {
            Config = aConfig;
            _httpContextAccessor = aHttpContextAccessor;
        }

        public async Task<IEnumerable<DepartmentModel>> GetAllDepartments()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<DepartmentModel>>(Config["APIAddress"] + "api/Department/GetAllDepartments", _httpContextAccessor.HttpContext);
        }
    }
}
