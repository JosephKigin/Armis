using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Armis.BusinessModels.ShippingModels;
using Armis.DataLogic.Services.ShippingService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Armis.Api.Controllers.Shipping
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PackageCodeController : ControllerBase
    {
        private readonly ILogger<PackageCodeController> _logger;

        public IPackageCodeService PackageCodeService { get; set; }

        public PackageCodeController(IPackageCodeService aPackageCodeService, ILogger<PackageCodeController> aLogger)
        {
            PackageCodeService = aPackageCodeService;
            _logger = aLogger;
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
                _logger.LogError("PackageCodeController.GetAllPackageCodes() Not able to get all package codes. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
    }
}