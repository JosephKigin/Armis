using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Armis.BusinessModels.ShippingModels;
using Armis.DataLogic.Services.ShippingService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Armis.Api.Controllers.Shipping
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PackageCodeController : ControllerBase
    {
        public IPackageCodeService PackageCodeService { get; set; }

        public PackageCodeController(IPackageCodeService aPackageCodeService)
        {
            PackageCodeService = aPackageCodeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackageCodeModel>>> GetAllPackageCodes()
        {
            try
            {
                var data = await PackageCodeService.GetAllPackageCodes();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}