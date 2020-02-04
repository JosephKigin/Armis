using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.ModelExtensions.ProcessExtensions;
using Armis.DataLogic.Services.ProcessServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.ProcessServices
{
    public class VariableTypeService : IVariableTypeService
    {
        private ARMISContext context;

        public VariableTypeService(ARMISContext aContext)
        {
            context = aContext;
        }

        public async Task<IEnumerable<VariableTypeModel>> GetAllVariableTypes()
        {
            var theEntities = await context.StepVarType.ToListAsync();

            if (theEntities == null) { throw new NullReferenceException("No variable types returned."); }

            var result = new List<VariableTypeModel>();

            theEntities.ForEach(i => result.Add(i.ToModel()));

            return result;
        }
    }
}
