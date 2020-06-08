using Armis.BusinessModels.ShippingModels;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.ModelExtensions.ShippingExtensions;
using Armis.DataLogic.Services.ShippingService.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.ShippingService
{
    public class ContainerService : IContainerService
    {
        private ARMISContext Context;

        public ContainerService(ARMISContext aContext)
        {
            Context = aContext;
        }

        public async Task<IEnumerable<ContainerTypeModel>> GetAllContainers()
        {
            var entities = await Context.Container.ToListAsync();

            if(entities == null || !entities.Any()) { throw new Exception("No Containers were returned"); }

            return entities.ToModels();
        }
    }
}
