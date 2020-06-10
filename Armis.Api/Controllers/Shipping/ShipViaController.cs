﻿using System;
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
    public class ShipViaController : ControllerBase
    {
        public IShipViaCodeService ShipViaService { get; set; }

        public ShipViaController(IShipViaCodeService aShipViaService)
        {
            ShipViaService = aShipViaService;
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
                return BadRequest(ex.Message);
            }
        }
    }
}