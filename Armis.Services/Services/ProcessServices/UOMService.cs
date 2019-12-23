using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.ModelExtensions.ProcessExtensions;
using Armis.DataLogic.Services.ProcessServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.ProcessServices
{
    public class UOMService : IUOMService
    {
        private ARMISContext context;
        public UOMService(ARMISContext aContext)
        {
            context = aContext;
        }

        public async Task<IEnumerable<UOMCodeModel>> GetAllUOMs()
        {
            var entities = await context.Uomcode.ToListAsync();

            var result = new List<UOMCodeModel>();
            entities.ForEach(i => result.Add(i.ToModel()));
            return result;
        }
    }
}
