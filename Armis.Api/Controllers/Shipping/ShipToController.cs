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
    public class ShipToController : ControllerBase
    {
        public IShipToService ShipToService { get; set; }

        public ShipToController(IShipToService aShipToService)
        {
            ShipToService = aShipToService;
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<IEnumerable<ShipToModel>>> GetAllShipToByCust(int customerId)
        {
            try
            {
                var data = await ShipToService.GetAllShipToByCust(customerId);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}