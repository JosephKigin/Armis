using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Armis.Api.Controllers.Customer;
using Armis.BusinessModels.ARModels;
using Armis.DataLogic.Services.ARServices.Interfaces;
using Armis.DataLogic.Services.CustomerServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Armis.Api.Controllers.AR
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CertificationChargesController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;

        public ICertificationChargeService CertificationChargeService { get; set; }

        public CertificationChargesController(ICertificationChargeService aCertificationChargeService, ILogger<ContactController> aLogger)
        {
            CertificationChargeService = aCertificationChargeService;
            _logger = aLogger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CertificationChargeModel>>> GetAllCertCharges()
        {
            try
            {
                var data = await CertificationChargeService.GetAllCertCharges();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("Not able to get all Certification Charges. | {ExMessage} | {StackTrace} | {InnerException}", ex.Message, ex.StackTrace, ex.InnerException);
                return BadRequest(ex.Message);
            }
        }
    }
}
