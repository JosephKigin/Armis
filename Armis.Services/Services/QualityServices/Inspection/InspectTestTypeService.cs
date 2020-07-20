using Armis.BusinessModels.QualityModels.InspectionModels;
using Armis.BusinessModels.QualityModels.Spec;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.ModelExtensions.QualityExtensions.SpecExtensions;
using Armis.DataLogic.Services.QualityServices.Inspection.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.QualityServices.Inspection
{
    public class InspectTestTypeService : IInspectTestTypeService
    {
        private ARMISContext Context;

        public InspectTestTypeService(ARMISContext aContext)
        {
            Context = aContext;
        }
        //Create
        public async Task<InspectTestTypeModel> CreateInspectTestType(InspectTestTypeModel anInspectTestTypeModel)
        {
            var lastInspectTestId = await Context.InspectTestType.MaxAsync(i => i.InspectTestId);
            anInspectTestTypeModel.InspectTestId = (Int16)(lastInspectTestId+1);

            Context.InspectTestType.Add(anInspectTestTypeModel.ToEntity());

            await Context.SaveChangesAsync();

            return anInspectTestTypeModel;
        }

        //READ
        public async Task<IEnumerable<InspectTestTypeModel>> GetAllInspectTestType()
        {
            var entities = await Context.InspectTestType.ToListAsync();

            return entities.ToModels();
        }

        //UPDATE

        //DELETE
    }
}
