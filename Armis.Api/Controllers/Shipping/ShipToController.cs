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
    public class ShipToController : ControllerBase
    {
        private readonly ILogger<ShipToController> _logger;

        public IShipToService ShipToService { get; set; }

        public ShipToController(IShipToService aShipToService, ILogger<ShipToController> aLogger)
        {
            ShipToService = aShipToService;
            _logger = aLogger;
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<IEnumerable<ShipToModel>>> GetAllShipToByCust(int aCustomerId)
        {
            try
            {
                var data = await ShipToService.GetAllShipToByCust(aCustomerId);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("ShipToController.GetAllShipToByCust(int customerId) Not able to get all ship tos for customer ID ({customerId}). | Message: {exMessage} | StackTrace: {stackTrace}", aCustomerId, ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
    }
}