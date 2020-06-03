using Armis.BusinessModels.CustomerModels;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.ModelExtensions.CustomerExtensions;
using Armis.DataLogic.Services.CustomerServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.CustomerServices
{
    public class BillToService : IBillToService
    {
        private ARMISContext Context;

        public BillToService(ARMISContext aContext)
        {
            Context = aContext;
        }

        public async Task<BillToModel> GetBillToByCustId(int customerId)
        {
            var entity = await Context.CustBillTo.FirstOrDefaultAsync(i => i.CustId == customerId);

            if(entity == null) { throw new Exception("Could not find a Bill To for customer ID: " + customerId); }

            return entity.ToModel();
        }
    }
}
