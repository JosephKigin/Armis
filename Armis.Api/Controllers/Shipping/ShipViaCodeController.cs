using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Armis.BusinessModels.ShippingModels;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.Services.ShippingService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Armis.Api.Controllers.Shipping
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShipViaCodeController : ControllerBase
    {
        private readonly ILogger<ShipViaCodeController> _logger;

        public IShipViaCodeService ShipViaService { get; set; }

        public ShipViaCodeController(IShipViaCodeService aShipViaService, ILogger<ShipViaCodeController> aLogger)
        {
            ShipViaService = aShipViaService;
            _logger = aLogger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShipViaCodeModel>>> GetAllShipVias()
        {
            try
            {
                var data = await ShipViaService.GetAllShipVias();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("ShipViaCodeController.GetAllShipVias() Not able to get all ship vias. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
    }
}