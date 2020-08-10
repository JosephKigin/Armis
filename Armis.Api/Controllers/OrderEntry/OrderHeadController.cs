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
using Microsoft.Extensions.Logging;

namespace Armis.Api.Controllers.OrderEntry
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderHeadController : ControllerBase
    {
        private readonly ILogger<OrderHeadController> _logger;

        public IOrderHeadService OrderHeadService { get; set; }

        public OrderHeadController(IOrderHeadService anOrderHeadService, ILogger<OrderHeadController> aLogger)
        {
            OrderHeadService = anOrderHeadService;
            _logger = aLogger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderHeadModel>>> GetAllOrderHeads() //TODO: This should return a model, not an entity.  This was created like this initially for testing purposes.
        {
            try
            {
                var data = await OrderHeadService.GetAllOrderHeads();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("OrderHeadController.GetAllOrderHeads() Not able to get all order heads. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderHeadModel>>> GetAllHydratedOrderHeads()
        {
            try
            {
                var data = await OrderHeadService.GetAllHydratedOrderHeads();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("OrderHeadController.GetAllHydratedOrderHeads() Not able to get all hydrated order heads. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{anOrderId:int}")]
        public async Task<ActionResult<OrderHeadModel>> GetHydratedOrderHead(int anOrderId)
        {
            try
            {
                var data = await OrderHeadService.GetHydratedOrderHeadById(anOrderId);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("OrderHeadController.GetHydratedOrderHead(int anOrderId) Not able to get hydrated order head for order ID ({orderId}). | Message: {exMessage} | StackTrace: {stackTrace}", anOrderId, ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<OrderHeadModel>> PostNewOrderHead(OrderHeadModel anOrderHeadModel)
        {
            try
            {
                var data = await OrderHeadService.PostOrderHead(anOrderHeadModel);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("OrderHeadController.PostNewOrderHead(OrderHeadModel anOrderHeadModel) Not able to create order head ({orderHeadModel}). | Message: {exMessage} | StackTrace: {stackTrace}", anOrderHeadModel, ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
    }
}