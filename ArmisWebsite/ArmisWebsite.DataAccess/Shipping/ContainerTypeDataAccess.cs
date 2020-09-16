using Armis.BusinessModels.ShippingModels;
using ArmisWebsite.DataAccess.Shipping.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Shipping
{
    public class ContainerTypeDataAccess : IContainerTypeDataAccess
    {
        private IConfiguration Config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContainerTypeDataAccess(IConfiguration aConfig, IHttpContextAccessor aHttpContextAccessor)
        {
            Config = aConfig;
            _httpContextAccessor = aHttpContextAccessor;
        }

        public async Task<IEnumerable<ContainerModel>> GetAllContainerTypes()
        {
            return await DataAccessGeneric.HttpGetRequest<IEnumerable<ContainerModel>>(Config["APIAddress"] + "api/ContainerType/GetAllContainerTypes", _httpContextAccessor.HttpContext);
        }
    }
}
