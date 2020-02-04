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
    public class VariableService : IVariableService
    {
        private ARMISContext context;

        public VariableService(ARMISContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<VariableTemplateModel>> GetAllVariableTemplates()
        {
            var theEntities = await context.StepVarTemplate
                                .Include(i => i.StepVarTypeCdNavigation).ToListAsync();

            if(theEntities == null) { throw new NullReferenceException("No variable templates returned."); }

            var theResult = new List<VariableTemplateModel>();

            foreach(var entity in theEntities) { theResult.Add(entity.ToModel()); }
            

            return theResult;
        }

        public async Task PostVariableTemplate(VariableTemplateModel aTemplateModel)
        {
            context.StepVarTemplate.Add(aTemplateModel.ToEntity());
            await context.SaveChangesAsync();
        }
    }
}
