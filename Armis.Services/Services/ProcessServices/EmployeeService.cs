using Armis.BusinessModels.EmployeeModels;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.ModelExtensions.EmployeeExtensions;
using Armis.DataLogic.Services.ProcessServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.ProcessServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ARMISContext context;
        public EmployeeService(ARMISContext aContext)
        {
            context = aContext;
        }

        public async Task<bool> CheckIfEmployeeNumberExists(short anEmpNum)
        {
            var entity = await context.Employee.FindAsync(anEmpNum);

            if (entity != null){ return true; }
            else { return false; }
        }

        public async Task<EmployeeModel> GetEmployeeById(short anEmpNum)
        {
            var entity = await context.Employee.FindAsync(anEmpNum);

            return entity.ToModel();
        }
    }
}
