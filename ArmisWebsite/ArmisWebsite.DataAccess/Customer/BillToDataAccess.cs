using Armis.BusinessModels.CustomerModels;
using ArmisWebsite.DataAccess.Customer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Customer
{
    public class BillToDataAccess : IBillToDataAccess
    {
        private IConfiguration Config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BillToDataAccess(IConfiguration aConfig, IHttpContextAccessor aHttpContextAccessor)
        {
            Config = aConfig;
            _httpContextAccessor = aHttpContextAccessor;
        }

        public async Task<BillToModel> GetBillToForCustId(int aCustId)
        {
            return await DataAccessGeneric.HttpGetRequest<BillToModel>(Config["APIAddress"] + "api/BillTo/GetBillToByCustId/" + aCustId, _httpContextAccessor.HttpContext);
        }
    }
}
