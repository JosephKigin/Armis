using Armis.BusinessModels.ShopFloorModels.Department;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.ModelExtensions.ShopFloorExtensions.DepartmentExtensions;
using Armis.DataLogic.Services.ShopFloorServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.ShopFloorServices
{
    public class DepartmentService : IDepartmentService
    {
        private ARMISContext Context;

        public DepartmentService(ARMISContext aContext)
        {
            Context = aContext;
        }

        public async Task<IEnumerable<DepartmentModel>> GetAllDepartments()
        {
            var entities = await Context.Department.ToListAsync();

            if(entities == null || !entities.Any()) { throw new Exception("No departments were returned"); }

            return entities.ToModels();
        }
    }
}
