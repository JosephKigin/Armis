using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Armis.BusinessModels.OrderEntryModels;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.Services.OrderEntryServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Armis.Api.Controllers.OrderEntry
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderHeadController : ControllerBase
    {
        public IOrderHeadService OrderHeadService { get; set; }

        public OrderHeadController(IOrderHeadService anOrderHeadService)
        {
            OrderHeadService = anOrderHeadService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderHead>>> GetAllOrderHeads() //TODO: This should return a model, not an entity.  This was created like this initially for testing purposes.
        {
            try
            {
                var data = await OrderHeadService.GetAllOrderHeads();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}